using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStation : MonoBehaviour
{

    private float healTimer;
    private float healSpeed;
    private int healAmountIn;
    private int healAmountOut;
    private bool onHealStation;
    private CircleCollider2D healStationCollider;
    private bool healStationColliderActive;

    // Start is called before the first frame update
    void Start()
    {
        healStationCollider = GetComponent<CircleCollider2D>();
        healSpeed = 1.0f;
        healAmountIn = 8;
        healAmountOut = 15;
        onHealStation = false;
        healTimer = 0;
        healStationCollider.enabled = true;
        healStationColliderActive = true;
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
        if(other.gameObject.tag == "Player" && this.gameObject.tag == "HealStationInSection")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP < 100)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP += healAmountIn;
                healTimer = healSpeed;
                healStationColliderActive = false;
                healStationCollider.enabled = false;
            }
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.tag == "HealStationOutOfSection")
        {
            if (other.gameObject.GetComponent<PlayerStatus>().HP < 100)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP += healAmountOut;
                healTimer = healSpeed;
                healStationColliderActive = false;
                healStationCollider.enabled = false;
            }
        }
    }


}
