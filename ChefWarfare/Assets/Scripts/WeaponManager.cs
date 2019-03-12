using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {

        //setting player number Inputs
        if(player1)
        {
            inputY = "Xbox_Button_Y_P1";
            inputRT = "Xbox_RT_P1";
        }
        else if(player2)
        {
            inputY = "Xbox_Button_Y_P2";
            inputRT = "Xbox_RT_P2";
        }
        else if (player3)
        {
            inputY = "Xbox_Button_Y_P3";
            inputRT = "Xbox_RT_P3";
        }
        else if (player4)
        {
            inputY = "Xbox_Button_Y_P4";
            inputRT = "Xbox_RT_P4";
        }

        //Setting Cooldown Lengths
        switchWeaponTimerCooldownLength = 1.0f;
        peaShooter_CooldownLength = 1.0f;
        semiAutoRifle_CooldownLength = 0.75f;    //600 dpm    
        burstRifle_CooldownLength = 1.25f;      //576 dpm
        shotgun_CooldownLength = 1.375f;
        spaghettiWhipCheese_CooldownLength = 1.0f;
        spaghettiWhipOnion_CooldownLength = 1.0f;

        //Pea Shooter
        hasWeapon_PeaShooter = true;            /*DEFAULT*/
        //hasWeapon_PeaShooter = false;           /*TESTING*/
        weapon_PeaShooter_Active = true;
        Weapon_PeaShooter.SetActive(true);      /*DEFAULT*/
        Debug.Log("Primary: PeaShooter");
        Debug.Log("Secondary: None");
        
        
        
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
            if (attackMain != 0 && peaShooter_Cooldown < 0)
            {
                peaShooter_Cooldown = peaShooter_CooldownLength;
                Instantiate(Prefab_Pea, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
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
            if (attackMain != 0 && semiAutoRifle_Cooldown < 0)
            {
                semiAutoRifle_Cooldown = semiAutoRifle_CooldownLength;
                Instantiate(Prefab_TomatoChunk, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
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
            if (attackMain != 0 && burstRifle_Cooldown < 0)
            {
                burstRifle_Cooldown = burstRifle_CooldownLength;
                Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint.transform.position.x, Weapon_BulletSpawnPoint.transform.position.y, Weapon_BulletSpawnPoint.transform.position.z), Weapon_PivotPoint.transform.rotation);
                Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint0.transform.position.x, Weapon_BulletSpawnPoint0.transform.position.y, Weapon_BulletSpawnPoint0.transform.position.z), Weapon_PivotPoint.transform.rotation);
                Instantiate(Prefab_TomatoSauce, new Vector3(Weapon_BulletSpawnPoint2.transform.position.x, Weapon_BulletSpawnPoint2.transform.position.y, Weapon_BulletSpawnPoint2.transform.position.z), Weapon_PivotPoint.transform.rotation);
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
            if (attackMain != 0 && shotgun_Cooldown < 0)
            {
                shotgun_Cooldown = shotgun_CooldownLength;
                Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun1.transform.position.x, Weapon_BulletSpawnPoint_Shotgun1.transform.position.y, Weapon_BulletSpawnPoint_Shotgun1.transform.position.z), Weapon_BulletSpawnPoint_Shotgun1.transform.rotation);
                Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun2.transform.position.x, Weapon_BulletSpawnPoint_Shotgun2.transform.position.y, Weapon_BulletSpawnPoint_Shotgun2.transform.position.z), Weapon_BulletSpawnPoint_Shotgun2.transform.rotation);
                Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun3.transform.position.x, Weapon_BulletSpawnPoint_Shotgun3.transform.position.y, Weapon_BulletSpawnPoint_Shotgun3.transform.position.z), Weapon_BulletSpawnPoint_Shotgun3.transform.rotation);
                Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun4.transform.position.x, Weapon_BulletSpawnPoint_Shotgun4.transform.position.y, Weapon_BulletSpawnPoint_Shotgun4.transform.position.z), Weapon_BulletSpawnPoint_Shotgun4.transform.rotation);
                Instantiate(Prefab_TomatoChunkShotgun, new Vector3(Weapon_BulletSpawnPoint_Shotgun5.transform.position.x, Weapon_BulletSpawnPoint_Shotgun5.transform.position.y, Weapon_BulletSpawnPoint_Shotgun5.transform.position.z), Weapon_BulletSpawnPoint_Shotgun5.transform.rotation);

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
            if (attackMain != 0 && spaghettiWhipCheese_Cooldown < 0)
            {
                spaghettiWhipCheese_Cooldown = spaghettiWhipCheese_CooldownLength;
                StartCoroutine(AttackSpaghettiWhipCheeseCoroutine());
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
            if (attackMain != 0 && spaghettiWhipOnion_Cooldown < 0)
            {
                spaghettiWhipOnion_Cooldown = spaghettiWhipOnion_CooldownLength;
                StartCoroutine(AttackSpaghettiWhipOnionCoroutine());
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

