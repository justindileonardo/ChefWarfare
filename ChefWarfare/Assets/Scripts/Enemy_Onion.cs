﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Onion : MonoBehaviour
{

    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer onionSpriteRenderer;
    public float HP;
    public GameObject onionPelletPrefab;
    public GameObject resourceOnionPrefab;

    //private variables
    private bool isMoving;
    private int damageGas = 1;
    private bool gasAttackReady;
    private float gasAttackCooldownTimer;
    private float attackCooldownTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        attackCooldownTimer = 2.0f;
        isMoving = true;
        HP = 25.0f;
        gasAttackReady = true;
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
        if (attackCooldownTimer < 0)
        {
            attackCooldownTimer = 2.0f;
            Instantiate(onionPelletPrefab, transform.position, Quaternion.identity);
        }

        //when gas attack is not ready increase the cooldown
        if (gasAttackReady == false)
        {
            gasAttackCooldownTimer += Time.deltaTime;
            //if cooldown timer reaches 1/2 a second, gas attack is ready
            if(gasAttackCooldownTimer > 0.5f)
            {
                gasAttackReady = true;
            }
        }
        

        //flips sprite depending on where player is
        if (transform.position.x > closestPlayer.transform.position.x)
        {
            onionSpriteRenderer.flipX = false;
        }
        else
        {
            onionSpriteRenderer.flipX = true;
        }




        //kills onion and drops resource
        if (HP <= 0)
        {
            Instantiate(resourceOnionPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }


    }



    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gasAttackReady == true)
            {
                other.gameObject.GetComponent<PlayerMovement>().HP -= damageGas;
                gasAttackCooldownTimer = 0;
                gasAttackReady = false;
            }
        }
    }

}