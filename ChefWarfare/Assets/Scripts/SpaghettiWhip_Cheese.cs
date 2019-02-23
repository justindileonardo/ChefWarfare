using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiWhip_Cheese : MonoBehaviour
{
    //public variables

    //private variables
    private int damage = 24;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage;
            //apply 50% move speed slow to player
            other.gameObject.GetComponent<PlayerStatus>().moveSpeed = 4.0f;
        }
        else if (other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage;
        }
        else if (other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage;
        }
        else if (other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage/2;            //the trigger for when the spaghetti enemy knows to attack gets hit, so it hits twice.  Maybe fix this one day?   
        }
        else if (other.gameObject.tag == "Enemy_Cheese")
        {
            other.gameObject.GetComponent<Enemy_Cheese>().HP -= damage;
        }
        else if (other.gameObject.tag == "Enemy_Onion")
        {
            other.gameObject.GetComponent<Enemy_Onion>().HP -= damage;
        }
    }

}
