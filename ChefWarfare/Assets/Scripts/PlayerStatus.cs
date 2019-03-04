using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //public variables
    public int HP;
    public float moveSpeed;
    public float moveSpeedDefault;
    public bool canMove;

    //private variables
    private float moveSpeedEffectTimer;
    private float cheeseMoveSpeedSlowLength;

    private PlayerMovement myPlayer;
    private SpriteRenderer blackDeathScreenP1;
    private SpriteRenderer blackDeathScreenP2;
    private SpriteRenderer blackDeathScreenP3;
    private SpriteRenderer blackDeathScreenP4;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        moveSpeedDefault = 8.0f;
        moveSpeed = moveSpeedDefault;
        cheeseMoveSpeedSlowLength = 1.0f;
        myPlayer = GetComponent<PlayerMovement>();
        canMove = true;

        blackDeathScreenP1 = GameObject.Find("DeathBlackScreen_P1").GetComponent<SpriteRenderer>();
        blackDeathScreenP2 = GameObject.Find("DeathBlackScreen_P2").GetComponent<SpriteRenderer>();
        blackDeathScreenP3 = GameObject.Find("DeathBlackScreen_P3").GetComponent<SpriteRenderer>();
        blackDeathScreenP4 = GameObject.Find("DeathBlackScreen_P4").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(HP <= 0)
        {
            StartCoroutine(Die());
        }

        if(HP > 100)
        {
            HP = 100;
        }
        //adding effects to player
        //move speed slow, goes back to default after 1 second
        if (moveSpeed < moveSpeedDefault/*8.0f*/ && canMove == true)
        {
            moveSpeedEffectTimer += Time.deltaTime;
            if (moveSpeedEffectTimer > cheeseMoveSpeedSlowLength/*1.0f*/)
            {
                moveSpeedEffectTimer = 0;
                moveSpeed = moveSpeedDefault;
            }
        }
    }


    IEnumerator Die()
    {
        if(myPlayer.player1 == true)
        {
            blackDeathScreenP1.enabled = true;
        }
        else if(myPlayer.player2 == true)
        {
            blackDeathScreenP2.enabled = true;
        }
        else if (myPlayer.player3 == true)
        {
            blackDeathScreenP3.enabled = true;
        }
        else if (myPlayer.player4 == true)
        {
            blackDeathScreenP4.enabled = true;
        }

        canMove = false;
        myPlayer.transform.position = myPlayer.respawnPosition;
        moveSpeed = 0;
        HP = 100;
        yield return new WaitForSeconds(5.0f);
        canMove = true;
        moveSpeed = moveSpeedDefault;
        HP = 100;

        if (myPlayer.player1 == true)
        {
            blackDeathScreenP1.enabled = false;
        }
        else if (myPlayer.player2 == true)
        {
            blackDeathScreenP2.enabled = false;
        }
        else if (myPlayer.player3 == true)
        {
            blackDeathScreenP3.enabled = false;
        }
        else if (myPlayer.player4 == true)
        {
            blackDeathScreenP4.enabled = false;
        }
    }

}
