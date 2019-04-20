using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tomato : MonoBehaviour
{

    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer tomatoSpriteRenderer;
    public SpriteRenderer tomatoExplosionSpriteRenderer;
    public SpriteRenderer tomatoSpriteRendererRedHit;
    public float HP;

    public GameObject resourceTomatoPrefab;

    public CircleCollider2D[] tomatoColliders;
    public AudioSource SFX_hit;
    private LevelLogic levelLogicScript;

    //private variables
    private bool isMoving;
    private int damage = 10;

    private Animator theAnimator;
    private float hpStored;
    private float hpStoredTimer;


    // Start is called before the first frame update
    void Start()
    {
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
        tomatoSpriteRenderer.enabled = true;
        tomatoExplosionSpriteRenderer.enabled = false;
        isMoving = true;
        HP = 16.0f;
        theAnimator = GetComponent<Animator>();
        theAnimator.SetBool("tomatoIsMoving", true);
        tomatoSpriteRendererRedHit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SFX_hit.volume = levelLogicScript.sfxVolumeSlider.value;

        //Red Hit Effect shows up on enemy screen when take damage
        hpStoredTimer -= Time.deltaTime;
        if (hpStoredTimer <= 0)
        {
            hpStoredTimer = .5f;
            hpStored = HP;
        }
        if (hpStored > HP)
        {
            StartCoroutine(PlayRedHit());
        }

        //finds closest player
        float distanceToClosestPlayer = Mathf.Infinity;
        PlayerMovement closestPlayer = null;
        PlayerMovement[] allPlayers = GameObject.FindObjectsOfType<PlayerMovement>();

        foreach (PlayerMovement currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }

        Debug.DrawLine(transform.position, closestPlayer.transform.position);

        //moves towards closest player
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            theAnimator.SetBool("tomatoIsMoving", false);
        }

        //print("Tomato HP: " + HP);

        //flips sprite depending on where player is
        if (this.transform.position.x > closestPlayer.transform.position.x)
        {
            tomatoSpriteRenderer.flipX = false;
            tomatoSpriteRendererRedHit.flipX = false;
        }
        else
        {
            tomatoSpriteRenderer.flipX = true;
            tomatoSpriteRendererRedHit.flipX = true;
        }

        //kills tomato and drops resource
        if (HP <= 0)
        {
            Instantiate(resourceTomatoPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }

    IEnumerator PlayRedHit()
    {
        tomatoSpriteRendererRedHit.enabled = true;
        yield return new WaitForSeconds(0.25f);
        tomatoSpriteRendererRedHit.enabled = false;
    }

    //Coroutine to explode then keep sprite there then destroy it
    IEnumerator AttackCoroutine()
    {
        SFX_hit.Play();
        tomatoSpriteRenderer.enabled = false;
        tomatoExplosionSpriteRenderer.enabled = true;
        isMoving = false;
        foreach (CircleCollider2D tomatoCollider in tomatoColliders)
        {
            tomatoCollider.enabled = false;
        }
        yield return new WaitForSeconds(.5f);
        yield return new WaitForSeconds(.5f);
        tomatoExplosionSpriteRenderer.enabled = false;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if collider range touches player, blow up, damage player
        if (other.gameObject.tag == "Player" && isMoving == true)
        {
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage;
            StartCoroutine(AttackCoroutine());
        }

        if(other.gameObject.tag == "EnemyDeath")
        {
            Destroy(gameObject);
        }
    }


}
