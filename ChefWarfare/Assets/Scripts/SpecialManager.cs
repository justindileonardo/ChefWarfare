using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialManager : MonoBehaviour
{

    //public variables

    //setting player number
    public bool player1;
    public bool player2;
    public bool player3;
    public bool player4;

    //Speed Boost Snack
    public SpriteRenderer snack_SpeedBoost;
    public GameObject snack_SpeedBoost_ParticleSystem;
    public bool hasSnack_SpeedBoost;

    //Damage Boost Snack
    public SpriteRenderer snack_DamageBoost;
    public GameObject snack_DamageBoost_ParticleSystem;
    public bool hasSnack_DamageBoost;

    //Health Boost Snack
    public SpriteRenderer snack_HealthBoost;
    public GameObject snack_HealthBoost_ParticleSystem;
    public bool hasSnack_HealthBoost;

    //Audio
    public AudioSource SFX_drinkShake;


    //private variables
    private string inputX;

    //Player Status Script Reference
    private PlayerStatus playerStatusScript;

    //Player Weapon Manager Script Reference
    private WeaponManager weaponManagerScript;

    //Speed Boost Snack
    private float snackSpeedBoost_Cooldown;
    private float snackSpeedBoost_CooldownLength;
    private bool snackSpeedBoost_Ready;
    private float snackSpeedBoost_ActiveTimer;
    private float snackSpeedBoost_ActiveLength;

    //Damage Boost Snack
    private float snackDamageBoost_Cooldown;
    private float snackDamageBoost_CooldownLength;
    private bool snackDamageBoost_Ready;
    private float snackDamageBoost_ActiveTimer;
    private float snackDamageBoost_ActiveLength;

    //Health Boost Snack
    private float snackHealthBoost_Cooldown;
    private float snackHealthBoost_CooldownLength;
    private bool snackHealthBoost_Ready;
    private float snackHealthBoost_ActiveTimer;
    private float snackHealthBoost_ActiveLength;
    private float snackHealthBoost_AddHealthTimer;
    private float snackHealthBoost_AddHealthTimerLength;
    private int snackHealthBoost_AddHealthAmount;

    private PlayerMovement playerMovementScript;
    private LevelLogic levelLogicScript;

    private Image sSpeed;
    private Image sDamage;
    private Image sHealth;
    private Image sBackBox;
    private Image sMainBox;
    private Image sFrontBox;
    private Image sReadyBox;

    public AudioSource AS_Heal;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();

        if(playerMovementScript.isMac == false)
        {
            //setting player number Inputs
            if (player1)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P1";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P1";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P1").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P1").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P1").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P1").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P1").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P1").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P1").GetComponent<Image>();
            }
            else if (player2)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P2";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P2";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P2").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P2").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P2").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P2").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P2").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P2").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P2").GetComponent<Image>();
                
            }
            else if (player3)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P3";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P3";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P3").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P3").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P3").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P3").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P3").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P3").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P3").GetComponent<Image>();
                
            }
            else if (player4)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P4";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P4";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P4").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P4").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P4").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P4").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P4").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P4").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P4").GetComponent<Image>();
                
            }
        }
        else if(playerMovementScript.isMac == true)
        {
            //setting player number Inputs
            if (player1)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P1_MAC";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P1";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P1").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P1").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P1").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P1").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P1").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P1").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P1").GetComponent<Image>();
            }
            else if (player2)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P2_MAC";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P2";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P2").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P2").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P2").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P2").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P2").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P2").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P2").GetComponent<Image>();
                
            }
            else if (player3)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P3_MAC";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P3";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P3").GetComponent<Image>();
                sDamage = GameObject.Find("UI_SnackSlot_Damage_P3").GetComponent<Image>();
                sHealth = GameObject.Find("UI_SnackSlot_Health_P3").GetComponent<Image>();
                sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P3").GetComponent<Image>();
                sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P3").GetComponent<Image>();
                sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P3").GetComponent<Image>();
                sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P3").GetComponent<Image>();
                
            }
            else if (player4)
            {
                if (SceneSwitchingScript.isXbox == true)
                {
                    inputX = "Xbox_Button_X_P4_MAC";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    inputX = "PS4_Button_X_P4";
                }


                sSpeed = GameObject.Find("UI_SnackSlot_Speed_P4").GetComponent<Image>();
               sDamage = GameObject.Find("UI_SnackSlot_Damage_P4").GetComponent<Image>();
               sHealth = GameObject.Find("UI_SnackSlot_Health_P4").GetComponent<Image>();
               sBackBox = GameObject.Find("UI_SnackSlot_TimerBackBox_P4").GetComponent<Image>();
               sMainBox = GameObject.Find("UI_SnackSlot_TimerBox_P4").GetComponent<Image>();
               sReadyBox = GameObject.Find("UI_SnackSlot_TimerReadyBox_P4").GetComponent<Image>();
               sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P4").GetComponent<Image>();
               sFrontBox = GameObject.Find("UI_SnackSlot_TimerFrontBox_P4").GetComponent<Image>();
               
            }
        }

        //UI on/off
        sSpeed.enabled = false;
        sDamage.enabled = false;
        sHealth.enabled = false;

        playerStatusScript = GetComponent<PlayerStatus>();
        weaponManagerScript = GetComponent<WeaponManager>();

        //setting variables
        //Snack - Speed Boost
        snack_SpeedBoost.enabled = false;                                       /*DEFAULT*/
        snack_SpeedBoost_ParticleSystem.SetActive(false);                       /*DEFAULT*/
        hasSnack_SpeedBoost = false;                                            /*DEFAULT*/
        //hasSnack_SpeedBoost = true;                                             /*TESTING*/
        snackSpeedBoost_CooldownLength = 30.0f;                                 /*DEFAULT*/
        //snackSpeedBoost_CooldownLength = 10.0f;                                 /*TESTING*/
        snackSpeedBoost_Cooldown = 0;              
        snackSpeedBoost_Ready = false;                                          /*DEFAULT*/
        snackSpeedBoost_ActiveLength = 7.5f;
        snackSpeedBoost_ActiveTimer = snackSpeedBoost_ActiveLength;

        //Snack - Damage Boost
        snack_DamageBoost.enabled = false;                                       /*DEFAULT*/
        snack_DamageBoost_ParticleSystem.SetActive(false);                       /*DEFAULT*/
        hasSnack_DamageBoost = false;                                            /*DEFAULT*/
        //hasSnack_DamageBoost = true;                                             /*TESTING*/
        snackDamageBoost_CooldownLength = 30.0f;                                 /*DEFAULT*/
        //snackDamageBoost_CooldownLength = 10.0f;                                 /*TESTING*/
        snackDamageBoost_Cooldown = 0;
        snackDamageBoost_Ready = false;                                          /*DEFAULT*/
        snackDamageBoost_ActiveLength = 7.5f;
        snackDamageBoost_ActiveTimer = snackDamageBoost_ActiveLength;

        //Snack - Health Boost
        snack_HealthBoost.enabled = false;                                       /*DEFAULT*/
        snack_HealthBoost_ParticleSystem.SetActive(false);                       /*DEFAULT*/
        hasSnack_HealthBoost = false;                                            /*DEFAULT*/
        //hasSnack_HealthBoost = true;                                             /*TESTING*/
        snackHealthBoost_CooldownLength = 30.0f;                                 /*DEFAULT*/
        //snackHealthBoost_CooldownLength = 10.0f;                                 /*TESTING*/
        snackHealthBoost_Cooldown = 0;
        snackHealthBoost_Ready = false;                                          /*DEFAULT*/
        snackHealthBoost_ActiveLength = 7.5f;
        snackHealthBoost_ActiveTimer = snackHealthBoost_ActiveLength;
        snackHealthBoost_AddHealthTimerLength = .425f;
        snackHealthBoost_AddHealthTimer = snackHealthBoost_AddHealthTimerLength;
        snackHealthBoost_AddHealthAmount = 5;

        if(player1)             /*TEMPORARY*/
        {
            sSpeed.enabled = false;
            sDamage.enabled = false;
            sHealth.enabled = false;
            sBackBox.enabled = false;
            sMainBox.enabled = false;
            sReadyBox.enabled = false;
            sFrontBox.enabled = false;
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        if(levelLogicScript.gameIsPaused == false)
        {
            //if the player has the speed snack
            if (hasSnack_SpeedBoost == true)
            {
                //if the cooldown finishes, set green for ready
                if (snackSpeedBoost_Cooldown <= 0 && sReadyBox.enabled == false)
                {
                    sMainBox.fillAmount = 0;
                    sReadyBox.enabled = true;
                }
                //disable green ready circle
                if (snackSpeedBoost_Cooldown > 0 && sReadyBox.enabled == true)
                {
                    sReadyBox.enabled = false;
                }

                //setting the value of the circle fill
                sMainBox.fillAmount = snackSpeedBoost_Cooldown / 30;

                //enabling the images when acquiring
                if (hasSnack_SpeedBoost == true && sSpeed.enabled == false)
                {
                    sSpeed.enabled = true;
                    sBackBox.enabled = true;
                    sMainBox.enabled = true;
                    sFrontBox.enabled = true;
                }
            }

            //if the player has the Damage snack
            else if (hasSnack_DamageBoost == true)
            {
                //if the cooldown finishes, set green for ready
                if (snackDamageBoost_Cooldown <= 0 && sReadyBox.enabled == false)
                {
                    sMainBox.fillAmount = 0;
                    sReadyBox.enabled = true;
                }
                //disable green ready circle
                if (snackDamageBoost_Cooldown > 0 && sReadyBox.enabled == true)
                {
                    sReadyBox.enabled = false;
                }

                //setting the value of the circle fill
                sMainBox.fillAmount = snackDamageBoost_Cooldown / 30;

                //enabling the images when acquiring
                if (hasSnack_DamageBoost == true && sDamage.enabled == false)
                {
                    sDamage.enabled = true;
                    sBackBox.enabled = true;
                    sMainBox.enabled = true;
                    sFrontBox.enabled = true;
                }
            }

            //if the player has the Health snack
            else if (hasSnack_HealthBoost == true)
            {
                //if the cooldown finishes, set green for ready
                if (snackHealthBoost_Cooldown <= 0 && sReadyBox.enabled == false)
                {
                    sMainBox.fillAmount = 0;
                    sReadyBox.enabled = true;
                }
                //disable green ready circle
                if (snackHealthBoost_Cooldown > 0 && sReadyBox.enabled == true)
                {
                    sReadyBox.enabled = false;
                }

                //setting the value of the circle fill
                sMainBox.fillAmount = snackHealthBoost_Cooldown / 30;

                //enabling the images when acquiring
                if (hasSnack_HealthBoost == true && sHealth.enabled == false)
                {
                    sHealth.enabled = true;
                    sBackBox.enabled = true;
                    sMainBox.enabled = true;
                    sFrontBox.enabled = true;
                }
            }

            IEnumerator PlayHeal()
            {
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
                yield return new WaitForSeconds(.63f);
                AS_Heal.Play();
            }


            //When the player has the Snack - Speed Boost
            if (hasSnack_SpeedBoost == true)
            {
                //decrease the cooldown timer when it is bigger than 0
                if (snackSpeedBoost_Cooldown > 0)
                {
                    snackSpeedBoost_Cooldown -= Time.deltaTime;
                }

                //if the cooldown timer finishes, set the snack to ready
                if (snackSpeedBoost_Cooldown <= 0 && snackSpeedBoost_Ready == false)
                {
                    snackSpeedBoost_Ready = true;
                }

                //if the snack is ready and player presses X, activate speed boost (x2 speed)
                if (snackSpeedBoost_Ready == true && snack_SpeedBoost.enabled == false && Input.GetButtonDown(inputX))
                {
                    snack_SpeedBoost.enabled = true;
                    snack_SpeedBoost_ParticleSystem.SetActive(true);
                    playerStatusScript.moveSpeed = 16.0f;
                    SFX_drinkShake.Play();
                }

                //if the speed boost is active and the timer is bigger than 0, decreasse the timer
                if (snack_SpeedBoost.enabled == true && snackSpeedBoost_ActiveTimer > 0)
                {
                    snackSpeedBoost_ActiveTimer -= Time.deltaTime;
                }

                //disable Speed Boost
                if (snackSpeedBoost_ActiveTimer <= 0 && snack_SpeedBoost.enabled == true)
                {
                    snack_SpeedBoost.enabled = false;
                    snack_SpeedBoost_ParticleSystem.SetActive(false);
                    playerStatusScript.moveSpeed = playerStatusScript.moveSpeedDefault;
                    snackSpeedBoost_Ready = false;
                    snackSpeedBoost_ActiveTimer = snackSpeedBoost_ActiveLength;
                    snackSpeedBoost_Cooldown = snackSpeedBoost_CooldownLength;
                }
            }



            //When the player has the Snack - Damage Boost
            else if (hasSnack_DamageBoost == true)
            {
                //decrease the cooldown timer when it is bigger than 0
                if (snackDamageBoost_Cooldown > 0)
                {
                    snackDamageBoost_Cooldown -= Time.deltaTime;
                }

                //if the cooldown timer finishes, set the snack to ready
                if (snackDamageBoost_Cooldown <= 0 && snackDamageBoost_Ready == false)
                {
                    snackDamageBoost_Ready = true;
                }

                //if the snack is ready and player presses X, activate Damage boost
                if (snackDamageBoost_Ready == true && snack_DamageBoost.enabled == false && Input.GetButtonDown(inputX))
                {
                    snack_DamageBoost.enabled = true;
                    snack_DamageBoost_ParticleSystem.SetActive(true);
                    weaponManagerScript.damageBoostMultiplier = 2;
                    SFX_drinkShake.Play();
                }

                //if the Damage boost is active and the timer is bigger than 0, decreasse the timer
                if (snack_DamageBoost.enabled == true && snackDamageBoost_ActiveTimer > 0)
                {
                    snackDamageBoost_ActiveTimer -= Time.deltaTime;
                }

                //disable Damage Boost
                if (snackDamageBoost_ActiveTimer <= 0 && snack_DamageBoost.enabled == true)
                {
                    snack_DamageBoost.enabled = false;
                    snack_DamageBoost_ParticleSystem.SetActive(false);
                    weaponManagerScript.damageBoostMultiplier = 1;
                    snackDamageBoost_Ready = false;
                    snackDamageBoost_ActiveTimer = snackDamageBoost_ActiveLength;
                    snackDamageBoost_Cooldown = snackDamageBoost_CooldownLength;
                }
            }


            //When the player has the Snack - Health Boost
            else if (hasSnack_HealthBoost == true)
            {
                //decrease the cooldown timer when it is bigger than 0
                if (snackHealthBoost_Cooldown > 0)
                {
                    snackHealthBoost_Cooldown -= Time.deltaTime;
                }

                //if the cooldown timer finishes, set the snack to ready
                if (snackHealthBoost_Cooldown <= 0 && snackHealthBoost_Ready == false)
                {
                    snackHealthBoost_Ready = true;
                }

                //if the snack is ready and player presses X, activate Health boost
                if (snackHealthBoost_Ready == true && snack_HealthBoost.enabled == false && Input.GetButtonDown(inputX))
                {
                    snack_HealthBoost.enabled = true;
                    snack_HealthBoost_ParticleSystem.SetActive(true);
                    weaponManagerScript.damageBoostMultiplier = 2;
                    SFX_drinkShake.Play();
                    StartCoroutine(PlayHeal());
                }

                //if the Health boost is active and the timer is bigger than 0, decreasse the timer
                if (snack_HealthBoost.enabled == true && snackHealthBoost_ActiveTimer > 0)
                {
                    snackHealthBoost_ActiveTimer -= Time.deltaTime;
                    snackHealthBoost_AddHealthTimer -= Time.deltaTime;
                }

                if (snackHealthBoost_AddHealthTimer <= 0)
                {
                    playerStatusScript.HP += snackHealthBoost_AddHealthAmount;
                    snackHealthBoost_AddHealthTimer = snackHealthBoost_AddHealthTimerLength;
                }

                //disable Health Boost
                if (snackHealthBoost_ActiveTimer <= 0 && snack_HealthBoost.enabled == true)
                {
                    snack_HealthBoost.enabled = false;
                    snack_HealthBoost_ParticleSystem.SetActive(false);
                    weaponManagerScript.damageBoostMultiplier = 1;
                    snackHealthBoost_Ready = false;
                    snackHealthBoost_ActiveTimer = snackHealthBoost_ActiveLength;
                    snackHealthBoost_Cooldown = snackHealthBoost_CooldownLength;
                    snackHealthBoost_AddHealthTimer = snackHealthBoost_AddHealthTimerLength;
                }
            }
        }
        

    }
}
