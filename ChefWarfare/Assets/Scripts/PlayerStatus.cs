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

    private Canvas canvasP1;
    private Canvas canvasP2;
    private Canvas canvasP3;
    private Canvas canvasP4;

    private Image HpPlayerFill1;
    private Image HpPlayerFill2;
    private Image HpPlayerFill3;
    private Image HpPlayerFill4;

    private float playerHPBarAppear_Timer_P1;
    private float playerHPBarAppear_Timer_P2;
    private float playerHPBarAppear_Timer_P3;
    private float playerHPBarAppear_Timer_P4;

    private EnemySpawnerP1 esP1;
    private EnemySpawnerP2 esP2;
    private EnemySpawnerP3 esP3;
    private EnemySpawnerP4 esP4;

    private LevelLogic levelLogicScript;

    [SerializeField] private int hpStored;
    [SerializeField] private float hpStoredTimer;

    private Image RedHitEffect_P1;
    private Image RedHitEffect_P2;
    private Image RedHitEffect_P3;
    private Image RedHitEffect_P4;
    private Image GreenHitEffect_P1;
    private Image GreenHitEffect_P2;
    private Image GreenHitEffect_P3;
    private Image GreenHitEffect_P4;

    private RecipeBook recipeBookScript_P1;
    private RecipeBook recipeBookScript_P2;
    private RecipeBook recipeBookScript_P3;
    private RecipeBook recipeBookScript_P4;

    private BlindEffect blindEffectScript;

    public SpriteRenderer redChefHitEffect_Head;
    public SpriteRenderer redChefHitEffect_Body;


    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        moveSpeedDefault = 8.0f;
        moveSpeed = moveSpeedDefault;
        moveSpeedEffectTimer = 0;
        cheeseMoveSpeedSlowLength = 1.0f;
        myPlayer = GetComponent<PlayerMovement>();
        canMove = true;

        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();

        blackDeathScreenP1 = GameObject.Find("DeathBlackScreen_P1").GetComponent<SpriteRenderer>();
        blackDeathScreenP2 = GameObject.Find("DeathBlackScreen_P2").GetComponent<SpriteRenderer>();
        blackDeathScreenP3 = GameObject.Find("DeathBlackScreen_P3").GetComponent<SpriteRenderer>();
        blackDeathScreenP4 = GameObject.Find("DeathBlackScreen_P4").GetComponent<SpriteRenderer>();

        /*
        HpText1 = GameObject.Find("UI_HP_Text_P1").GetComponent<Text>();
        HpText2 = GameObject.Find("UI_HP_Text_P2").GetComponent<Text>();
        HpText3 = GameObject.Find("UI_HP_Text_P3").GetComponent<Text>();
        HpText4 = GameObject.Find("UI_HP_Text_P4").GetComponent<Text>();
        */
        /*
        HpFill1 = GameObject.Find("UI_HP_Fill_P1").GetComponent<Image>();
        HpFill2 = GameObject.Find("UI_HP_Fill_P2").GetComponent<Image>();
        HpFill3 = GameObject.Find("UI_HP_Fill_P3").GetComponent<Image>();
        HpFill4 = GameObject.Find("UI_HP_Fill_P4").GetComponent<Image>();
        */

        HpFill1 = GameObject.Find("UI_HPBar_P1").GetComponent<Image>();
        HpFill2 = GameObject.Find("UI_HPBar_P2").GetComponent<Image>();
        HpFill3 = GameObject.Find("UI_HPBar_P3").GetComponent<Image>();
        HpFill4 = GameObject.Find("UI_HPBar_P4").GetComponent<Image>();

        canvasP1 = GameObject.Find("Canvas_P1").GetComponent<Canvas>();
        canvasP2 = GameObject.Find("Canvas_P2").GetComponent<Canvas>();
        canvasP3 = GameObject.Find("Canvas_P3").GetComponent<Canvas>();
        canvasP4 = GameObject.Find("Canvas_P4").GetComponent<Canvas>();

        HpPlayerFill1 = GameObject.Find("UI_Player_HPBar_P1").GetComponent<Image>();
        HpPlayerFill2 = GameObject.Find("UI_Player_HPBar_P2").GetComponent<Image>();
        HpPlayerFill3 = GameObject.Find("UI_Player_HPBar_P3").GetComponent<Image>();
        HpPlayerFill4 = GameObject.Find("UI_Player_HPBar_P4").GetComponent<Image>();

        esP1 = GameObject.Find("EnemySpawnerP1").GetComponent<EnemySpawnerP1>();
        esP2 = GameObject.Find("EnemySpawnerP2").GetComponent<EnemySpawnerP2>();
        esP3 = GameObject.Find("EnemySpawnerP3").GetComponent<EnemySpawnerP3>();
        esP4 = GameObject.Find("EnemySpawnerP4").GetComponent<EnemySpawnerP4>();

        RedHitEffect_P1 = GameObject.Find("RedHitEffect_P1").GetComponent<Image>();
        RedHitEffect_P2 = GameObject.Find("RedHitEffect_P2").GetComponent<Image>();
        RedHitEffect_P3 = GameObject.Find("RedHitEffect_P3").GetComponent<Image>();
        RedHitEffect_P4 = GameObject.Find("RedHitEffect_P4").GetComponent<Image>();

        GreenHitEffect_P1 = GameObject.Find("GreenHitEffect_P1").GetComponent<Image>();
        GreenHitEffect_P2 = GameObject.Find("GreenHitEffect_P2").GetComponent<Image>();
        GreenHitEffect_P3 = GameObject.Find("GreenHitEffect_P3").GetComponent<Image>();
        GreenHitEffect_P4 = GameObject.Find("GreenHitEffect_P4").GetComponent<Image>();

        RedHitEffect_P1.enabled = false;
        RedHitEffect_P2.enabled = false;
        RedHitEffect_P3.enabled = false;
        RedHitEffect_P4.enabled = false;

        GreenHitEffect_P1.enabled = false;
        GreenHitEffect_P2.enabled = false;
        GreenHitEffect_P3.enabled = false;
        GreenHitEffect_P4.enabled = false;

        canvasP1.enabled = false;
        canvasP2.enabled = false;
        canvasP3.enabled = false;
        canvasP4.enabled = false;

        playerHPBarAppear_Timer_P1 = 0;
        playerHPBarAppear_Timer_P2 = 0;
        playerHPBarAppear_Timer_P3 = 0;
        playerHPBarAppear_Timer_P4 = 0;

        recipeBookScript_P1 = GameObject.Find("CraftingOven_S1").GetComponent<RecipeBook>();
        recipeBookScript_P2 = GameObject.Find("CraftingOven_S2").GetComponent<RecipeBook>();
        recipeBookScript_P3 = GameObject.Find("CraftingOven_S3").GetComponent<RecipeBook>();
        recipeBookScript_P4 = GameObject.Find("CraftingOven_S4").GetComponent<RecipeBook>();

        blindEffectScript = GetComponent<BlindEffect>();

        redChefHitEffect_Head.enabled = false;
        redChefHitEffect_Body.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //makes it so when dead cant move
        if(myPlayer.player1)
        {
            if (blackDeathScreenP1.enabled)
            {
                canMove = false;
            }
        }
        if (myPlayer.player2)
        {
            if (blackDeathScreenP2.enabled)
            {
                canMove = false;
            }
        }
        if (myPlayer.player3)
        {
            if (blackDeathScreenP3.enabled)
            {
                canMove = false;
            }
        }
        if (myPlayer.player4)
        {
            if (blackDeathScreenP4.enabled)
            {
                canMove = false;
            }
        }

        if (HP <= 0)
        {
            PlayerDie();
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

        
        if (myPlayer.player1 == true)
        {
            //Showing player HP on screen
            //HpText1.text = HP.ToString();
            HpFill1.fillAmount = (float)HP / 100;
            HpPlayerFill1.fillAmount = (float)HP / 100;

            //Red Hit Effect shows up on player's screen when take damage
            hpStoredTimer -= Time.deltaTime;
            if (hpStoredTimer <= 0)
            {
                hpStoredTimer = .5f;
                hpStored = HP;
            }
            if (hpStored > HP)
            {
                StartCoroutine(PlayRedHitScreen1());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P1 = 3.0f;
                canvasP1.enabled = true;
            }
            if(hpStored < HP)
            {
                StartCoroutine(PlayGreenHitScreen1());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P1 = 3.0f;
                canvasP1.enabled = true;
            }
            if (blackDeathScreenP1.enabled == true)
            {
                RedHitEffect_P1.enabled = false;
                GreenHitEffect_P1.enabled = false;
            }

            //Player HP Bar
            if(playerHPBarAppear_Timer_P1 >= 0)
            {
                playerHPBarAppear_Timer_P1 -= Time.deltaTime;
            }
            else
            {
                canvasP1.enabled = false;
            }

        }
        else if(myPlayer.player2 == true)
        {
            //Showing player HP on screen
            //HpText2.text = HP.ToString();
            HpFill2.fillAmount = (float)HP / 100;
            HpPlayerFill2.fillAmount = (float)HP / 100;

            //Red Hit Effect shows up on player's screen when take damage
            hpStoredTimer -= Time.deltaTime;
            if (hpStoredTimer <= 0)
            {
                hpStoredTimer = .5f;
                hpStored = HP;
            }
            if (hpStored > HP)
            {
                StartCoroutine(PlayRedHitScreen2());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P2 = 3.0f;
                canvasP2.enabled = true;
            }
            if (hpStored < HP)
            {
                StartCoroutine(PlayGreenHitScreen2());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P2 = 3.0f;
                canvasP2.enabled = true;
            }
            if (blackDeathScreenP2.enabled == true)
            {
                RedHitEffect_P2.enabled = false;
                GreenHitEffect_P2.enabled = false;
            }

            //Player HP Bar
            if (playerHPBarAppear_Timer_P2 >= 0)
            {
                playerHPBarAppear_Timer_P2 -= Time.deltaTime;
            }
            else
            {
                canvasP2.enabled = false;
            }
        }
        else if (myPlayer.player3 == true)
        {
            //Showing player HP on screen
            //HpText3.text = HP.ToString();
            HpFill3.fillAmount = (float)HP / 100;
            HpPlayerFill3.fillAmount = (float)HP / 100;

            //Red Hit Effect shows up on player's screen when take damage
            hpStoredTimer -= Time.deltaTime;
            if (hpStoredTimer <= 0)
            {
                hpStoredTimer = .5f;
                hpStored = HP;
            }
            if (hpStored > HP)
            {
                StartCoroutine(PlayRedHitScreen3());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P3 = 3.0f;
                canvasP3.enabled = true;
            }
            if (hpStored < HP)
            {
                StartCoroutine(PlayGreenHitScreen3());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P3 = 3.0f;
                canvasP3.enabled = true;
            }
            if (blackDeathScreenP3.enabled == true)
            {
                RedHitEffect_P3.enabled = false;
                GreenHitEffect_P3.enabled = false;
            }

            //Player HP Bar
            if (playerHPBarAppear_Timer_P3 >= 0)
            {
                playerHPBarAppear_Timer_P3 -= Time.deltaTime;
            }
            else
            {
                canvasP3.enabled = false;
            }
        }
        else if (myPlayer.player4 == true)
        {
            //Showing player HP on screen
            //HpText4.text = HP.ToString();
            HpFill4.fillAmount = (float)HP / 100;
            HpPlayerFill4.fillAmount = (float)HP / 100;

            //Red Hit Effect shows up on player's screen when take damage
            hpStoredTimer -= Time.deltaTime;
            if (hpStoredTimer <= 0)
            {
                hpStoredTimer = .5f;
                hpStored = HP;
            }
            if (hpStored > HP)
            {
                StartCoroutine(PlayRedHitScreen4());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P4 = 3.0f;
                canvasP4.enabled = true;
            }
            if (hpStored < HP)
            {
                StartCoroutine(PlayGreenHitScreen4());
                //Player HP Bar Enabling
                playerHPBarAppear_Timer_P4 = 3.0f;
                canvasP4.enabled = true;
            }
            if (blackDeathScreenP4.enabled == true)
            {
                RedHitEffect_P4.enabled = false;
                GreenHitEffect_P4.enabled = false;
            }

            //Player HP Bar
            if (playerHPBarAppear_Timer_P4 >= 0)
            {
                playerHPBarAppear_Timer_P4 -= Time.deltaTime;
            }
            else
            {
                canvasP4.enabled = false;
            }
        }
    }

    IEnumerator PlayRedHitScreen1()
    {
        RedHitEffect_P1.enabled = true;
        redChefHitEffect_Head.enabled = true;
        redChefHitEffect_Body.enabled = true;
        yield return new WaitForSeconds(0.25f);
        RedHitEffect_P1.enabled = false;
        redChefHitEffect_Head.enabled = false;
        redChefHitEffect_Body.enabled = false;
    }

    IEnumerator PlayRedHitScreen2()
    {
        RedHitEffect_P2.enabled = true;
        redChefHitEffect_Head.enabled = true;
        redChefHitEffect_Body.enabled = true;
        yield return new WaitForSeconds(0.25f);
        RedHitEffect_P2.enabled = false;
        redChefHitEffect_Head.enabled = false;
        redChefHitEffect_Body.enabled = false;
    }

    IEnumerator PlayRedHitScreen3()
    {
        RedHitEffect_P3.enabled = true;
        redChefHitEffect_Head.enabled = true;
        redChefHitEffect_Body.enabled = true;
        yield return new WaitForSeconds(0.25f);
        RedHitEffect_P3.enabled = false;
        redChefHitEffect_Head.enabled = false;
        redChefHitEffect_Body.enabled = false;
    }

    IEnumerator PlayRedHitScreen4()
    {
        RedHitEffect_P4.enabled = true;
        redChefHitEffect_Head.enabled = true;
        redChefHitEffect_Body.enabled = true;
        yield return new WaitForSeconds(0.25f);
        RedHitEffect_P4.enabled = false;
        redChefHitEffect_Head.enabled = false;
        redChefHitEffect_Body.enabled = false;
    }

    IEnumerator PlayGreenHitScreen1()
    {
        GreenHitEffect_P1.enabled = true;
        yield return new WaitForSeconds(0.25f);
        GreenHitEffect_P1.enabled = false;
    }

    IEnumerator PlayGreenHitScreen2()
    {
        GreenHitEffect_P2.enabled = true;
        yield return new WaitForSeconds(0.25f);
        GreenHitEffect_P2.enabled = false;
    }

    IEnumerator PlayGreenHitScreen3()
    {
        GreenHitEffect_P3.enabled = true;
        yield return new WaitForSeconds(0.25f);
        GreenHitEffect_P3.enabled = false;
    }

    IEnumerator PlayGreenHitScreen4()
    {
        GreenHitEffect_P4.enabled = true;
        yield return new WaitForSeconds(0.25f);
        GreenHitEffect_P4.enabled = false;
    }


    public void PlayerDie()
    {
        if (myPlayer.player1 == true)
        {
            recipeBookScript_P1.ExitCookingStationDelayFunction();
            esP1.DestroyAllEnemies();
            esP1.enemySpawnerActive = false;
            esP1.enemyReadyToSpawn = false;
            esP1.enemySpawnTimer = 0;
        }
        else if (myPlayer.player2 == true)
        {
            recipeBookScript_P2.ExitCookingStationDelayFunction();
            esP2.DestroyAllEnemies();
            esP2.enemySpawnerActive = false;
            esP2.enemyReadyToSpawn = false;
            esP2.enemySpawnTimer = 0;
        }
        else if (myPlayer.player3 == true)
        {
            recipeBookScript_P3.ExitCookingStationDelayFunction();
            esP3.DestroyAllEnemies();
            esP3.enemySpawnerActive = false;
            esP3.enemyReadyToSpawn = false;
            esP3.enemySpawnTimer = 0;
        }
        else if (myPlayer.player4 == true)
        {
            recipeBookScript_P4.ExitCookingStationDelayFunction();
            esP4.DestroyAllEnemies();
            esP4.enemySpawnerActive = false;
            esP4.enemyReadyToSpawn = false;
            esP4.enemySpawnTimer = 0;
        }
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        if(myPlayer.player1 == true)
        {
            blackDeathScreenP1.enabled = true;
            levelLogicScript.scoreRed -= 10;
        }
        else if(myPlayer.player2 == true)
        {
            blackDeathScreenP2.enabled = true;
            levelLogicScript.scoreBlue -= 10;
        }
        else if (myPlayer.player3 == true)
        {
            blackDeathScreenP3.enabled = true;
            levelLogicScript.scoreGreen -= 10;
        }
        else if (myPlayer.player4 == true)
        {
            blackDeathScreenP4.enabled = true;
            levelLogicScript.scoreOrange -= 10;
        }
        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds(.01f);
        canMove = false;
        myPlayer.transform.position = myPlayer.respawnPosition;
        moveSpeed = 0;
        HP = 100;
        blindEffectScript.blindEffectTimer = 0;
        blindEffectScript.blindEffectSprite.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 0;
        myPlayer.transform.position = myPlayer.respawnPosition;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 0;
        myPlayer.transform.position = myPlayer.respawnPosition;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 0;
        myPlayer.transform.position = myPlayer.respawnPosition;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 0;
        myPlayer.transform.position = myPlayer.respawnPosition;
        yield return new WaitForSeconds(4.0f);
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
