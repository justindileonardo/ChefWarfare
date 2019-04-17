﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiWhip_Onion : MonoBehaviour
{
    //public variables
    public AudioSource SFX_hit;

    //private variables
    private int damage = 20;
    private WeaponManager weaponManagerScript;


    // Start is called before the first frame update
    void Start()
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
        weaponManagerScript = closestPlayer.GetComponent<WeaponManager>();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            //apply blind to other player for 2 seconds
            other.gameObject.GetComponent<BlindEffect>().blindEffectTimer = 2.0f;
            SFX_hit.Play();
        }
        else if (other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            SFX_hit.Play();
        }
        else if (other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            SFX_hit.Play();
        }
        else if (other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage / 2 * weaponManagerScript.damageBoostMultiplier;            //the trigger for when the spaghetti enemy knows to attack gets hit, so it hits twice.  Maybe fix this one day?   
            SFX_hit.Play();
        }
        else if (other.gameObject.tag == "Enemy_Cheese")
        {
            other.gameObject.GetComponent<Enemy_Cheese>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            SFX_hit.Play();
        }
        else if (other.gameObject.tag == "Enemy_Onion")
        {
            other.gameObject.GetComponent<Enemy_Onion>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            SFX_hit.Play();
        }
    }

}
