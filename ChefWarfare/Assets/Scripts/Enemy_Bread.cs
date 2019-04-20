using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bread : MonoBehaviour
{
    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer breadSpriteRenderer_Body;
    public SpriteRenderer breadSpriteRenderer_LegLeft;
    public SpriteRenderer breadSpriteRenderer_LegRight;
    public SpriteRenderer breadSpriteRenderer_RedHit;
    public float HP;

    public GameObject resourceBreadPrefab;

    //private variables
    private bool isMoving;
    private float attackCooldownTimer;
    private int damage = 3;
    private float hpStored;
    private float hpStoredTimer;
    public AudioSource SFX_hit;
    private LevelLogic levelLogicScript;

    // Start is called before the first frame update
    void Start()
    {
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
        attackCooldownTimer = 0;
        isMoving = true;
        HP = 10.0f;
        breadSpriteRenderer_RedHit.enabled = false;
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


        //always decreases cooldown timer
        attackCooldownTimer -= Time.deltaTime;

        //when cooldown timer is less than 0 it will move towards player
        if(attackCooldownTimer < 0)
        {
            isMoving = true;
        }


        //flips sprite depending on where player is
        if (this.transform.position.x > closestPlayer.transform.position.x)
        {
            breadSpriteRenderer_Body.flipX = false;
            breadSpriteRenderer_LegLeft.flipX = false;
            breadSpriteRenderer_LegRight.flipX = false;
            breadSpriteRenderer_RedHit.flipX = false;
        }
        else
        {
            breadSpriteRenderer_Body.flipX = true;
            breadSpriteRenderer_LegLeft.flipX = true;
            breadSpriteRenderer_LegRight.flipX = true;
            breadSpriteRenderer_RedHit.flipX = true;
        }


        //kills bread and drops resource
        if(HP <= 0)
        {
            Instantiate(resourceBreadPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }


    IEnumerator PlayRedHit()
    {
        breadSpriteRenderer_RedHit.enabled = true;
        yield return new WaitForSeconds(0.25f);
        breadSpriteRenderer_RedHit.enabled = false;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        //if collide with player, attack player
        if(other.gameObject.tag == "Player" && isMoving == true)
        {
            //attack player, reset cooldown, stop movement
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage;
            isMoving = false;
            attackCooldownTimer = 1.0f;
            SFX_hit.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyDeath")
        {
            Destroy(gameObject);
        }
    }



}
