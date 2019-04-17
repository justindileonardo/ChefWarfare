﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spaghetti_Whip : MonoBehaviour
{
    //public variables

    //private variables
    private int damage = 5;
    public AudioSource SFX_hit;

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
            SFX_hit.Play();
        }
    }

}
