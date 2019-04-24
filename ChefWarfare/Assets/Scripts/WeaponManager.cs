using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    //public variables

    //setting player number
    public bool player1;
    public bool player2;
    public bool player3;
    public bool player4;

    private string inputY;
    private string inputRT;

    //PlayerMovement Script
    public PlayerMovement playerMovementScript;
    public LevelLogic levelLogicScript;

    //The PivotPoint
    public GameObject Weapon_PivotPoint;
    public GameObject Weapon_BulletSpawnPoint;
    public GameObject Weapon_BulletSpawnPoint0;
    public GameObject Weapon_BulletSpawnPoint2;
    public GameObject Weapon_BulletSpawnPoint_Shotgun1;
    public GameObject Weapon_BulletSpawnPoint_Shotgun2;
    public GameObject Weapon_BulletSpawnPoint_Shotgun3;
    public GameObject Weapon_BulletSpawnPoint_Shotgun4;
    public GameObject Weapon_BulletSpawnPoint_Shotgun5;

    //Pea Shooter
    public GameObject Weapon_PeaShooter;
    public bool hasWeapon_PeaShooter;
    public bool weapon_PeaShooter_Active;
    //Pea
    public GameObject Prefab_Pea;

    //Burst Rifle
    public GameObject Weapon_BurstRifle;
    public bool hasWeapon_BurstRifle;
    public bool weapon_BurstRifle_Active;
    //Tomato Sauce
    public GameObject Prefab_TomatoSauce;

    //Semi-Auto Rifle
    public GameObject Weapon_SemiAutoRifle;
    public bool hasWeapon_SemiAutoRifle;
    public bool weapon_SemiAutoRifle_Active;
    //Tomato chunk
    public GameObject Prefab_TomatoChunk;

    //Shotgun
    public GameObject Weapon_Shotgun;
    public bool hasWeapon_Shotgun;
    public bool weapon_Shotgun_Active;
    //Tomato chunk Shotgun
    public GameObject Prefab_TomatoChunkShotgun;

    //Spaghetti Whip - Cheese
    public GameObject Weapon_SpaghettiWhipCheese_WindUp;
    public GameObject Weapon_SpaghettiWhipCheese_Attack;
    public SpriteRenderer Weapon_SpaghettiWhipCheese_SpriteRenderer;
    public BoxCollider2D Weapon_SpaghettiWhipCheese_Collider;
    public bool hasWeapon_SpaghettiWhipCheese;
    public bool weapon_SpaghettiWhipCheese_Active;

    //Spaghetti Whip - Onion
    public GameObject Weapon_SpaghettiWhipOnion_WindUp;
    public GameObject Weapon_SpaghettiWhipOnion_Attack;
    public SpriteRenderer Weapon_SpaghettiWhipOnion_SpriteRenderer;
    public BoxCollider2D Weapon_SpaghettiWhipOnion_Collider;
    public bool hasWeapon_SpaghettiWhipOnion;
    public bool weapon_SpaghettiWhipOnion_Active;

    //Damage Boost multiplier
    public int damageBoostMultiplier;


    //Audio
    public AudioSource SFX_shootPeaShooter;
    public AudioSource SFX_shootSemiAutoRifle;
    public AudioSource SFX_shootBurstRifle;
    public AudioSource SFX_shootShotgun;
    public AudioSource SFX_shootWhip;


    //private variables
    //Switch Weapon timer
    private bool canSwitchWeapon;
    private float switchWeaponCooldown;
    private float switchWeaponTimerCooldownLength;

    //Pea Shooter
    private float peaShooter_Cooldown;
    private float peaShooter_CooldownLength;

    //Semi-Auto Rifle
    private float semiAutoRifle_Cooldown;
    private float semiAutoRifle_CooldownLength;

    //Burst Rifle
    private float burstRifle_Cooldown;
    private float burstRifle_CooldownLength;

    //Shotgun
    private float shotgun_Cooldown;
    private float shotgun_CooldownLength;

    //Spaghetti Whip-Cheese
    private float spaghettiWhipCheese_Cooldown;
    private float spaghettiWhipCheese_CooldownLength;

    //Spaghetti Whip-Onion
    private float spaghettiWhipOnion_Cooldown;
    private float spaghettiWhipOnion_CooldownLength;

    //UI Inventory
    private Image w1PeaShooter;
    private Image w2PeaShooter;
    private Image w1SemiAutoRifle;
    private Image w2SemiAutoRifle;
    private Image w1BurstRifle;
    private Image w2BurstRifle;
    private Image w1Shotgun;
    private Image w2Shotgun;
    private Image w1WhipCheese;
    private Image w2WhipCheese;
    private Image w1WhipOnion;
    private Image w2WhipOnion;


    // Start is called before the first frame update
    void Start()
    {

        playerMovementScript = GetComponent<PlayerMovement>();

        if(playerMovementScript.isMac == false)
        {
            //setting player number Inputs and UI images
            if (player1)
            {
                inputY = "Xbox_Button_Y_P1";
                inputRT = "Xbox_RT_P1";

                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P1").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P1").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P1").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P1").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P1").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P1").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P1").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P1").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P1").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P1").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P1").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P1").GetComponent<Image>();

            }
            else if (player2)
            {
                inputY = "Xbox_Button_Y_P2";
                inputRT = "Xbox_RT_P2";

                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P2").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P2").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P2").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P2").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P2").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P2").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P2").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P2").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P2").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P2").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P2").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P2").GetComponent<Image>();
                
            }
            else if (player3)
            {
                inputY = "Xbox_Button_Y_P3";
                inputRT = "Xbox_RT_P3";
                
                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P3").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P3").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P3").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P3").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P3").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P3").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P3").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P3").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P3").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P3").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P3").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P3").GetComponent<Image>();
                
            }
            else if (player4)
            {
                inputY = "Xbox_Button_Y_P4";
                inputRT = "Xbox_RT_P4";
                
                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P4").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P4").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P4").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P4").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P4").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P4").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P4").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P4").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P4").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P4").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P4").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P4").GetComponent<Image>();
                
            }

        }

        else if (playerMovementScript.isMac == true)
        {
            //setting player number Inputs and UI images
            if (player1)
            {
                inputY = "Xbox_Button_Y_P1_MAC";
                inputRT = "Xbox_RT_P1_MAC";

                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P1").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P1").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P1").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P1").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P1").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P1").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P1").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P1").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P1").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P1").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P1").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P1").GetComponent<Image>();
            }
            else if (player2)
            {
                inputY = "Xbox_Button_Y_P2_MAC";
                inputRT = "Xbox_RT_P2_MAC";
                
                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P2").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P2").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P2").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P2").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P2").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P2").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P2").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P2").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P2").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P2").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P2").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P2").GetComponent<Image>();
                
            }
            else if (player3)
            {
                inputY = "Xbox_Button_Y_P3_MAC";
                inputRT = "Xbox_RT_P3_MAC";
                
                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P3").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P3").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P3").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P3").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P3").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P3").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P3").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P3").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P3").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P3").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P3").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P3").GetComponent<Image>();
                
            }
            else if (player4)
            {
                inputY = "Xbox_Button_Y_P4_MAC";
                inputRT = "Xbox_RT_P4_MAC";
                
                w1PeaShooter = GameObject.Find("UI_WeaponSlot1_PeaShooter_P4").GetComponent<Image>();
                w2PeaShooter = GameObject.Find("UI_WeaponSlot2_PeaShooter_P4").GetComponent<Image>();
                w1SemiAutoRifle = GameObject.Find("UI_WeaponSlot1_SemiAutoRifle_P4").GetComponent<Image>();
                w2SemiAutoRifle = GameObject.Find("UI_WeaponSlot2_SemiAutoRifle_P4").GetComponent<Image>();
                w1BurstRifle = GameObject.Find("UI_WeaponSlot1_BurstRifle_P4").GetComponent<Image>();
                w2BurstRifle = GameObject.Find("UI_WeaponSlot2_BurstRifle_P4").GetComponent<Image>();
                w1Shotgun = GameObject.Find("UI_WeaponSlot1_Shotgun_P4").GetComponent<Image>();
                w2Shotgun = GameObject.Find("UI_WeaponSlot2_Shotgun_P4").GetComponent<Image>();
                w1WhipCheese = GameObject.Find("UI_WeaponSlot1_WhipCheese_P4").GetComponent<Image>();
                w2WhipCheese = GameObject.Find("UI_WeaponSlot2_WhipCheese_P4").GetComponent<Image>();
                w1WhipOnion = GameObject.Find("UI_WeaponSlot1_WhipOnion_P4").GetComponent<Image>();
                w2WhipOnion = GameObject.Find("UI_WeaponSlot2_WhipOnion_P4").GetComponent<Image>();
                
            }

        }

        //UI on/off
        w1PeaShooter.enabled = true;
        w2PeaShooter.enabled = false;
        w1SemiAutoRifle.enabled = false;
        w2SemiAutoRifle.enabled = false;
        w1BurstRifle.enabled = false;
        w2BurstRifle.enabled = false;
        w1Shotgun.enabled = false;
        w2Shotgun.enabled = false;
        w1WhipCheese.enabled = false;
        w2WhipCheese.enabled = false;
        w1WhipOnion.enabled = false;
        w2WhipOnion.enabled = false;

        //Setting Cooldown Lengths
        switchWeaponTimerCooldownLength = 1.0f;
        peaShooter_CooldownLength = 0.75f;
        semiAutoRifle_CooldownLength = 0.4f;       
        burstRifle_CooldownLength = 0.7f;      
        shotgun_CooldownLength = 1.5f;
        spaghettiWhipCheese_CooldownLength = 1.0f;
        spaghettiWhipOnion_CooldownLength = 1.0f;

        //Pea Shooter
        hasWeapon_PeaShooter = true;            /*DEFAULT*/
        //hasWeapon_PeaShooter = false;           /*TESTING*/
        weapon_PeaShooter_Active = true;
        Weapon_PeaShooter.SetActive(true);      /*DEFAULT*/
        //Debug.Log("Primary: PeaShooter");
        //Debug.Log("Secondary: None");
        
        
        
        //Semi-Auto Rifle
        hasWeapon_SemiAutoRifle = false;        //DEFAULT
        //hasWeapon_SemiAutoRifle = true;         //TESTING
        weapon_SemiAutoRifle_Active = false;    //DEFAULT
        //weapon_SemiAutoRifle_Active = true;     //TESTING

        //Burst Rifle
        hasWeapon_BurstRifle = false;             //DEFAULT
        //hasWeapon_BurstRifle = true;            //TESTING
        weapon_BurstRifle_Active = false;

        //Shotgun
        hasWeapon_Shotgun = false;                //DEFAULT
        //hasWeapon_Shotgun = true;                   //TESTING
        weapon_Shotgun_Active = false;

        //Spaghetti Whip Cheese
        hasWeapon_SpaghettiWhipCheese = false;      //DEFAULT
        //hasWeapon_SpaghettiWhipCheese = true;       //TESTING
        weapon_SpaghettiWhipCheese_Active = false;

        //Spaghetti Whip Onion
        hasWeapon_SpaghettiWhipOnion = false;      //DEFAULT
        //hasWeapon_SpaghettiWhipOnion = true;       //TESTING
        weapon_SpaghettiWhipOnion_Active = false;

        //Damage Boost Multiplier
        damageBoostMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //NEEDED: So weapon switching works | Must wait 1 second to switch weapons again after switching weapons
        if (switchWeaponCooldown > 0f)
        {
            switchWeaponCooldown -= Time.deltaTime;
            canSwitchWeapon = false;
        }
        else
        {
            canSwitchWeapon = true;
        }




        //setting UI
        //Pea Shooter
        if (hasWeapon_PeaShooter == true && weapon_PeaShooter_Active == true && w1PeaShooter.enabled == false)
        {
            w1PeaShooter.enabled = true;
            w2PeaShooter.enabled = false;
        }
        else if (hasWeapon_PeaShooter == true && weapon_PeaShooter_Active == false && w2PeaShooter.enabled == false)
        {
            w2PeaShooter.enabled = true;
            w1PeaShooter.enabled = false;
        }
        else if (hasWeapon_PeaShooter == false && w1PeaShooter.enabled == false)
        {
            w1PeaShooter.enabled = false;
            w2PeaShooter.enabled = false;
        }
        else if (hasWeapon_PeaShooter == false && w2PeaShooter.enabled == false)
        {
            w1PeaShooter.enabled = false;
            w2PeaShooter.enabled = false;
        }

        //Semi Auto Rifle
        if (hasWeapon_SemiAutoRifle == true && weapon_SemiAutoRifle_Active == true && w1SemiAutoRifle.enabled == false)
        {
            w1SemiAutoRifle.enabled = true;
            w2SemiAutoRifle.enabled = false;
        }
        else if (hasWeapon_SemiAutoRifle == true && weapon_SemiAutoRifle_Active == false && w2SemiAutoRifle.enabled == false)
        {
            w2SemiAutoRifle.enabled = true;
            w1SemiAutoRifle.enabled = false;
        }
        else if (hasWeapon_SemiAutoRifle == false && w1SemiAutoRifle.enabled == false)
        {
            w1SemiAutoRifle.enabled = false;
            w2SemiAutoRifle.enabled = false;
        }
        else if (hasWeapon_SemiAutoRifle == false && w2SemiAutoRifle.enabled == false)
        {
            w1SemiAutoRifle.enabled = false;
            w2SemiAutoRifle.enabled = false;
        }

        //Burst Rifle
        if (hasWeapon_BurstRifle == true && weapon_BurstRifle_Active == true && w1BurstRifle.enabled == false)
        {
            w1BurstRifle.enabled = true;
            w2BurstRifle.enabled = false;
        }
        else if (hasWeapon_BurstRifle == true && weapon_BurstRifle_Active == false && w2BurstRifle.enabled == false)
        {
            w2BurstRifle.enabled = true;
            w1BurstRifle.enabled = false;
        }
        else if (hasWeapon_BurstRifle == false && w1BurstRifle.enabled == false)
        {
            w1BurstRifle.enabled = false;
            w2BurstRifle.enabled = false;
        }
        else if (hasWeapon_BurstRifle == false && w2BurstRifle.enabled == false)
        {
            w1BurstRifle.enabled = false;
            w2BurstRifle.enabled = false;
        }

        //Shotgun
        if (hasWeapon_Shotgun == true && weapon_Shotgun_Active == true && w1Shotgun.enabled == false)
        {
            w1Shotgun.enabled = true;
            w2Shotgun.enabled = false;
        }
        else if (hasWeapon_Shotgun == true && weapon_Shotgun_Active == false && w2Shotgun.enabled == false)
        {
            w2Shotgun.enabled = true;
            w1Shotgun.enabled = false;
        }
        else if (hasWeapon_Shotgun == false && w1Shotgun.enabled == false)
        {
            w1Shotgun.enabled = false;
            w2Shotgun.enabled = false;
        }
        else if (hasWeapon_Shotgun == false && w2Shotgun.enabled == false)
        {
            w1Shotgun.enabled = false;
            w2Shotgun.enabled = false;
        }

        //Whip Cheese
        if (hasWeapon_SpaghettiWhipCheese == true && weapon_SpaghettiWhipCheese_Active == true && w1WhipCheese.enabled == false)
        {
            w1WhipCheese.enabled = true;
            w2WhipCheese.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipCheese == true && weapon_SpaghettiWhipCheese_Active == false && w2WhipCheese.enabled == false)
        {
            w2WhipCheese.enabled = true;
            w1WhipCheese.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipCheese == false && w1WhipCheese.enabled == false)
        {
            w1WhipCheese.enabled = false;
            w2WhipCheese.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipCheese == false && w2WhipCheese.enabled == false)
        {
            w1WhipCheese.enabled = false;
            w2WhipCheese.enabled = false;
        }

        //Whip Onion
        if (hasWeapon_SpaghettiWhipOnion == true && weapon_SpaghettiWhipOnion_Active == true && w1WhipOnion.enabled == false)
        {
            w1WhipOnion.enabled = true;
            w2WhipOnion.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipOnion == true && weapon_SpaghettiWhipOnion_Active == false && w2WhipOnion.enabled == false)
        {
            w2WhipOnion.enabled = true;
            w1WhipOnion.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipOnion == false && w1WhipOnion.enabled == false)
        {
            w1WhipOnion.enabled = false;
            w2WhipOnion.enabled = false;
        }
        else if (hasWeapon_SpaghettiWhipOnion == false && w2WhipOnion.enabled == false)
        {
            w1WhipOnion.enabled = false;
            w2WhipOnion.enabled = false;
        }


        if(levelLogicScript.gameIsPaused == false)
        {
            //using Pea Shooter
            if (hasWeapon_PeaShooter == true && weapon_PeaShooter_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Semi-Auto Rifle
                    if (hasWeapon_SemiAutoRifle == true)
                    {
                        weapon_PeaShooter_Active = false;
                        Weapon_PeaShooter.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SemiAutoRifle_Active = true;
                        Weapon_SemiAutoRifle.SetActive(true);
                        semiAutoRifle_Cooldown = semiAutoRifle_CooldownLength;
                        Debug.Log("Primary: Semi-Auto Rifle");
                        Debug.Log("Secondary: PeaShooter");
                    }
                    else if (hasWeapon_BurstRifle == true)
                    {
                        weapon_PeaShooter_Active = false;
                        Weapon_PeaShooter.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_BurstRifle_Active = true;
                        Weapon_BurstRifle.SetActive(true);
                        burstRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Burst Rifle");
                        Debug.Log("Secondary: PeaShooter");
                    }
                    else if (hasWeapon_Shotgun == true)
                    {
                        weapon_PeaShooter_Active = false;
                        Weapon_PeaShooter.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_Shotgun_Active = true;
                        Weapon_Shotgun.SetActive(true);
                        shotgun_Cooldown = shotgun_CooldownLength;
                        Debug.Log("Primary: Shotgun");
                        Debug.Log("Secondary: PeaShooter");
                    }
                    else if (hasWeapon_SpaghettiWhipCheese == true)
                    {
                        weapon_PeaShooter_Active = false;
                        Weapon_PeaShooter.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipCheese_Active = true;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Cheese");
                        Debug.Log("Secondary: PeaShooter");
                    }
                    else if (hasWeapon_SpaghettiWhipOnion == true)
                    {
                        weapon_PeaShooter_Active = false;
                        Weapon_PeaShooter.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipOnion_Active = true;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Onion");
                        Debug.Log("Secondary: PeaShooter");
                    }
                    //next weapon
                    //next weapon

                }
                //when crafting a weapon, first check if has pea shooter, 
                //Removing Pea Shooter (Discarding/Destroying)
                /*if ()
                {

                }*/

                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                peaShooter_Cooldown -= Time.deltaTime;

                //if pressed, check if shot is ready and shoot.  Reset cooldown timer.
                if (attackMain > .5f && peaShooter_Cooldown < 0)
                {

                    peaShooter_Cooldown = peaShooter_CooldownLength;
                    GameObject bullet;
                    bullet = Instantiate(Prefab_Pea, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
                    SFX_shootPeaShooter.Play();

                    if(LevelLogic.mode == "FFA" || LevelLogic.mode == "1v1")
                    {
                        if (player1)
                        {
                            bullet.layer = 20/*Player1Bullets*/;
                        }
                        else if (player2)
                        {
                            bullet.layer = 21/*Player2Bullets*/;
                        }
                        else if (player3)
                        {
                            bullet.layer = 22/*Player3Bullets*/;
                        }
                        else if (player4)
                        {
                            bullet.layer = 23/*Player4Bullets*/;
                        }
                    }
                    else if(LevelLogic.mode == "2v2")
                    {
                        if (player1 || player3)
                        {
                            bullet.layer = 24;
                        }
                        else if (player2 || player4)
                        {
                            bullet.layer = 25;
                        }
                    }
                  



                }
            }

            //using Semi-Auto Rifle
            else if (hasWeapon_SemiAutoRifle == true && weapon_SemiAutoRifle_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Pea Shooter
                    if (hasWeapon_PeaShooter == true)
                    {
                        weapon_SemiAutoRifle_Active = false;
                        Weapon_SemiAutoRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_PeaShooter_Active = true;
                        Weapon_PeaShooter.SetActive(true);
                        peaShooter_Cooldown = peaShooter_CooldownLength;
                        Debug.Log("Primary: Pea Shooter");
                        Debug.Log("Secondary: Semi-Auto Rifle");
                    }
                    else if (hasWeapon_BurstRifle == true)
                    {
                        weapon_SemiAutoRifle_Active = false;
                        Weapon_SemiAutoRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_BurstRifle_Active = true;
                        Weapon_BurstRifle.SetActive(true);
                        burstRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Burst Rifle");
                        Debug.Log("Secondary: Semi-Auto Rifle");
                    }
                    else if (hasWeapon_Shotgun == true)
                    {
                        weapon_SemiAutoRifle_Active = false;
                        Weapon_SemiAutoRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_Shotgun_Active = true;
                        Weapon_Shotgun.SetActive(true);
                        shotgun_Cooldown = shotgun_CooldownLength;
                        Debug.Log("Primary: Shotgun");
                        Debug.Log("Secondary: Semi-Auto Rifle");
                    }
                    else if (hasWeapon_SpaghettiWhipCheese == true)
                    {
                        weapon_SemiAutoRifle_Active = false;
                        Weapon_SemiAutoRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipCheese_Active = true;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Cheese");
                        Debug.Log("Secondary: Semi-Auto Rifle");
                    }
                    else if (hasWeapon_SpaghettiWhipOnion == true)
                    {
                        weapon_SemiAutoRifle_Active = false;
                        Weapon_SemiAutoRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipOnion_Active = true;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Onion");
                        Debug.Log("Secondary: Semi-Auto Rifle");
                    }


                }

                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                semiAutoRifle_Cooldown -= Time.deltaTime;

                //if pressed, check if shot is ready and shoot.  Reset cooldown timer.
                if (attackMain > .5f && semiAutoRifle_Cooldown < 0)
                {
                    semiAutoRifle_Cooldown = semiAutoRifle_CooldownLength;
                    GameObject bullet;
                    bullet = Instantiate(Prefab_TomatoChunk, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
                    SFX_shootSemiAutoRifle.Play();


                    if (LevelLogic.mode == "FFA" || LevelLogic.mode == "1v1")
                    {
                        if (player1)
                        {
                            bullet.layer = 20/*Player1Bullets*/;
                        }
                        else if (player2)
                        {
                            bullet.layer = 21/*Player2Bullets*/;
                        }
                        else if (player3)
                        {
                            bullet.layer = 22/*Player3Bullets*/;
                        }
                        else if (player4)
                        {
                            bullet.layer = 23/*Player4Bullets*/;
                        }
                    }
                    else if (LevelLogic.mode == "2v2")
                    {
                        if (player1 || player3)
                        {
                            bullet.layer = 24;
                        }
                        else if (player2 || player4)
                        {
                            bullet.layer = 25;
                        }
                    }

                }

            }


            //using Burst Rifle
            else if (hasWeapon_BurstRifle == true && weapon_BurstRifle_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Pea Shooter
                    if (hasWeapon_PeaShooter == true)
                    {
                        weapon_BurstRifle_Active = false;
                        Weapon_BurstRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_PeaShooter_Active = true;
                        Weapon_PeaShooter.SetActive(true);
                        peaShooter_Cooldown = peaShooter_CooldownLength;
                        Debug.Log("Primary: Pea Shooter");
                        Debug.Log("Secondary: Burst Rifle");
                    }
                    else if (hasWeapon_SemiAutoRifle == true)
                    {
                        weapon_BurstRifle_Active = false;
                        Weapon_BurstRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SemiAutoRifle_Active = true;
                        Weapon_SemiAutoRifle.SetActive(true);
                        semiAutoRifle_Cooldown = semiAutoRifle_CooldownLength;
                        Debug.Log("Primary: Semi-Auto Rifle");
                        Debug.Log("Secondary: Burst Rifle");
                    }
                    else if (hasWeapon_Shotgun == true)
                    {
                        weapon_BurstRifle_Active = false;
                        Weapon_BurstRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_Shotgun_Active = true;
                        Weapon_Shotgun.SetActive(true);
                        shotgun_Cooldown = shotgun_CooldownLength;
                        Debug.Log("Primary: Shotgun");
                        Debug.Log("Secondary: Burst Rifle");
                    }
                    else if (hasWeapon_SpaghettiWhipCheese == true)
                    {
                        weapon_BurstRifle_Active = false;
                        Weapon_BurstRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipCheese_Active = true;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Cheese");
                        Debug.Log("Secondary: Burst Rifle");
                    }
                    else if (hasWeapon_SpaghettiWhipOnion == true)
                    {
                        weapon_BurstRifle_Active = false;
                        Weapon_BurstRifle.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipOnion_Active = true;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Onion");
                        Debug.Log("Secondary: Burst Rifle");
                    }


                }


                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                burstRifle_Cooldown -= Time.deltaTime;

                //if pressed, check if shot is ready and shoot.  Reset cooldown timer.
                if (attackMain > .5f && burstRifle_Cooldown < 0)
                {
                    burstRifle_Cooldown = burstRifle_CooldownLength;
                    GameObject bullet1;
                    GameObject bullet2;
                    GameObject bullet3;
                    bullet1 = Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
                    bullet2 = Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint0.transform.position.x, Weapon_BulletSpawnPoint0.transform.position.y, Weapon_BulletSpawnPoint0.transform.position.z), Weapon_PivotPoint.transform.rotation);
                    bullet3 = Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint2.transform.position.x, Weapon_BulletSpawnPoint2.transform.position.y, Weapon_BulletSpawnPoint2.transform.position.z), Weapon_PivotPoint.transform.rotation);
                    SFX_shootBurstRifle.Play();

                    if(LevelLogic.mode == "FFA" || LevelLogic.mode == "1v1")
                    {
                        if (player1)
                        {
                            bullet1.layer = 20/*Player1Bullets*/;
                            bullet2.layer = 20/*Player1Bullets*/;
                            bullet3.layer = 20/*Player1Bullets*/;
                        }
                        else if (player2)
                        {
                            bullet1.layer = 21/*Player2Bullets*/;
                            bullet2.layer = 21/*Player2Bullets*/;
                            bullet3.layer = 21/*Player2Bullets*/;
                        }
                        else if (player3)
                        {
                            bullet1.layer = 22/*Player3Bullets*/;
                            bullet2.layer = 22/*Player3Bullets*/;
                            bullet3.layer = 22/*Player3Bullets*/;
                        }
                        else if (player4)
                        {
                            bullet1.layer = 23/*Player4Bullets*/;
                            bullet2.layer = 23/*Player4Bullets*/;
                            bullet3.layer = 23/*Player4Bullets*/;
                        }
                    }
                    else if(LevelLogic.mode == "2v2")
                    {
                        if (player1 || player3)
                        {
                            bullet1.layer = 24;
                            bullet2.layer = 24;
                            bullet3.layer = 24;
                        }
                        else if (player2 || player4)
                        {
                            bullet1.layer = 25;
                            bullet2.layer = 25;
                            bullet3.layer = 25;
                        }
                    }
                   

                }

            }



            //using Shotgun
            else if (hasWeapon_Shotgun == true && weapon_Shotgun_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Pea Shooter
                    if (hasWeapon_PeaShooter == true)
                    {
                        weapon_Shotgun_Active = false;
                        Weapon_Shotgun.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_PeaShooter_Active = true;
                        Weapon_PeaShooter.SetActive(true);
                        peaShooter_Cooldown = peaShooter_CooldownLength;
                        Debug.Log("Primary: Pea Shooter");
                        Debug.Log("Secondary: Shotgun");
                    }
                    else if (hasWeapon_SemiAutoRifle == true)
                    {
                        weapon_Shotgun_Active = false;
                        Weapon_Shotgun.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SemiAutoRifle_Active = true;
                        Weapon_SemiAutoRifle.SetActive(true);
                        semiAutoRifle_Cooldown = semiAutoRifle_CooldownLength;
                        Debug.Log("Primary: Semi-Auto Rifle");
                        Debug.Log("Secondary: Shotgun");
                    }
                    else if (hasWeapon_BurstRifle == true)
                    {
                        weapon_Shotgun_Active = false;
                        Weapon_Shotgun.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_BurstRifle_Active = true;
                        Weapon_BurstRifle.SetActive(true);
                        burstRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Burst Rifle");
                        Debug.Log("Secondary: Shotgun");
                    }
                    else if (hasWeapon_SpaghettiWhipCheese == true)
                    {
                        weapon_Shotgun_Active = false;
                        Weapon_Shotgun.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipCheese_Active = true;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Cheese");
                        Debug.Log("Secondary: Shotgun");
                    }
                    else if (hasWeapon_SpaghettiWhipOnion == true)
                    {
                        weapon_Shotgun_Active = false;
                        Weapon_Shotgun.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipOnion_Active = true;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Onion");
                        Debug.Log("Secondary: Shotgun");
                    }



                }

                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                shotgun_Cooldown -= Time.deltaTime;

                //if pressed, check if shot is ready and shoot.  Reset cooldown timer.
                if (attackMain > .5f && shotgun_Cooldown < 0)
                {
                    shotgun_Cooldown = shotgun_CooldownLength;
                    GameObject bullet1;
                    GameObject bullet2;
                    GameObject bullet3;
                    GameObject bullet4;
                    GameObject bullet5;
                    bullet1 = Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun1.transform.position.x, Weapon_BulletSpawnPoint_Shotgun1.transform.position.y, Weapon_BulletSpawnPoint_Shotgun1.transform.position.z), Weapon_BulletSpawnPoint_Shotgun1.transform.rotation);
                    bullet2 = Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun2.transform.position.x, Weapon_BulletSpawnPoint_Shotgun2.transform.position.y, Weapon_BulletSpawnPoint_Shotgun2.transform.position.z), Weapon_BulletSpawnPoint_Shotgun2.transform.rotation);
                    bullet3 = Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun3.transform.position.x, Weapon_BulletSpawnPoint_Shotgun3.transform.position.y, Weapon_BulletSpawnPoint_Shotgun3.transform.position.z), Weapon_BulletSpawnPoint_Shotgun3.transform.rotation);
                    bullet4 = Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun4.transform.position.x, Weapon_BulletSpawnPoint_Shotgun4.transform.position.y, Weapon_BulletSpawnPoint_Shotgun4.transform.position.z), Weapon_BulletSpawnPoint_Shotgun4.transform.rotation);
                    bullet5 = Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun5.transform.position.x, Weapon_BulletSpawnPoint_Shotgun5.transform.position.y, Weapon_BulletSpawnPoint_Shotgun5.transform.position.z), Weapon_BulletSpawnPoint_Shotgun5.transform.rotation);
                    SFX_shootShotgun.Play();

                    if(LevelLogic.mode == "FFA")
                    {
                        if (player1)
                        {
                            bullet1.layer = 20/*Player1Bullets*/;
                            bullet2.layer = 20/*Player1Bullets*/;
                            bullet3.layer = 20/*Player1Bullets*/;
                            bullet4.layer = 20/*Player1Bullets*/;
                            bullet5.layer = 20/*Player1Bullets*/;
                        }
                        else if (player2)
                        {
                            bullet1.layer = 21/*Player2Bullets*/;
                            bullet2.layer = 21/*Player2Bullets*/;
                            bullet3.layer = 21/*Player2Bullets*/;
                            bullet4.layer = 21/*Player2Bullets*/;
                            bullet5.layer = 21/*Player2Bullets*/;
                        }
                        else if (player3)
                        {
                            bullet1.layer = 22/*Player3Bullets*/;
                            bullet2.layer = 22/*Player3Bullets*/;
                            bullet3.layer = 22/*Player3Bullets*/;
                            bullet4.layer = 22/*Player3Bullets*/;
                            bullet5.layer = 22/*Player3Bullets*/;
                        }
                        else if (player4)
                        {
                            bullet1.layer = 23/*Player4Bullets*/;
                            bullet2.layer = 23/*Player4Bullets*/;
                            bullet3.layer = 23/*Player4Bullets*/;
                            bullet4.layer = 23/*Player4Bullets*/;
                            bullet5.layer = 23/*Player4Bullets*/;
                        }
                    }

                    else if(LevelLogic.mode == "2v2")
                    {
                        if (player1 || player3)
                        {
                            bullet1.layer = 24;
                            bullet2.layer = 24;
                            bullet3.layer = 24;
                            bullet4.layer = 24;
                            bullet5.layer = 24;
                        }
                        if (player2 || player4)
                        {
                            bullet1.layer = 25;
                            bullet2.layer = 25;
                            bullet3.layer = 25;
                            bullet4.layer = 25;
                            bullet5.layer = 25;
                        }
                    }
                   

                }

            }



            //using Spaghetti Whip-Cheese
            else if (hasWeapon_SpaghettiWhipCheese == true && weapon_SpaghettiWhipCheese_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Pea Shooter
                    if (hasWeapon_PeaShooter == true)
                    {
                        weapon_SpaghettiWhipCheese_Active = false;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_PeaShooter_Active = true;
                        Weapon_PeaShooter.SetActive(true);
                        peaShooter_Cooldown = peaShooter_CooldownLength;
                        Debug.Log("Primary: Pea Shooter");
                        Debug.Log("Secondary: Spaghetti Whip Cheese");
                    }
                    else if (hasWeapon_SemiAutoRifle == true)
                    {
                        weapon_SpaghettiWhipCheese_Active = false;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SemiAutoRifle_Active = true;
                        Weapon_SemiAutoRifle.SetActive(true);
                        semiAutoRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Semi-Auto Rifle");
                        Debug.Log("Secondary: Spaghetti Whip Cheese");
                    }
                    else if (hasWeapon_BurstRifle == true)
                    {
                        weapon_SpaghettiWhipCheese_Active = false;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_BurstRifle_Active = true;
                        Weapon_BurstRifle.SetActive(true);
                        burstRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Burst Rifle");
                        Debug.Log("Secondary: Spaghetti Whip Cheese");
                    }
                    else if (hasWeapon_Shotgun == true)
                    {
                        weapon_SpaghettiWhipCheese_Active = false;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_Shotgun_Active = true;
                        Weapon_Shotgun.SetActive(true);
                        shotgun_Cooldown = shotgun_CooldownLength;
                        Debug.Log("Primary: Shotgun");
                        Debug.Log("Secondary: Spaghetti Whip Cheese");
                    }
                    else if (hasWeapon_SpaghettiWhipOnion == true)
                    {
                        weapon_SpaghettiWhipCheese_Active = false;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipOnion_Active = true;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Onion");
                        Debug.Log("Secondary: Spaghetti Whip Cheese");
                    }

                }

                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                spaghettiWhipCheese_Cooldown -= Time.deltaTime;

                //if pressed, check if attack is ready and attack.  Reset cooldown timer.
                if (attackMain > .5f && spaghettiWhipCheese_Cooldown < 0)
                {
                    spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                    StartCoroutine(AttackSpaghettiWhipCheeseCoroutine());
                    SFX_shootWhip.Play();
                }

            }



            //using Spaghetti Whip-Onion
            else if (hasWeapon_SpaghettiWhipOnion == true && weapon_SpaghettiWhipOnion_Active == true)
            {
                //Switch to secondary weapon and put this weapon in secondary slot
                if (Input.GetButtonDown(inputY) && canSwitchWeapon == true)
                {
                    //sets cooldown to switch weapons again
                    switchWeaponCooldown = switchWeaponTimerCooldownLength;

                    //switch to Pea Shooter
                    if (hasWeapon_PeaShooter == true)
                    {
                        weapon_SpaghettiWhipOnion_Active = false;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_PeaShooter_Active = true;
                        Weapon_PeaShooter.SetActive(true);
                        peaShooter_Cooldown = peaShooter_CooldownLength;
                        Debug.Log("Primary: Pea Shooter");
                        Debug.Log("Secondary: Spaghetti Whip Onion");
                    }
                    else if (hasWeapon_SemiAutoRifle == true)
                    {
                        weapon_SpaghettiWhipOnion_Active = false;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SemiAutoRifle_Active = true;
                        Weapon_SemiAutoRifle.SetActive(true);
                        semiAutoRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Semi-Auto Rifle");
                        Debug.Log("Secondary: Spaghetti Whip Onion");
                    }
                    else if (hasWeapon_BurstRifle == true)
                    {
                        weapon_SpaghettiWhipOnion_Active = false;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_BurstRifle_Active = true;
                        Weapon_BurstRifle.SetActive(true);
                        burstRifle_Cooldown = burstRifle_CooldownLength;
                        Debug.Log("Primary: Burst Rifle");
                        Debug.Log("Secondary: Spaghetti Whip Onion");
                    }
                    else if (hasWeapon_Shotgun == true)
                    {
                        weapon_SpaghettiWhipOnion_Active = false;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_Shotgun_Active = true;
                        Weapon_Shotgun.SetActive(true);
                        shotgun_Cooldown = shotgun_CooldownLength;
                        Debug.Log("Primary: Shotgun");
                        Debug.Log("Secondary: Spaghetti Whip Onion");
                    }
                    else if (hasWeapon_SpaghettiWhipCheese == true)
                    {
                        weapon_SpaghettiWhipOnion_Active = false;
                        Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
                        Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                        //TO DO: enable weapon sprite renderer in box secondary weapon
                        weapon_SpaghettiWhipCheese_Active = true;
                        Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                        Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
                        spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                        Debug.Log("Primary: Spaghetti Whip Cheese");
                        Debug.Log("Secondary: Spaghetti Whip Onion");
                    }

                }

                //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
                float attackMain = Input.GetAxis(inputRT);

                //cooldown/reload timer in between shots
                spaghettiWhipOnion_Cooldown -= Time.deltaTime;

                //if pressed, check if attack is ready and attack.  Reset cooldown timer.
                if (attackMain > .5f && spaghettiWhipOnion_Cooldown < 0)
                {
                    spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                    StartCoroutine(AttackSpaghettiWhipOnionCoroutine());
                    SFX_shootWhip.Play();
                }

            }

        }
        
            

        


    }

    //coroutine to attack with SpaghettiWhipCheese
    IEnumerator AttackSpaghettiWhipCheeseCoroutine()
    {
        Weapon_SpaghettiWhipCheese_Collider.enabled = true;
        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        Weapon_SpaghettiWhipCheese_Collider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
    }

    //coroutine to attack with SpaghettiWhipOnion
    IEnumerator AttackSpaghettiWhipOnionCoroutine()
    {
        Weapon_SpaghettiWhipOnion_Collider.enabled = true;
        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.025f);
        Weapon_SpaghettiWhipOnion_Collider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
    }

}

