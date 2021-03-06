﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spaghetti : MonoBehaviour
{

    //FindClosestPlayer(); function: https://www.youtube.com/watch?v=YLE3v8bBnck

    //public variables
    public float moveSpeed;
    public SpriteRenderer spaghettiSpriteRenderer;
    public SpriteRenderer spaghettiSpriteRendererRedHit;
    public float HP;

    public GameObject resourceSpaghettiPrefab;
    public GameObject whipPivotPoint;
    public SpriteRenderer whipWindUp;
    public SpriteRenderer whipAttack;
    public BoxCollider2D whipCollider;

    //private variables
    private bool isMoving;
    private float attackCooldownTimer;
    private bool isAttacking;
    private float hpStored;
    private float hpStoredTimer;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldownTimer = 0;
        isMoving = true;
        isAttacking = false;
        HP = 10.0f;
        whipWindUp.enabled = true;
        whipAttack.enabled = false;
        whipCollider.enabled = false;
        spaghettiSpriteRendererRedHit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Red Hit Effect shows up on enemy screen when take damage
        hpStoredTimer -= Time.deltaTime;
        if (hpStoredTimer <= 0)
        {
            hpStoredTimer = .5f;
            hpStored = HP;
        }
        if (hpStored > HP)
        {
            StartCoroutine(PlayRedHit());
        }

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

        //flips sprite depending on where player is
        if (this.transform.position.x > closestPlayer.transform.position.x)
        {
            spaghettiSpriteRenderer.flipX = false;
            spaghettiSpriteRendererRedHit.flipX = false;
        }
        else
        {
            spaghettiSpriteRenderer.flipX = true;
            spaghettiSpriteRendererRedHit.flipX = true;
        }

        //when cooldown timer is less than 0 it will move towards player
        if (attackCooldownTimer < 0)
        {
            isMoving = true;
        }

        //makes the whip track the player's position
        if(isAttacking == false)
        {
            whipPivotPoint.transform.right = closestPlayer.transform.position - whipPivotPoint.transform.position;
        }
       


        //kills spaghetti and drops resource
        if (HP <= 0)
        {
            Instantiate(resourceSpaghettiPrefab, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }

    IEnumerator PlayRedHit()
    {
        spaghettiSpriteRendererRedHit.enabled = true;
        yield return new WaitForSeconds(0.25f);
        spaghettiSpriteRendererRedHit.enabled = false;
    }

    //coroutine to attack a player
    IEnumerator AttackCoroutine()
    {
        
        isAttacking = true;
        isMoving = false;
        whipCollider.enabled = true;
        attackCooldownTimer = 2.0f;
        whipWindUp.enabled = false;
        whipAttack.enabled = true;
        yield return new WaitForSeconds(0.05f);
        whipCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        whipAttack.enabled = false;
        whipWindUp.enabled = true;
        isAttacking = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //attacking a player when in range
        if (other.gameObject.tag == "Player" && isMoving == true && isAttacking == false)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyDeath")
        {
            Destroy(gameObject);
        }
    }

}
