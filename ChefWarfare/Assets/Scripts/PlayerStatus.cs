using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //public variables
    public int HP;
    public float moveSpeed;

    //private variables
    private float moveSpeedDefault;
    private float moveSpeedEffectTimer;
    private float cheeseMoveSpeedSlowLength;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        moveSpeedDefault = 8.0f;
        moveSpeed = moveSpeedDefault;
        cheeseMoveSpeedSlowLength = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP > 100)
        {
            HP = 100;
        }
        //adding effects to player
        //move speed slow, goes back to default after 1 second
        if (moveSpeed != moveSpeedDefault/*8.0f*/)
        {
            moveSpeedEffectTimer += Time.deltaTime;
            if (moveSpeedEffectTimer > cheeseMoveSpeedSlowLength/*1.0f*/)
            {
                moveSpeedEffectTimer = 0;
                moveSpeed = moveSpeedDefault;
            }
        }
    }
}
