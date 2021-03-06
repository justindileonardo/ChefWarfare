﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{

    public GameObject[] checkmark1, checkmark2, checkmark3, checkmark4;

    private WeaponManager weaponManagerScript_P1;
    private WeaponManager weaponManagerScript_P2;
    private WeaponManager weaponManagerScript_P3;
    private WeaponManager weaponManagerScript_P4;

    private SpecialManager specialManagerScript_P1;
    private SpecialManager specialManagerScript_P2;
    private SpecialManager specialManagerScript_P3;
    private SpecialManager specialManagerScript_P4;

    private PlayerInventory playerInventoryScript_P1;
    private PlayerInventory playerInventoryScript_P2;
    private PlayerInventory playerInventoryScript_P3;
    private PlayerInventory playerInventoryScript_P4;

    [HideInInspector] public int SR_bread;
    [HideInInspector] public int SR_tomato;

    [HideInInspector] public int BR_bread;
    [HideInInspector] public int BR_tomato;

    [HideInInspector] public int SG_bread;
    [HideInInspector] public int SG_tomato;

    [HideInInspector] public int WC_spaghetti;
    [HideInInspector] public int WC_cheese;

    [HideInInspector] public int WO_spaghetti;
    [HideInInspector] public int WO_onion;

    [HideInInspector] public int SS_tomato;
    [HideInInspector] public int SS_cheese;
    [HideInInspector] public int SS_onion;

    [HideInInspector] public int SD_tomato;
    [HideInInspector] public int SD_cheese;
    [HideInInspector] public int SD_onion;

    [HideInInspector] public int SH_tomato;
    [HideInInspector] public int SH_cheese;
    [HideInInspector] public int SH_onion;

    public AudioSource SFX_cookItemSuccess;


    private bool canCookSemiAutoRifle_P1;
    private bool canCookSemiAutoRifle_P2;
    private bool canCookSemiAutoRifle_P3;
    private bool canCookSemiAutoRifle_P4;

    private bool canCookBurstRifle_P1;
    private bool canCookBurstRifle_P2;
    private bool canCookBurstRifle_P3;
    private bool canCookBurstRifle_P4;

    private bool canCookShotgun_P1;
    private bool canCookShotgun_P2;
    private bool canCookShotgun_P3;
    private bool canCookShotgun_P4;

    private bool canCookWhipCheese_P1;
    private bool canCookWhipCheese_P2;
    private bool canCookWhipCheese_P3;
    private bool canCookWhipCheese_P4;

    private bool canCookWhipOnion_P1;
    private bool canCookWhipOnion_P2;
    private bool canCookWhipOnion_P3;
    private bool canCookWhipOnion_P4;

    private bool canCookSnackSpeed_P1;
    private bool canCookSnackSpeed_P2;
    private bool canCookSnackSpeed_P3;
    private bool canCookSnackSpeed_P4;

    private bool canCookSnackDamage_P1;
    private bool canCookSnackDamage_P2;
    private bool canCookSnackDamage_P3;
    private bool canCookSnackDamage_P4;

    private bool canCookSnackHealth_P1;
    private bool canCookSnackHealth_P2;
    private bool canCookSnackHealth_P3;
    private bool canCookSnackHealth_P4;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            checkmark1[i].SetActive(false);
            checkmark2[i].SetActive(false);
            checkmark3[i].SetActive(false);
            checkmark4[i].SetActive(false);
        }

        weaponManagerScript_P1 = GameObject.Find("Player1").GetComponent<WeaponManager>();
        weaponManagerScript_P2 = GameObject.Find("Player2").GetComponent<WeaponManager>();
        weaponManagerScript_P3 = GameObject.Find("Player3").GetComponent<WeaponManager>();
        weaponManagerScript_P4 = GameObject.Find("Player4").GetComponent<WeaponManager>();

        specialManagerScript_P1 = GameObject.Find("Player1").GetComponent<SpecialManager>();
        specialManagerScript_P2 = GameObject.Find("Player2").GetComponent<SpecialManager>();
        specialManagerScript_P3 = GameObject.Find("Player3").GetComponent<SpecialManager>();
        specialManagerScript_P4 = GameObject.Find("Player4").GetComponent<SpecialManager>();

        playerInventoryScript_P1 = GameObject.Find("Player1").GetComponent<PlayerInventory>();
        playerInventoryScript_P2 = GameObject.Find("Player2").GetComponent<PlayerInventory>();
        playerInventoryScript_P3 = GameObject.Find("Player3").GetComponent<PlayerInventory>();
        playerInventoryScript_P4 = GameObject.Find("Player4").GetComponent<PlayerInventory>();

        //amounts needed for recipes
        //Semi-Auto Rifle
        SR_bread = 9;
        SR_tomato = 6;

        //Burst Rifle
        BR_bread = 8;
        BR_tomato = 7;

        //Shotgun
        SG_bread = 6;
        SG_tomato = 9;

        //Whip Cheese
        WC_spaghetti = 9;
        WC_cheese = 6;

        //Whip Onion
        WO_spaghetti = 9;
        WO_onion = 6;

        //Snack Speed
        SS_tomato = 4;
        SS_cheese = 7;
        SS_onion = 4;

        //Snack Damage
        SD_tomato = 7;
        SD_cheese = 4;
        SD_onion = 4;

        //Snack Health
        SH_tomato = 4;
        SH_cheese = 4;
        SH_onion = 7;


        canCookSemiAutoRifle_P1 = false;
        canCookSemiAutoRifle_P2 = false;
        canCookSemiAutoRifle_P3 = false;
        canCookSemiAutoRifle_P4 = false;

        canCookBurstRifle_P1 = false;
        canCookBurstRifle_P2 = false;
        canCookBurstRifle_P3 = false;
        canCookBurstRifle_P4 = false;

        canCookShotgun_P1 = false;
        canCookShotgun_P2 = false;
        canCookShotgun_P3 = false;
        canCookShotgun_P4 = false;

        canCookWhipCheese_P1 = false;
        canCookWhipCheese_P2 = false;
        canCookWhipCheese_P3 = false;
        canCookWhipCheese_P4 = false;

        canCookWhipOnion_P1 = false;
        canCookWhipOnion_P2 = false;
        canCookWhipOnion_P3 = false;
        canCookWhipOnion_P4 = false;

        canCookSnackSpeed_P1 = false;
        canCookSnackSpeed_P2 = false;
        canCookSnackSpeed_P3 = false;
        canCookSnackSpeed_P4 = false;

        canCookSnackDamage_P1 = false;
        canCookSnackDamage_P2 = false;
        canCookSnackDamage_P3 = false;
        canCookSnackDamage_P4 = false;

        canCookSnackHealth_P1 = false;
        canCookSnackHealth_P2 = false;
        canCookSnackHealth_P3 = false;
        canCookSnackHealth_P4 = false;





    }

    // Update is called once per frame
    void Update()
    {

        ResourceNeedsToCraft();

    }

    //function for all the players and the resources they need to craft an item
    public void ResourceNeedsToCraft()
    {
        //crafting resource needs

        //Semi-Auto Rifle
        if (playerInventoryScript_P1.breadCount >= SR_bread && playerInventoryScript_P1.tomatoCount >= SR_tomato)
        {
            canCookSemiAutoRifle_P1 = true;
        }
        else
        {
            canCookSemiAutoRifle_P1 = false;
        }
        if (playerInventoryScript_P2.breadCount >= SR_bread && playerInventoryScript_P2.tomatoCount >= SR_tomato)
        {
            canCookSemiAutoRifle_P2 = true;
        }
        else
        {
            canCookSemiAutoRifle_P2 = false;
        }
        if (playerInventoryScript_P3.breadCount >= SR_bread && playerInventoryScript_P3.tomatoCount >= SR_tomato)
        {
            canCookSemiAutoRifle_P3 = true;
        }
        else
        {
            canCookSemiAutoRifle_P3 = false;
        }
        if (playerInventoryScript_P4.breadCount >= SR_bread && playerInventoryScript_P4.tomatoCount >= SR_tomato)
        {
            canCookSemiAutoRifle_P4 = true;
        }
        else
        {
            canCookSemiAutoRifle_P4 = false;
        }

        //Burst Rifle
        if (playerInventoryScript_P1.breadCount >= BR_bread && playerInventoryScript_P1.tomatoCount >= BR_tomato)
        {
            canCookBurstRifle_P1 = true;
        }
        else
        {
            canCookBurstRifle_P1 = false;
        }
        if (playerInventoryScript_P2.breadCount >= BR_bread && playerInventoryScript_P2.tomatoCount >= BR_tomato)
        {
            canCookBurstRifle_P2 = true;
        }
        else
        {
            canCookBurstRifle_P2 = false;
        }
        if (playerInventoryScript_P3.breadCount >= BR_bread && playerInventoryScript_P3.tomatoCount >= BR_tomato)
        {
            canCookBurstRifle_P3 = true;
        }
        else
        {
            canCookBurstRifle_P3 = false;
        }
        if (playerInventoryScript_P4.breadCount >= BR_bread && playerInventoryScript_P4.tomatoCount >= BR_tomato)
        {
            canCookBurstRifle_P4 = true;
        }
        else
        {
            canCookBurstRifle_P4 = false;
        }

        //Shotgun
        if (playerInventoryScript_P1.breadCount >= SG_bread && playerInventoryScript_P1.tomatoCount >= SG_tomato)
        {
            canCookShotgun_P1 = true;
        }
        else
        {
            canCookShotgun_P1 = false;
        }
        if (playerInventoryScript_P2.breadCount >= SG_bread && playerInventoryScript_P2.tomatoCount >= SG_tomato)
        {
            canCookShotgun_P2 = true;
        }
        else
        {
            canCookShotgun_P2 = false;
        }
        if (playerInventoryScript_P3.breadCount >= SG_bread && playerInventoryScript_P3.tomatoCount >= SG_tomato)
        {
            canCookShotgun_P3 = true;
        }
        else
        {
            canCookShotgun_P3 = false;
        }
        if (playerInventoryScript_P4.breadCount >= SG_bread && playerInventoryScript_P4.tomatoCount >= SG_tomato)
        {
            canCookShotgun_P4 = true;
        }
        else
        {
            canCookShotgun_P4 = false;
        }

        //Whip Cheese
        if (playerInventoryScript_P1.spaghettiCount >= WC_spaghetti && playerInventoryScript_P1.cheeseCount >= WC_cheese)
        {
            canCookWhipCheese_P1 = true;
        }
        else
        {
            canCookWhipCheese_P1 = false;
        }
        if (playerInventoryScript_P2.spaghettiCount >= WC_spaghetti && playerInventoryScript_P2.cheeseCount >= WC_cheese)
        {
            canCookWhipCheese_P2 = true;
        }
        else
        {
            canCookWhipCheese_P2 = false;
        }
        if (playerInventoryScript_P3.spaghettiCount >= WC_spaghetti && playerInventoryScript_P3.cheeseCount >= WC_cheese)
        {
            canCookWhipCheese_P3 = true;
        }
        else
        {
            canCookWhipCheese_P3 = false;
        }
        if (playerInventoryScript_P4.spaghettiCount >= WC_spaghetti && playerInventoryScript_P4.cheeseCount >= WC_cheese)
        {
            canCookWhipCheese_P4 = true;
        }
        else
        {
            canCookWhipCheese_P4 = false;
        }

        //Whip Onion
        if (playerInventoryScript_P1.spaghettiCount >= WO_spaghetti && playerInventoryScript_P1.onionCount >= WO_onion)
        {
            canCookWhipOnion_P1 = true;
        }
        else
        {
            canCookWhipOnion_P1 = false;
        }
        if (playerInventoryScript_P2.spaghettiCount >= WO_spaghetti && playerInventoryScript_P2.onionCount >= WO_onion)
        {
            canCookWhipOnion_P2 = true;
        }
        else
        {
            canCookWhipOnion_P2 = false;
        }
        if (playerInventoryScript_P3.spaghettiCount >= WO_spaghetti && playerInventoryScript_P3.onionCount >= WO_onion)
        {
            canCookWhipOnion_P3 = true;
        }
        else
        {
            canCookWhipOnion_P3 = false;
        }
        if (playerInventoryScript_P4.spaghettiCount >= WO_spaghetti && playerInventoryScript_P4.onionCount >= WO_onion)
        {
            canCookWhipOnion_P4 = true;
        }
        else
        {
            canCookWhipOnion_P4 = false;
        }


        //Snack Speed
        if (playerInventoryScript_P1.tomatoCount >= SS_tomato && playerInventoryScript_P1.cheeseCount >= SS_cheese && playerInventoryScript_P1.onionCount >= SS_onion)
        {
            canCookSnackSpeed_P1 = true;
        }
        else
        {
            canCookSnackSpeed_P1 = false;
        }
        if (playerInventoryScript_P2.tomatoCount >= SS_tomato && playerInventoryScript_P2.cheeseCount >= SS_cheese && playerInventoryScript_P2.onionCount >= SS_onion)
        {
            canCookSnackSpeed_P2 = true;
        }
        else
        {
            canCookSnackSpeed_P2 = false;
        }
        if (playerInventoryScript_P3.tomatoCount >= SS_tomato && playerInventoryScript_P3.cheeseCount >= SS_cheese && playerInventoryScript_P3.onionCount >= SS_onion)
        {
            canCookSnackSpeed_P3 = true;
        }
        else
        {
            canCookSnackSpeed_P3 = false;
        }
        if (playerInventoryScript_P4.tomatoCount >= SS_tomato && playerInventoryScript_P4.cheeseCount >= SS_cheese && playerInventoryScript_P4.onionCount >= SS_onion)
        {
            canCookSnackSpeed_P4 = true;
        }
        else
        {
            canCookSnackSpeed_P4 = false;
        }

        //Snack Damage
        if (playerInventoryScript_P1.tomatoCount >= SD_tomato && playerInventoryScript_P1.cheeseCount >= SD_cheese && playerInventoryScript_P1.onionCount >= SD_onion)
        {
            canCookSnackDamage_P1 = true;
        }
        else
        {
            canCookSnackDamage_P1 = false;
        }
        if (playerInventoryScript_P2.tomatoCount >= SD_tomato && playerInventoryScript_P2.cheeseCount >= SD_cheese && playerInventoryScript_P2.onionCount >= SD_onion)
        {
            canCookSnackDamage_P2 = true;
        }
        else
        {
            canCookSnackDamage_P2 = false;
        }
        if (playerInventoryScript_P3.tomatoCount >= SD_tomato && playerInventoryScript_P3.cheeseCount >= SD_cheese && playerInventoryScript_P3.onionCount >= SD_onion)
        {
            canCookSnackDamage_P3 = true;
        }
        else
        {
            canCookSnackDamage_P3 = false;
        }
        if (playerInventoryScript_P4.tomatoCount >= SD_tomato && playerInventoryScript_P4.cheeseCount >= SD_cheese && playerInventoryScript_P4.onionCount >= SD_onion)
        {
            canCookSnackDamage_P4 = true;
        }
        else
        {
            canCookSnackDamage_P4 = false;
        }

        //Snack Health
        if (playerInventoryScript_P1.tomatoCount >= SH_tomato && playerInventoryScript_P1.cheeseCount >= SH_cheese && playerInventoryScript_P1.onionCount >= SH_onion)
        {
            canCookSnackHealth_P1 = true;
        }
        else
        {
            canCookSnackHealth_P1 = false;
        }
        if (playerInventoryScript_P2.tomatoCount >= SH_tomato && playerInventoryScript_P2.cheeseCount >= SH_cheese && playerInventoryScript_P2.onionCount >= SH_onion)
        {
            canCookSnackHealth_P2 = true;
        }
        else
        {
            canCookSnackHealth_P2 = false;
        }
        if (playerInventoryScript_P3.tomatoCount >= SH_tomato && playerInventoryScript_P3.cheeseCount >= SH_cheese && playerInventoryScript_P3.onionCount >= SH_onion)
        {
            canCookSnackHealth_P3 = true;
        }
        else
        {
            canCookSnackHealth_P3 = false;
        }
        if (playerInventoryScript_P4.tomatoCount >= SH_tomato && playerInventoryScript_P4.cheeseCount >= SH_cheese && playerInventoryScript_P4.onionCount >= SH_onion)
        {
            canCookSnackHealth_P4 = true;
        }
        else
        {
            canCookSnackHealth_P4 = false;
        }

    }


    //PLAYER 1
    //cooking semi-auto rifle
    public void Cook_SemiAutoRifle_P1()
    {
        if(canCookSemiAutoRifle_P1 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= SR_bread;
                playerInventoryScript_P1.tomatoCount -= SR_tomato;
                checkmark1[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle (ALREADY)
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and burst rifle
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_BurstRifle_Active = false;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= SR_bread;
                playerInventoryScript_P1.tomatoCount -= SR_tomato;
                checkmark1[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_Shotgun_Active = false;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= SR_bread;
                playerInventoryScript_P1.tomatoCount -= SR_tomato;
                checkmark1[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= SR_bread;
                playerInventoryScript_P1.tomatoCount -= SR_tomato;
                checkmark1[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= SR_bread;
                playerInventoryScript_P1.tomatoCount -= SR_tomato;
                checkmark1[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }
        

    }

    //cooking burst rifle
    public void Cook_BurstRifle_P1()
    {
        if (canCookBurstRifle_P1 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_BurstRifle = true;
                weaponManagerScript_P1.weapon_BurstRifle_Active = true;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= BR_bread;
                playerInventoryScript_P1.tomatoCount -= BR_tomato;
                checkmark1[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_BurstRifle = true;
                weaponManagerScript_P1.weapon_BurstRifle_Active = true;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= BR_bread;
                playerInventoryScript_P1.tomatoCount -= BR_tomato;
                checkmark1[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle (ALREADY)
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_Shotgun_Active = false;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P1.hasWeapon_BurstRifle = true;
                weaponManagerScript_P1.weapon_BurstRifle_Active = true;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= BR_bread;
                playerInventoryScript_P1.tomatoCount -= BR_tomato;
                checkmark1[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_BurstRifle = true;
                weaponManagerScript_P1.weapon_BurstRifle_Active = true;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= BR_bread;
                playerInventoryScript_P1.tomatoCount -= BR_tomato;
                checkmark1[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_BurstRifle = true;
                weaponManagerScript_P1.weapon_BurstRifle_Active = true;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P1.breadCount -= BR_bread;
                playerInventoryScript_P1.tomatoCount -= BR_tomato;
                checkmark1[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking shotgun
    public void Cook_Shotgun_P1()
    {
        if (canCookShotgun_P1 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_Shotgun = true;
                weaponManagerScript_P1.weapon_Shotgun_Active = true;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P1.breadCount -= SG_bread;
                playerInventoryScript_P1.tomatoCount -= SG_tomato;
                checkmark1[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_Shotgun = true;
                weaponManagerScript_P1.weapon_Shotgun_Active = true;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P1.breadCount -= SG_bread;
                playerInventoryScript_P1.tomatoCount -= SG_tomato;
                checkmark1[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_BurstRifle_Active = false;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_Shotgun = true;
                weaponManagerScript_P1.weapon_Shotgun_Active = true;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P1.breadCount -= SG_bread;
                playerInventoryScript_P1.tomatoCount -= SG_tomato;
                checkmark1[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_Shotgun = true;
                weaponManagerScript_P1.weapon_Shotgun_Active = true;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P1.breadCount -= SG_bread;
                playerInventoryScript_P1.tomatoCount -= SG_tomato;
                checkmark1[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_Shotgun = true;
                weaponManagerScript_P1.weapon_Shotgun_Active = true;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P1.breadCount -= SG_bread;
                playerInventoryScript_P1.tomatoCount -= SG_tomato;
                checkmark1[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipCheese_P1()
    {
        if (canCookWhipCheese_P1 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P1.cheeseCount -= WC_cheese;
                checkmark1[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P1.cheeseCount -= WC_cheese;
                checkmark1[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_BurstRifle_Active = false;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P1.cheeseCount -= WC_cheese;
                checkmark1[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_Shotgun_Active = false;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P1.cheeseCount -= WC_cheese;
                checkmark1[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P1.cheeseCount -= WC_cheese;
                checkmark1[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipOnion_P1()
    {
        if (canCookWhipOnion_P1 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P1.onionCount -= WO_onion;
                checkmark1[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P1.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P1.onionCount -= WO_onion;
                checkmark1[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_BurstRifle_Active = false;
                weaponManagerScript_P1.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P1.onionCount -= WO_onion;
                checkmark1[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun 
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_Shotgun_Active = false;
                weaponManagerScript_P1.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P1.onionCount -= WO_onion;
                checkmark1[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P1.weapon_PeaShooter_Active = false;
                weaponManagerScript_P1.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P1.hasWeapon_PeaShooter = false;
                weaponManagerScript_P1.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P1.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P1.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P1.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P1.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P1.onionCount -= WO_onion;
                checkmark1[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion (ALREADY)
            else if (
                        weaponManagerScript_P1.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P1.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P1.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P1.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P1.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                //do nothing - accident click
            }
        }


    }

    //cooking Snack Speed
    public void Cook_SnackSpeed_P1()
    {
        if (canCookSnackSpeed_P1 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P1.hasSnack_SpeedBoost = true;
                playerInventoryScript_P1.tomatoCount -= SS_tomato;
                playerInventoryScript_P1.onionCount -= SS_onion;
                playerInventoryScript_P1.cheeseCount -= SS_cheese;
                checkmark1[5].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == true &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }
           
        }


    }

    //cooking Snack Damage
    public void Cook_SnackDamage_P1()
    {
        if (canCookSnackDamage_P1 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P1.hasSnack_DamageBoost = true;
                playerInventoryScript_P1.tomatoCount -= SD_tomato;
                playerInventoryScript_P1.onionCount -= SD_onion;
                playerInventoryScript_P1.cheeseCount -= SD_cheese;
                checkmark1[6].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == true &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Health
    public void Cook_SnackHealth_P1()
    {
        if (canCookSnackHealth_P1 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P1.hasSnack_HealthBoost = true;
                playerInventoryScript_P1.tomatoCount -= SH_tomato;
                playerInventoryScript_P1.onionCount -= SH_onion;
                playerInventoryScript_P1.cheeseCount -= SH_cheese;
                checkmark1[7].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == true &&
                        specialManagerScript_P1.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P1.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P1.hasSnack_DamageBoost == false &&
                        specialManagerScript_P1.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }


    //PLAYER 2
    //cooking semi-auto rifle
    public void Cook_SemiAutoRifle_P2()
    {
        if (canCookSemiAutoRifle_P2 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= SR_bread;
                playerInventoryScript_P2.tomatoCount -= SR_tomato;
                checkmark2[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle (ALREADY)
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and burst rifle
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_BurstRifle_Active = false;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= SR_bread;
                playerInventoryScript_P2.tomatoCount -= SR_tomato;
                checkmark2[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_Shotgun_Active = false;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= SR_bread;
                playerInventoryScript_P2.tomatoCount -= SR_tomato;
                checkmark2[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= SR_bread;
                playerInventoryScript_P2.tomatoCount -= SR_tomato;
                checkmark2[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= SR_bread;
                playerInventoryScript_P2.tomatoCount -= SR_tomato;
                checkmark2[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking burst rifle
    public void Cook_BurstRifle_P2()
    {
        if (canCookBurstRifle_P2 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_BurstRifle = true;
                weaponManagerScript_P2.weapon_BurstRifle_Active = true;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= BR_bread;
                playerInventoryScript_P2.tomatoCount -= BR_tomato;
                checkmark2[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_BurstRifle = true;
                weaponManagerScript_P2.weapon_BurstRifle_Active = true;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= BR_bread;
                playerInventoryScript_P2.tomatoCount -= BR_tomato;
                checkmark2[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle (ALREADY)
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_Shotgun_Active = false;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P2.hasWeapon_BurstRifle = true;
                weaponManagerScript_P2.weapon_BurstRifle_Active = true;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= BR_bread;
                playerInventoryScript_P2.tomatoCount -= BR_tomato;
                checkmark2[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_BurstRifle = true;
                weaponManagerScript_P2.weapon_BurstRifle_Active = true;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= BR_bread;
                playerInventoryScript_P2.tomatoCount -= BR_tomato;
                checkmark2[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_BurstRifle = true;
                weaponManagerScript_P2.weapon_BurstRifle_Active = true;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P2.breadCount -= BR_bread;
                playerInventoryScript_P2.tomatoCount -= BR_tomato;
                checkmark2[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking shotgun
    public void Cook_Shotgun_P2()
    {
        if (canCookShotgun_P2 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_Shotgun = true;
                weaponManagerScript_P2.weapon_Shotgun_Active = true;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P2.breadCount -= SG_bread;
                playerInventoryScript_P2.tomatoCount -= SG_tomato;
                checkmark2[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_Shotgun = true;
                weaponManagerScript_P2.weapon_Shotgun_Active = true;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P2.breadCount -= SG_bread;
                playerInventoryScript_P2.tomatoCount -= SG_tomato;
                checkmark2[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_BurstRifle_Active = false;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_Shotgun = true;
                weaponManagerScript_P2.weapon_Shotgun_Active = true;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P2.breadCount -= SG_bread;
                playerInventoryScript_P2.tomatoCount -= SG_tomato;
                checkmark2[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_Shotgun = true;
                weaponManagerScript_P2.weapon_Shotgun_Active = true;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P2.breadCount -= SG_bread;
                playerInventoryScript_P2.tomatoCount -= SG_tomato;
                checkmark2[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_Shotgun = true;
                weaponManagerScript_P2.weapon_Shotgun_Active = true;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P2.breadCount -= SG_bread;
                playerInventoryScript_P2.tomatoCount -= SG_tomato;
                checkmark2[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipCheese_P2()
    {
        if (canCookWhipCheese_P2 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P2.cheeseCount -= WC_cheese;
                checkmark2[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P2.cheeseCount -= WC_cheese;
                checkmark2[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_BurstRifle_Active = false;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P2.cheeseCount -= WC_cheese;
                checkmark2[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_Shotgun_Active = false;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P2.cheeseCount -= WC_cheese;
                checkmark2[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P2.cheeseCount -= WC_cheese;
                checkmark2[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipOnion_P2()
    {
        if (canCookWhipOnion_P2 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P2.onionCount -= WO_onion;
                checkmark2[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P2.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P2.onionCount -= WO_onion;
                checkmark2[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_BurstRifle_Active = false;
                weaponManagerScript_P2.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P2.onionCount -= WO_onion;
                checkmark2[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun 
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_Shotgun_Active = false;
                weaponManagerScript_P2.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P2.onionCount -= WO_onion;
                checkmark2[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P2.weapon_PeaShooter_Active = false;
                weaponManagerScript_P2.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P2.hasWeapon_PeaShooter = false;
                weaponManagerScript_P2.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P2.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P2.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P2.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P2.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P2.onionCount -= WO_onion;
                checkmark2[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion (ALREADY)
            else if (
                        weaponManagerScript_P2.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P2.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P2.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P2.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P2.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                //do nothing - accident click
            }
        }


    }

    //cooking Snack Speed
    public void Cook_SnackSpeed_P2()
    {
        if (canCookSnackSpeed_P2 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P2.hasSnack_SpeedBoost = true;
                playerInventoryScript_P2.tomatoCount -= SS_tomato;
                playerInventoryScript_P2.onionCount -= SS_onion;
                playerInventoryScript_P2.cheeseCount -= SS_cheese;
                checkmark2[5].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == true &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Damage
    public void Cook_SnackDamage_P2()
    {
        if (canCookSnackDamage_P2 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P2.hasSnack_DamageBoost = true;
                playerInventoryScript_P2.tomatoCount -= SD_tomato;
                playerInventoryScript_P2.onionCount -= SD_onion;
                playerInventoryScript_P2.cheeseCount -= SD_cheese;
                checkmark2[6].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == true &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Health
    public void Cook_SnackHealth_P2()
    {
        if (canCookSnackHealth_P2 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P2.hasSnack_HealthBoost = true;
                playerInventoryScript_P2.tomatoCount -= SH_tomato;
                playerInventoryScript_P2.onionCount -= SH_onion;
                playerInventoryScript_P2.cheeseCount -= SH_cheese;
                checkmark2[7].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == true &&
                        specialManagerScript_P2.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P2.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P2.hasSnack_DamageBoost == false &&
                        specialManagerScript_P2.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }



    //PLAYER 3
    //cooking semi-auto rifle
    public void Cook_SemiAutoRifle_P3()
    {
        if (canCookSemiAutoRifle_P3 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= SR_bread;
                playerInventoryScript_P3.tomatoCount -= SR_tomato;
                checkmark3[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle (ALREADY)
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and burst rifle
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_BurstRifle_Active = false;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= SR_bread;
                playerInventoryScript_P3.tomatoCount -= SR_tomato;
                checkmark3[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_Shotgun_Active = false;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= SR_bread;
                playerInventoryScript_P3.tomatoCount -= SR_tomato;
                checkmark3[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= SR_bread;
                playerInventoryScript_P3.tomatoCount -= SR_tomato;
                checkmark3[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= SR_bread;
                playerInventoryScript_P3.tomatoCount -= SR_tomato;
                checkmark3[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking burst rifle
    public void Cook_BurstRifle_P3()
    {
        if (canCookBurstRifle_P3 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_BurstRifle = true;
                weaponManagerScript_P3.weapon_BurstRifle_Active = true;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= BR_bread;
                playerInventoryScript_P3.tomatoCount -= BR_tomato;
                checkmark3[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_BurstRifle = true;
                weaponManagerScript_P3.weapon_BurstRifle_Active = true;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= BR_bread;
                playerInventoryScript_P3.tomatoCount -= BR_tomato;
                checkmark3[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle (ALREADY)
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_Shotgun_Active = false;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P3.hasWeapon_BurstRifle = true;
                weaponManagerScript_P3.weapon_BurstRifle_Active = true;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= BR_bread;
                playerInventoryScript_P3.tomatoCount -= BR_tomato;
                checkmark3[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_BurstRifle = true;
                weaponManagerScript_P3.weapon_BurstRifle_Active = true;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= BR_bread;
                playerInventoryScript_P3.tomatoCount -= BR_tomato;
                checkmark3[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_BurstRifle = true;
                weaponManagerScript_P3.weapon_BurstRifle_Active = true;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P3.breadCount -= BR_bread;
                playerInventoryScript_P3.tomatoCount -= BR_tomato;
                checkmark3[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking shotgun
    public void Cook_Shotgun_P3()
    {
        if (canCookShotgun_P3 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_Shotgun = true;
                weaponManagerScript_P3.weapon_Shotgun_Active = true;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P3.breadCount -= SG_bread;
                playerInventoryScript_P3.tomatoCount -= SG_tomato;
                checkmark3[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_Shotgun = true;
                weaponManagerScript_P3.weapon_Shotgun_Active = true;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P3.breadCount -= SG_bread;
                playerInventoryScript_P3.tomatoCount -= SG_tomato;
                checkmark3[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_BurstRifle_Active = false;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_Shotgun = true;
                weaponManagerScript_P3.weapon_Shotgun_Active = true;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P3.breadCount -= SG_bread;
                playerInventoryScript_P3.tomatoCount -= SG_tomato;
                checkmark3[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_Shotgun = true;
                weaponManagerScript_P3.weapon_Shotgun_Active = true;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P3.breadCount -= SG_bread;
                playerInventoryScript_P3.tomatoCount -= SG_tomato;
                checkmark3[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_Shotgun = true;
                weaponManagerScript_P3.weapon_Shotgun_Active = true;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P3.breadCount -= SG_bread;
                playerInventoryScript_P3.tomatoCount -= SG_tomato;
                checkmark3[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipCheese_P3()
    {
        if (canCookWhipCheese_P3 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P3.cheeseCount -= WC_cheese;
                checkmark3[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P3.cheeseCount -= WC_cheese;
                checkmark3[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_BurstRifle_Active = false;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P3.cheeseCount -= WC_cheese;
                checkmark3[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_Shotgun_Active = false;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P3.cheeseCount -= WC_cheese;
                checkmark3[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P3.cheeseCount -= WC_cheese;
                checkmark3[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipOnion_P3()
    {
        if (canCookWhipOnion_P3 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P3.onionCount -= WO_onion;
                checkmark3[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P3.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P3.onionCount -= WO_onion;
                checkmark3[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_BurstRifle_Active = false;
                weaponManagerScript_P3.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P3.onionCount -= WO_onion;
                checkmark3[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun 
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_Shotgun_Active = false;
                weaponManagerScript_P3.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P3.onionCount -= WO_onion;
                checkmark3[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P3.weapon_PeaShooter_Active = false;
                weaponManagerScript_P3.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P3.hasWeapon_PeaShooter = false;
                weaponManagerScript_P3.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P3.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P3.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P3.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P3.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P3.onionCount -= WO_onion;
                checkmark3[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion (ALREADY)
            else if (
                        weaponManagerScript_P3.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P3.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P3.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P3.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P3.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                //do nothing - accident click
            }
        }


    }

    //cooking Snack Speed
    public void Cook_SnackSpeed_P3()
    {
        if (canCookSnackSpeed_P3 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P3.hasSnack_SpeedBoost = true;
                playerInventoryScript_P3.tomatoCount -= SS_tomato;
                playerInventoryScript_P3.onionCount -= SS_onion;
                playerInventoryScript_P3.cheeseCount -= SS_cheese;
                checkmark3[5].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == true &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Damage
    public void Cook_SnackDamage_P3()
    {
        if (canCookSnackDamage_P3 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P3.hasSnack_DamageBoost = true;
                playerInventoryScript_P3.tomatoCount -= SD_tomato;
                playerInventoryScript_P3.onionCount -= SD_onion;
                playerInventoryScript_P3.cheeseCount -= SD_cheese;
                checkmark3[6].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == true &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Health
    public void Cook_SnackHealth_P3()
    {
        if (canCookSnackHealth_P3 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P3.hasSnack_HealthBoost = true;
                playerInventoryScript_P3.tomatoCount -= SH_tomato;
                playerInventoryScript_P3.onionCount -= SH_onion;
                playerInventoryScript_P3.cheeseCount -= SH_cheese;
                checkmark3[7].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == true &&
                        specialManagerScript_P3.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P3.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P3.hasSnack_DamageBoost == false &&
                        specialManagerScript_P3.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }



    //PLAYER 4
    //cooking semi-auto rifle
    public void Cook_SemiAutoRifle_P4()
    {
        if (canCookSemiAutoRifle_P4 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= SR_bread;
                playerInventoryScript_P4.tomatoCount -= SR_tomato;
                checkmark4[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle (ALREADY)
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and burst rifle
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_BurstRifle_Active = false;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= SR_bread;
                playerInventoryScript_P4.tomatoCount -= SR_tomato;
                checkmark4[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_Shotgun_Active = false;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= SR_bread;
                playerInventoryScript_P4.tomatoCount -= SR_tomato;
                checkmark4[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= SR_bread;
                playerInventoryScript_P4.tomatoCount -= SR_tomato;
                checkmark4[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SemiAutoRifle = true;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = true;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= SR_bread;
                playerInventoryScript_P4.tomatoCount -= SR_tomato;
                checkmark4[0].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking burst rifle
    public void Cook_BurstRifle_P4()
    {
        if (canCookBurstRifle_P4 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_BurstRifle = true;
                weaponManagerScript_P4.weapon_BurstRifle_Active = true;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= BR_bread;
                playerInventoryScript_P4.tomatoCount -= BR_tomato;
                checkmark4[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_BurstRifle = true;
                weaponManagerScript_P4.weapon_BurstRifle_Active = true;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= BR_bread;
                playerInventoryScript_P4.tomatoCount -= BR_tomato;
                checkmark4[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle (ALREADY)
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and shotgun
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_Shotgun_Active = false;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P4.hasWeapon_BurstRifle = true;
                weaponManagerScript_P4.weapon_BurstRifle_Active = true;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= BR_bread;
                playerInventoryScript_P4.tomatoCount -= BR_tomato;
                checkmark4[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_BurstRifle = true;
                weaponManagerScript_P4.weapon_BurstRifle_Active = true;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= BR_bread;
                playerInventoryScript_P4.tomatoCount -= BR_tomato;
                checkmark4[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_BurstRifle = true;
                weaponManagerScript_P4.weapon_BurstRifle_Active = true;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(true);
                playerInventoryScript_P4.breadCount -= BR_bread;
                playerInventoryScript_P4.tomatoCount -= BR_tomato;
                checkmark4[1].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking shotgun
    public void Cook_Shotgun_P4()
    {
        if (canCookShotgun_P4 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_Shotgun = true;
                weaponManagerScript_P4.weapon_Shotgun_Active = true;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P4.breadCount -= SG_bread;
                playerInventoryScript_P4.tomatoCount -= SG_tomato;
                checkmark4[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_Shotgun = true;
                weaponManagerScript_P4.weapon_Shotgun_Active = true;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P4.breadCount -= SG_bread;
                playerInventoryScript_P4.tomatoCount -= SG_tomato;
                checkmark4[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_BurstRifle_Active = false;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_Shotgun = true;
                weaponManagerScript_P4.weapon_Shotgun_Active = true;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P4.breadCount -= SG_bread;
                playerInventoryScript_P4.tomatoCount -= SG_tomato;
                checkmark4[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_Shotgun = true;
                weaponManagerScript_P4.weapon_Shotgun_Active = true;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P4.breadCount -= SG_bread;
                playerInventoryScript_P4.tomatoCount -= SG_tomato;
                checkmark4[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_Shotgun = true;
                weaponManagerScript_P4.weapon_Shotgun_Active = true;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(true);
                playerInventoryScript_P4.breadCount -= SG_bread;
                playerInventoryScript_P4.tomatoCount -= SG_tomato;
                checkmark4[2].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipCheese_P4()
    {
        if (canCookWhipCheese_P4 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P4.cheeseCount -= WC_cheese;
                checkmark4[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P4.cheeseCount -= WC_cheese;
                checkmark4[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_BurstRifle_Active = false;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P4.cheeseCount -= WC_cheese;
                checkmark4[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun (ALREADY)
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_Shotgun_Active = false;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P4.cheeseCount -= WC_cheese;
                checkmark4[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                //do nothing - accident click
            }
            //check if has pea shooter and whip onion
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WC_spaghetti;
                playerInventoryScript_P4.cheeseCount -= WC_cheese;
                checkmark4[3].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
        }


    }

    //cooking Whip Cheese
    public void Cook_WhipOnion_P4()
    {
        if (canCookWhipOnion_P4 == true)
        {
            //check if only has pea shooter
            if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
               )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P4.onionCount -= WO_onion;
                checkmark4[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and semi auto rifle
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == true &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SemiAutoRifle_Active = false;
                weaponManagerScript_P4.Weapon_SemiAutoRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P4.onionCount -= WO_onion;
                checkmark4[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and burst rifle 
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == true &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false
                   )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_BurstRifle_Active = false;
                weaponManagerScript_P4.Weapon_BurstRifle.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P4.onionCount -= WO_onion;
                checkmark4[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and shotgun 
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_Shotgun_Active = false;
                weaponManagerScript_P4.Weapon_Shotgun.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P4.onionCount -= WO_onion;
                checkmark4[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip cheese
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == true &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == false

                    )
            {
                weaponManagerScript_P4.weapon_PeaShooter_Active = false;
                weaponManagerScript_P4.Weapon_PeaShooter.SetActive(false);
                weaponManagerScript_P4.hasWeapon_PeaShooter = false;
                weaponManagerScript_P4.weapon_SpaghettiWhipCheese_Active = false;
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_WindUp.SetActive(false);
                weaponManagerScript_P4.Weapon_SpaghettiWhipCheese_Attack.SetActive(false);
                weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion = true;
                weaponManagerScript_P4.weapon_SpaghettiWhipOnion_Active = true;
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_Attack.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_WindUp.SetActive(true);
                weaponManagerScript_P4.Weapon_SpaghettiWhipOnion_SpriteRenderer.enabled = false;
                playerInventoryScript_P4.spaghettiCount -= WO_spaghetti;
                playerInventoryScript_P4.onionCount -= WO_onion;
                checkmark4[4].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has pea shooter and whip onion (ALREADY)
            else if (
                        weaponManagerScript_P4.hasWeapon_PeaShooter == true &&
                        weaponManagerScript_P4.hasWeapon_SemiAutoRifle == false &&
                        weaponManagerScript_P4.hasWeapon_BurstRifle == false &&
                        weaponManagerScript_P4.hasWeapon_Shotgun == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipCheese == false &&
                        weaponManagerScript_P4.hasWeapon_SpaghettiWhipOnion == true

                    )
            {
                //do nothing - accident click
            }
        }


    }

    //cooking Snack Speed
    public void Cook_SnackSpeed_P4()
    {
        if (canCookSnackSpeed_P4 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P4.hasSnack_SpeedBoost = true;
                playerInventoryScript_P4.tomatoCount -= SS_tomato;
                playerInventoryScript_P4.onionCount -= SS_onion;
                playerInventoryScript_P4.cheeseCount -= SS_cheese;
                checkmark4[5].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == true &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Damage
    public void Cook_SnackDamage_P4()
    {
        if (canCookSnackDamage_P4 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P4.hasSnack_DamageBoost = true;
                playerInventoryScript_P4.tomatoCount -= SD_tomato;
                playerInventoryScript_P4.onionCount -= SD_onion;
                playerInventoryScript_P4.cheeseCount -= SD_cheese;
                checkmark4[6].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == true &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }

    //cooking Snack Health
    public void Cook_SnackHealth_P4()
    {
        if (canCookSnackHealth_P4 == true)
        {
            //check if has no snack
            if (

                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
               )
            {
                specialManagerScript_P4.hasSnack_HealthBoost = true;
                playerInventoryScript_P4.tomatoCount -= SH_tomato;
                playerInventoryScript_P4.onionCount -= SH_onion;
                playerInventoryScript_P4.cheeseCount -= SH_cheese;
                checkmark4[7].SetActive(true);
                SFX_cookItemSuccess.Play();
            }
            //check if has snack speed (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == true &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                    )
            {
                //do nothing - accident click
            }
            //check if has snack damage (already)
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == true &&
                        specialManagerScript_P4.hasSnack_HealthBoost == false
                   )
            {
                //do nothing
            }
            //check if has snack health already
            else if (
                        specialManagerScript_P4.hasSnack_SpeedBoost == false &&
                        specialManagerScript_P4.hasSnack_DamageBoost == false &&
                        specialManagerScript_P4.hasSnack_HealthBoost == true

                    )
            {
                //do nothing
            }

        }


    }
}
