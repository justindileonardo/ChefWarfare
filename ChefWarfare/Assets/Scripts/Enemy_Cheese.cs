using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cheese : MonoBehaviour
{

    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer cheeseSpriteRenderer;
    public float HP;
    public GameObject cheesePelletPrefab;
    public GameObject resourceCheesePrefab;

    //private variables
    private bool isMoving;
    private float attackCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldownTimer = 1.5f;
        isMoving = true;
        HP = 25.0f;
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

        //attack (shoot pellet)
        if(attackCooldownTimer < 0)
        {
            attackCooldownTimer = 1.5f;
            Instantiate(cheesePelletPrefab, transform.position, Quaternion.identity);
        }


        //flips sprite depending on where player is
        if (this.transform.position.x > closestPlayer.transform.position.x)
        {
            cheeseSpriteRenderer.flipX = false;
        }
        else
        {
            cheeseSpriteRenderer.flipX = true;
        }


        //kills cheese and drops resource
        if (HP <= 0)
        {
            Instantiate(resourceCheesePrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
