using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cheese_Pellet : MonoBehaviour
{

    //public variables
    public int damage = 3;

    //private variables
    private float speed = 20.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float slowEffectSpeed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

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

        //moves pellet towards closest player and destroys pellet after 2 seconds
        moveDirection = (closestPlayer.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //apply damage to player
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage;
            //apply 50% move speed slow to player
            other.gameObject.GetComponent<PlayerStatus>().moveSpeed = 4.0f; 
            //destroys the bullet
            Destroy(gameObject);
        }
        //if it hits else anything it gets destroyed
        else
        {
            Destroy(gameObject);
        }
    }

}
