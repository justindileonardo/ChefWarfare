﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherZoneDamagePlayer_S1 : MonoBehaviour
{


    private float damageTimer;
    private float damageSpeed;
    private int damageAmount;
    private bool inDamageStation;
    private BoxCollider2D damageStationCollider;
    private bool damageStationColliderActive;

    // Start is called before the first frame update
    void Start()
    {
        damageStationCollider = GetComponent<BoxCollider2D>();
        damageSpeed = 1.0f;
        damageAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > -.01f && damageStationColliderActive == false)
        {
            damageTimer -= Time.deltaTime;
        }
        else if (damageTimer <= -.01f && damageStationColliderActive == false)
        {
            damageStationCollider.enabled = true;
            damageStationColliderActive = true;
        }

    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player2")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP > 0)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP -= damageAmount;
                damageTimer = damageSpeed;
                damageStationColliderActive = false;
                damageStationCollider.enabled = false;
            }
        }
        else if (other.gameObject.name == "Player3")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP > 0)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP -= damageAmount;
                damageTimer = damageSpeed;
                damageStationColliderActive = false;
                damageStationCollider.enabled = false;
            }
        }
        else if (other.gameObject.name == "Player4")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP > 0)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP -= damageAmount;
                damageTimer = damageSpeed;
                damageStationColliderActive = false;
                damageStationCollider.enabled = false;
            }
        }
    }
}