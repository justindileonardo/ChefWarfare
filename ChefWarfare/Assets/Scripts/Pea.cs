using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
    //public variables
    public int damage = 2;

    //private variables
    private GameObject Weapon_PeaShooter;
    private GameObject Weapon_PivotPoint;
    private float speed = 20.0f;
    private Rigidbody2D rb;
    private float existTimer;

    // Start is called before the first frame update
    void Start()
    {
        Weapon_PeaShooter = GameObject.Find("PeaShooter");
        Weapon_PivotPoint = GameObject.Find("Weapon_PivotPoint");
        rb = GetComponent<Rigidbody2D>();
        existTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        existTimer += Time.deltaTime;
        if(existTimer > 0.75f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().HP -= damage;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy_Cheese")
        {
            other.gameObject.GetComponent<Enemy_Cheese>().HP -= damage;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy_Onion")
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
