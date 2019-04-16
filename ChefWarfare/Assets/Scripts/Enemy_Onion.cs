using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Onion : MonoBehaviour
{

    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer onionSpriteRenderer;
    public SpriteRenderer onionSpriteRendererRedHit;
    public float HP;
    public GameObject onionPelletPrefab;
    public GameObject resourceOnionPrefab;

    //private variables
    private bool isMoving;
    private float attackCooldownTimer;
    private float hpStored;
    private float hpStoredTimer;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldownTimer = 2.0f;
        isMoving = true;
        HP = 20.0f;
        onionSpriteRendererRedHit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        //attack (shoot pellet)
        if (attackCooldownTimer < 0)
        {
            attackCooldownTimer = 2.0f;
            Instantiate(onionPelletPrefab, transform.position, Quaternion.identity);
        }

        
        

        //flips sprite depending on where player is
        if (transform.position.x > closestPlayer.transform.position.x)
        {
            onionSpriteRenderer.flipX = false;
            onionSpriteRendererRedHit.flipX = false;
        }
        else
        {
            onionSpriteRenderer.flipX = true;
            onionSpriteRendererRedHit.flipX = true;
        }




        //kills onion and drops resource
        if (HP <= 0)
        {
            Instantiate(resourceOnionPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }


    }

    IEnumerator PlayRedHit()
    {
        onionSpriteRendererRedHit.enabled = true;
        yield return new WaitForSeconds(0.25f);
        onionSpriteRendererRedHit.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyDeath")
        {
            Destroy(gameObject);
        }
    }

}
