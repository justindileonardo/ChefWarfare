using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoChunk : MonoBehaviour
{
    //public variables
    public int damage;

    //private variables
    private float speed = 30.0f;
    private float existTimer;

    // Start is called before the first frame update
    void Start()
    {
        existTimer = 0;
        damage = 8;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        existTimer += Time.deltaTime;
        if (existTimer > 0.75f)
        {
            Destroy(gameObject);
        }
        if (GetComponent<BoxCollider2D>().enabled == false)
        {
            if (existTimer > .025f)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().HP -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy_Cheese")
        {
            other.gameObject.GetComponent<Enemy_Cheese>().HP -= damage;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy_Onion")
        {
            other.gameObject.GetComponent<Enemy_Onion>().HP -= damage;
            Destroy(gameObject);
        }
        //if hits anything other than player or enemy destroy itself
        else
        {
            Destroy(gameObject);
        }
    }


}
