using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //public variables
    //The PivotPoint
    public GameObject Weapon_PivotPoint;
    public GameObject Weapon_BulletSpawnPoint;
    public GameObject Weapon_BulletSpawnPoint0;
    public GameObject Weapon_BulletSpawnPoint2;

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

    // Start is called before the first frame update
    void Start()
    {
        //Setting Cooldown Lengths
        switchWeaponTimerCooldownLength = 1.0f;
        peaShooter_CooldownLength = 1.0f;
        semiAutoRifle_CooldownLength = 0.75f;    //600 dpm    
        burstRifle_CooldownLength = 1.25f;      //576 dpm

        //Pea Shooter
        hasWeapon_PeaShooter = true;
        weapon_PeaShooter_Active = true;
        Weapon_PeaShooter.SetActive(true);
        Debug.Log("Primary: PeaShooter");
        Debug.Log("Secondary: None");

        //Semi-Auto Rifle
        //hasWeapon_SemiAutoRifle = false;
        hasWeapon_SemiAutoRifle = true;       /*TESTING*/
        weapon_SemiAutoRifle_Active = false;

        //Burst Rifle
        hasWeapon_BurstRifle = false;
        //hasWeapon_BurstRifle = true;            /*TESTING*/
        weapon_BurstRifle_Active = false;
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

        /*//enabling Pea Shooter
        if(hasWeapon_PeaShooter == true && weapon_PeaShooter_Active == false)
        {
            //enabling gameobjects
            weapon_PeaShooter_Active = true;
            Weapon_PeaShooter.SetActive(true);
            Debug.Log("Enabled 'Weapon_PeaShooter'");
        }*/


        //using Pea Shooter
        if (hasWeapon_PeaShooter == true && weapon_PeaShooter_Active == true)
        {
            //Switch to secondary weapon and put this weapon in secondary slot
            if (Input.GetButtonDown("Xbox_Button_Y_P1") && canSwitchWeapon == true)
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
                //next weapon
                //next weapon

            }
            //when crafting a weapon, first check if has pea shooter, 
            //Removing Pea Shooter (Discarding/Destroying)
            /*if ()
            {

            }*/

            //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
            float attackMain = Input.GetAxis("Xbox_RT_P1");

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
            if (Input.GetButtonDown("Xbox_Button_Y_P1") && canSwitchWeapon == true)
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


            }

            //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
            float attackMain = Input.GetAxis("Xbox_RT_P1");

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
            if (Input.GetButtonDown("Xbox_Button_Y_P1") && canSwitchWeapon == true)
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


            }


            //value 0-1 of not pressed or pressed "Xbox_RT_P1" (RT)
            float attackMain = Input.GetAxis("Xbox_RT_P1");

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


    }
}

