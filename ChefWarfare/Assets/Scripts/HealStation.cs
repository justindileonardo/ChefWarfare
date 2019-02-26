using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStation : MonoBehaviour
{

    private float healTimer;
    private float healSpeed;
    private int healAmount;
    private bool onHealStation;
    private BoxCollider2D healStationCollider;
    private bool healStationColliderActive;

    // Start is called before the first frame update
    void Start()
    {
        healStationCollider = GetComponent<BoxCollider2D>();
        healSpeed = 1.0f;
        healAmount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (healTimer > -.01f && healStationColliderActive == false)
        {
            healTimer -= Time.deltaTime;
        }
        else if(healTimer <= -.01f && healStationColliderActive == false)
        {
            healStationCollider.enabled = true;
            healStationColliderActive = true;
        }
        
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP < 100)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP += healAmount;
                healTimer = healSpeed;
                healStationColliderActive = false;
                healStationCollider.enabled = false;
            }
        }
    }


}
