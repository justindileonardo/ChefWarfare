using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spaghetti_Whip : MonoBehaviour
{
    //public variables

    //private variables
    private int damage = 8;

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
            other.gameObject.GetComponent<PlayerMovement>().HP -= damage;
        }
    }

}
