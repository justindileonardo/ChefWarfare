﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //public variables
    public GameObject Weapon_PivotPoint;
    //Pea Shooter
    public GameObject Weapon_PeaShooter; 
    public bool hasWeaponPeaShooter;
    public bool weaponPeaShooterActive;
    //Pea
    public GameObject PeaPrefab;



    //private variables
    //Pea Shooter
    private float peaShooterCooldown;

    // Start is called before the first frame update
    void Start()
    {
        hasWeaponPeaShooter = true;
        weaponPeaShooterActive = true;
        peaShooterCooldown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //using Pea Shooter
        if(hasWeaponPeaShooter == true && weaponPeaShooterActive == true)
        {
            //value 0-1 of not pressed or pressed "AttackMain" (RT)
            float attackMain = Input.GetAxis("AttackMain");

            //cooldown/reload timer in between shots
            peaShooterCooldown -= Time.deltaTime;

            //if pressed, check if shot is ready and shoot.  Reset cooldown timer.
            if(attackMain != 0 && peaShooterCooldown < 0)
            {
                peaShooterCooldown = 2f;
                Instantiate(PeaPrefab, new Vector3(Weapon_PeaShooter.transform.position.x, Weapon_PeaShooter.transform.position.y, Weapon_PeaShooter.transform.position.z), Weapon_PivotPoint.transform.rotation);
            }
        }


    }
}