using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Onion_Pellet : MonoBehaviour
{
    //public variables
    public int damage = 1;

    //private variables
    private float speed = 15.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float blindEffectLength;
    public AudioSource SFX_hit;

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
        Destroy(gameObject, 2.25f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyProjectile()
    {
        SFX_hit.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //apply damage to player
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage;
            //apply blind to other player for 2 seconds
            other.gameObject.GetComponent<BlindEffect>().blindEffectTimer = 2.0f;
            //destroys the bullet
            StartCoroutine(DestroyProjectile());
        }
        //if it hits else anything it gets destroyed
        else
        {
            Destroy(gameObject);
        }
    }

}
