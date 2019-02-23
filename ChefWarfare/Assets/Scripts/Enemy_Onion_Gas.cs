using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Onion_Gas : MonoBehaviour
{

    //private variables
    private int damageGas = 1;
    private bool gasAttackReady;
    private float gasAttackCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        gasAttackReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        //when gas attack is not ready increase the cooldown
        if (gasAttackReady == false)
        {
            gasAttackCooldownTimer += Time.deltaTime;
            //if cooldown timer reaches 1/2 a second, gas attack is ready
            if (gasAttackCooldownTimer > 0.5f)
            {
                gasAttackReady = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gasAttackReady == true)
            {
                other.gameObject.GetComponent<PlayerStatus>().HP -= damageGas;
                gasAttackCooldownTimer = 0;
                gasAttackReady = false;
            }
        }
    }

}
