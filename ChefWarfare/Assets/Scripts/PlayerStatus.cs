using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Text HpText1;
    private Text HpText2;
    private Text HpText3;
    private Text HpText4;

    private Image HpFill1;
    private Image HpFill2;
    private Image HpFill3;
    private Image HpFill4;


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

        HpText1 = GameObject.Find("UI_HP_Text_P1").GetComponent<Text>();
        HpText2 = GameObject.Find("UI_HP_Text_P2").GetComponent<Text>();
        HpText3 = GameObject.Find("UI_HP_Text_P3").GetComponent<Text>();
        HpText4 = GameObject.Find("UI_HP_Text_P4").GetComponent<Text>();

        HpFill1 = GameObject.Find("UI_HP_Fill_P1").GetComponent<Image>();
        HpFill2 = GameObject.Find("UI_HP_Fill_P2").GetComponent<Image>();
        HpFill3 = GameObject.Find("UI_HP_Fill_P3").GetComponent<Image>();
        HpFill4 = GameObject.Find("UI_HP_Fill_P4").GetComponent<Image>();
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

        //Showing player HP on screen
        if (myPlayer.player1 == true)
        {
            HpText1.text = HP.ToString();
            HpFill1.fillAmount = (float)HP/100;
        }
        else if(myPlayer.player2 == true)
        {
            HpText2.text = HP.ToString();
            HpFill2.fillAmount = (float)HP/100;
        }
        else if (myPlayer.player3 == true)
        {
            HpText3.text = HP.ToString();
            HpFill3.fillAmount = (float)HP/100;
        }
        else if (myPlayer.player4 == true)
        {
            HpText4.text = HP.ToString();
            HpFill4.fillAmount = (float)HP/100;
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
