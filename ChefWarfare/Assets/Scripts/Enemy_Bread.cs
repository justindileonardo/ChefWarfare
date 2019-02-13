using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bread : MonoBehaviour
{
    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer breadSpriteRenderer;
    public float HP;

    public GameObject resourceBreadPrefab;

    //private variables
    private bool isMoving;
    private float attackCooldownTimer;
    private int damage = 3;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldownTimer = 0;
        isMoving = true;
        HP = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {

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
            breadSpriteRenderer.flipX = false;
        }
        else
        {
            breadSpriteRenderer.flipX = true;
        }


        //kills bread and drops resource
        if(HP <= 0)
        {
            Instantiate(resourceBreadPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }


    void OnCollisionStay2D(Collision2D other)
    {
        //if collide with player, attack player
        if(other.gameObject.tag == "Player" && isMoving == true)
        {
            //attack player, reset cooldown, stop movement
            other.gameObject.GetComponent<PlayerMovement>().HP -= damage;
            isMoving = false;
            attackCooldownTimer = 1.0f;

        }
    }




}
