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
        //if hits anything other than player or enemy destroy itself
        if(other.gameObject.tag != "Player" || other.gameObject.tag != "Enemy_Bread" /*|| other.gameObject.tag != " "......*/)
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().HP -= damage;
        }
        if(other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage;
        }
        if(other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage;
        }
        if(other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage;
        }
    }


}
