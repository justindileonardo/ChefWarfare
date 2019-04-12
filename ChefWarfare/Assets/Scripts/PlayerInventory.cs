using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    private PlayerMovement myPlayerMovementScript;
    private Cooking cookingScript;
    private WeaponManager weaponManagerScript;
    private SpecialManager specialManagerScript;

    public int breadCount;
    public int spaghettiCount;
    public int tomatoCount;
    public int cheeseCount;
    public int onionCount;

    public TextMeshProUGUI breadText;
    public TextMeshProUGUI spaghettiText;
    public TextMeshProUGUI tomatoText;
    public TextMeshProUGUI onionText;
    public TextMeshProUGUI cheeseText;

    public TextMeshProUGUI breadTextR;
    public TextMeshProUGUI spaghettiTextR;
    public TextMeshProUGUI tomatoTextR;
    public TextMeshProUGUI onionTextR;
    public TextMeshProUGUI cheeseTextR;

    public GameObject ResourcesALL;
    public GameObject ResourcesRALL;

    public Image og1_1;
    public Image og1_2;
    public Image og2_1;
    public Image og2_2;
    public Image og3_1;
    public Image og3_2;
    public Image og4_1;
    public Image og4_2;
    public Image og5_1;
    public Image og5_2;
    public Image og6_1;
    public Image og6_2;
    public Image og6_3;
    public Image og7_1;
    public Image og7_2;
    public Image og7_3;
    public Image og8_1;
    public Image og8_2;
    public Image og8_3;

    public Image or1_1;
    public Image or1_2;
    public Image or2_1;
    public Image or2_2;
    public Image or3_1;
    public Image or3_2;
    public Image or4_1;
    public Image or4_2;
    public Image or5_1;
    public Image or5_2;
    public Image or6_1;
    public Image or6_2;
    public Image or6_3;
    public Image or7_1;
    public Image or7_2;
    public Image or7_3;
    public Image or8_1;
    public Image or8_2;
    public Image or8_3;


    public GameObject RecipeStatus_SR;
    public GameObject RecipeStatus_BR;
    public GameObject RecipeStatus_SG;
    public GameObject RecipeStatus_WC;
    public GameObject RecipeStatus_WO;
    public GameObject RecipeStatus_SS;
    public GameObject RecipeStatus_SD;
    public GameObject RecipeStatus_SH;

    public Transform firstPos;
    public Transform secondPos;
    public Transform thirdPos;
    public Transform fourthPos;
    public Transform fifthPos;

    private bool firstSpotTaken;
    private bool secondSpotTaken;
    private bool thirdSpotTaken;
    private bool fourthSpotTaken;
    private bool fifthSpotTaken;

    private bool playerAlreadyShown_SR;
    private bool playerAlreadyShown_BR;
    private bool playerAlreadyShown_SG;
    private bool playerAlreadyShown_WC;
    private bool playerAlreadyShown_WO;
    private bool playerAlreadyShown_SS;
    private bool playerAlreadyShown_SD;
    private bool playerAlreadyShown_SH;

    public AudioSource SFX_recipeReady;


    // Start is called before the first frame update
    void Start()
    {
        myPlayerMovementScript = GetComponent<PlayerMovement>();
        cookingScript = GameObject.Find("CookingScript").GetComponent<Cooking>();
        weaponManagerScript = GetComponent<WeaponManager>();
        specialManagerScript = GetComponent<SpecialManager>();

        /*breadCount = 0;           TESTING
        tomatoCount = 0;
        spaghettiCount = 0;
        cheeseCount = 0;
        onionCount = 0;*/

        NotInRecipeBook();

        og1_1.enabled = false;
        og1_2.enabled = false;
        og2_1.enabled = false;
        og2_2.enabled = false;
        og3_1.enabled = false;
        og3_2.enabled = false;
        og4_1.enabled = false;
        og4_2.enabled = false;
        og5_1.enabled = false;
        og5_2.enabled = false;
        og6_1.enabled = false;
        og6_2.enabled = false;
        og6_3.enabled = false;
        og7_1.enabled = false;
        og7_2.enabled = false;
        og7_3.enabled = false;
        og8_1.enabled = false;
        og8_2.enabled = false;
        og8_3.enabled = false;

        or1_1.enabled = true;
        or1_2.enabled = true;
        or2_1.enabled = true;
        or2_2.enabled = true;
        or3_1.enabled = true;
        or3_2.enabled = true;
        or4_1.enabled = true;
        or4_2.enabled = true;
        or5_1.enabled = true;
        or5_2.enabled = true;
        or6_1.enabled = true;
        or6_2.enabled = true;
        or6_3.enabled = true;
        or7_1.enabled = true;
        or7_2.enabled = true;
        or7_3.enabled = true;
        or8_1.enabled = true;
        or8_2.enabled = true;
        or8_3.enabled = true;

        RecipeStatus_SR.SetActive(false);
        RecipeStatus_BR.SetActive(false);
        RecipeStatus_SG.SetActive(false);
        RecipeStatus_WC.SetActive(false);
        RecipeStatus_WO.SetActive(false);
        RecipeStatus_SS.SetActive(false);
        RecipeStatus_SD.SetActive(false);
        RecipeStatus_SH.SetActive(false);

        playerAlreadyShown_SR = false;
        playerAlreadyShown_BR = false;
        playerAlreadyShown_SG = false;
        playerAlreadyShown_WC = false;
        playerAlreadyShown_WO = false;
        playerAlreadyShown_SS = false;
        playerAlreadyShown_SD = false;
        playerAlreadyShown_SH = false;

    }

    // Update is called once per frame
    void Update()
    {
        breadText.text = breadCount.ToString();
        tomatoText.text = tomatoCount.ToString();
        spaghettiText.text = spaghettiCount.ToString();
        onionText.text = onionCount.ToString();
        cheeseText.text = cheeseCount.ToString();
        breadTextR.text = breadCount.ToString();
        tomatoTextR.text = tomatoCount.ToString();
        spaghettiTextR.text = spaghettiCount.ToString();
        onionTextR.text = onionCount.ToString();
        cheeseTextR.text = cheeseCount.ToString();


        UpdateRecipeBookBoxOutlineColors();

        UpdateAlreadyShowns();


    }

    public void InRecipeBook()
    {
        ResourcesALL.SetActive(false);
        ResourcesRALL.SetActive(true);
    }

    public void NotInRecipeBook()
    {
        ResourcesALL.SetActive(true);
        ResourcesRALL.SetActive(false);
    }

    public void UpdateRecipeBookBoxOutlineColors()
    {
        //Changing color based on amounts player has
        //Semi Auto Rifle Bread
        if (breadCount >= cookingScript.SR_bread && og1_1.enabled == false)
        {
            og1_1.enabled = true;
            or1_1.enabled = false;
        }
        else if (breadCount < cookingScript.SR_bread && og1_1.enabled == true)
        {
            og1_1.enabled = false;
            or1_1.enabled = true;
        }

        //Semi Auto Rifle Tomato
        if (tomatoCount >= cookingScript.SR_tomato && og1_2.enabled == false)
        {
            og1_2.enabled = true;
            or1_2.enabled = false;
        }
        else if (tomatoCount < cookingScript.SR_tomato && og1_2.enabled == true)
        {
            og1_2.enabled = false;
            or1_2.enabled = true;
        }

        //Burst Rifle Bread
        if (breadCount >= cookingScript.BR_bread && og2_1.enabled == false)
        {
            og2_1.enabled = true;
            or2_1.enabled = false;
        }
        else if (breadCount < cookingScript.BR_bread && og2_1.enabled == true)
        {
            og2_1.enabled = false;
            or2_1.enabled = true;
        }

        //Burst Rifle Tomato
        if (tomatoCount >= cookingScript.BR_tomato && og2_2.enabled == false)
        {
            og2_2.enabled = true;
            or2_2.enabled = false;
        }
        else if (tomatoCount < cookingScript.BR_tomato && og2_2.enabled == true)
        {
            og2_2.enabled = false;
            or2_2.enabled = true;
        }

        //Shotgun Bread
        if (breadCount >= cookingScript.SG_bread && og3_1.enabled == false)
        {
            og3_1.enabled = true;
            or3_1.enabled = false;
        }
        else if (breadCount < cookingScript.SG_bread && og3_1.enabled == true)
        {
            og3_1.enabled = false;
            or3_1.enabled = true;
        }

        //Shotgun Tomato
        if (tomatoCount >= cookingScript.SG_tomato && og3_2.enabled == false)
        {
            og3_2.enabled = true;
            or3_2.enabled = false;
        }
        else if (tomatoCount < cookingScript.SG_tomato && og3_2.enabled == true)
        {
            og3_2.enabled = false;
            or3_2.enabled = true;
        }

        //Whip Cheese Spaghetti
        if (spaghettiCount >= cookingScript.WC_spaghetti && og4_1.enabled == false)
        {
            og4_1.enabled = true;
            or4_1.enabled = false;
        }
        else if (spaghettiCount < cookingScript.WC_spaghetti && og4_1.enabled == true)
        {
            og4_1.enabled = false;
            or4_1.enabled = true;
        }

        //Whip Cheese Cheese
        if (cheeseCount >= cookingScript.WC_cheese && og4_2.enabled == false)
        {
            og4_2.enabled = true;
            or4_2.enabled = false;
        }
        else if (cheeseCount < cookingScript.WC_cheese && og4_2.enabled == true)
        {
            og4_2.enabled = false;
            or4_2.enabled = true;
        }

        //Whip Onion Spaghetti
        if (spaghettiCount >= cookingScript.WO_spaghetti && og5_1.enabled == false)
        {
            og5_1.enabled = true;
            or5_1.enabled = false;
        }
        else if (spaghettiCount < cookingScript.WO_spaghetti && og5_1.enabled == true)
        {
            og5_1.enabled = false;
            or5_1.enabled = true;
        }

        //Whip Onion Onion
        if (onionCount >= cookingScript.WO_onion && og5_2.enabled == false)
        {
            og5_2.enabled = true;
            or5_2.enabled = false;
        }
        else if (onionCount < cookingScript.WO_onion && og5_2.enabled == true)
        {
            og5_2.enabled = false;
            or5_2.enabled = true;
        }

        //Shake Speed Tomato
        if (tomatoCount >= cookingScript.SS_tomato && og6_1.enabled == false)
        {
            og6_1.enabled = true;
            or6_1.enabled = false;
        }
        else if (tomatoCount < cookingScript.SS_tomato && og6_1.enabled == true)
        {
            og6_1.enabled = false;
            or6_1.enabled = true;
        }

        //Shake Speed Cheese
        if (cheeseCount >= cookingScript.SS_cheese && og6_2.enabled == false)
        {
            og6_2.enabled = true;
            or6_2.enabled = false;
        }
        else if (cheeseCount < cookingScript.SS_cheese && og6_2.enabled == true)
        {
            og6_2.enabled = false;
            or6_2.enabled = true;
        }

        //Shake Speed Onion
        if (onionCount >= cookingScript.SS_onion && og6_3.enabled == false)
        {
            og6_3.enabled = true;
            or6_3.enabled = false;
        }
        else if (onionCount < cookingScript.SS_onion && og6_3.enabled == true)
        {
            og6_3.enabled = false;
            or6_3.enabled = true;
        }

        //Shake Damage Tomato
        if (tomatoCount >= cookingScript.SD_tomato && og7_1.enabled == false)
        {
            og7_1.enabled = true;
            or7_1.enabled = false;
        }
        else if (tomatoCount < cookingScript.SD_tomato && og7_1.enabled == true)
        {
            og7_1.enabled = false;
            or7_1.enabled = true;
        }

        //Shake Damage Cheese
        if (cheeseCount >= cookingScript.SD_cheese && og7_2.enabled == false)
        {
            og7_2.enabled = true;
            or7_2.enabled = false;
        }
        else if (cheeseCount < cookingScript.SD_cheese && og7_2.enabled == true)
        {
            og7_2.enabled = false;
            or7_2.enabled = true;
        }

        //Shake Damage Onion
        if (onionCount >= cookingScript.SD_onion && og7_3.enabled == false)
        {
            og7_3.enabled = true;
            or7_3.enabled = false;
        }
        else if (onionCount < cookingScript.SD_onion && og7_3.enabled == true)
        {
            og7_3.enabled = false;
            or7_3.enabled = true;
        }

        //Shake Health Tomato
        if (tomatoCount >= cookingScript.SH_tomato && og8_1.enabled == false)
        {
            og8_1.enabled = true;
            or8_1.enabled = false;
        }
        else if (tomatoCount < cookingScript.SH_tomato && og8_1.enabled == true)
        {
            og8_1.enabled = false;
            or8_1.enabled = true;
        }

        //Shake Health Cheese
        if (cheeseCount >= cookingScript.SH_cheese && og8_2.enabled == false)
        {
            og8_2.enabled = true;
            or8_2.enabled = false;
        }
        else if (cheeseCount < cookingScript.SH_cheese && og8_2.enabled == true)
        {
            og8_2.enabled = false;
            or8_2.enabled = true;
        }

        //Shake Health Onion
        if (onionCount >= cookingScript.SH_onion && og8_3.enabled == false)
        {
            og8_3.enabled = true;
            or8_3.enabled = false;
        }
        else if (onionCount < cookingScript.SH_onion && og8_3.enabled == true)
        {
            og8_3.enabled = false;
            or8_3.enabled = true;
        }
    }

    public void UpdateAlreadyShowns()
    {
        //this is to allow the recipe status again if the player crafts something but it is not the item that is ready again
        //Semi Auto Rifle
        if (weaponManagerScript.hasWeapon_SemiAutoRifle == false)
        {
            if (breadCount < cookingScript.SR_bread || tomatoCount < cookingScript.SR_tomato)
            {
                playerAlreadyShown_SR = false;
            }
        }
        //Burst Rifle
        if (weaponManagerScript.hasWeapon_BurstRifle == false)
        {
            if (breadCount < cookingScript.BR_bread || tomatoCount < cookingScript.BR_tomato)
            {
                playerAlreadyShown_BR = false;
            }
        }
        //Shotgun
        if (weaponManagerScript.hasWeapon_Shotgun == false)
        {
            if (breadCount < cookingScript.SG_bread || tomatoCount < cookingScript.SG_tomato)
            {
                playerAlreadyShown_SG = false;
            }
        }
        //Whip Cheese
        if (weaponManagerScript.hasWeapon_SpaghettiWhipCheese == false)
        {
            if (spaghettiCount < cookingScript.WC_spaghetti || cheeseCount < cookingScript.WC_cheese)
            {
                playerAlreadyShown_WC = false;
            }
        }
        //Whip Onion
        if (weaponManagerScript.hasWeapon_SpaghettiWhipOnion == false)
        {
            if (spaghettiCount < cookingScript.WO_spaghetti || onionCount < cookingScript.WO_onion)
            {
                playerAlreadyShown_WO = false;
            }
        }
        //Shake Speed
        if (specialManagerScript.hasSnack_SpeedBoost == false)
        {
            if (tomatoCount < cookingScript.SS_tomato || onionCount < cookingScript.SS_onion || cheeseCount < cookingScript.SS_cheese)
            {
                playerAlreadyShown_SS = false;
            }
        }
        //Shake Damage
        if (specialManagerScript.hasSnack_DamageBoost == false)
        {
            if (tomatoCount < cookingScript.SD_tomato || onionCount < cookingScript.SD_onion || cheeseCount < cookingScript.SD_cheese)
            {
                playerAlreadyShown_SD = false;
            }
        }
        //Shake Health
        if (specialManagerScript.hasSnack_HealthBoost == false)
        {
            if (tomatoCount < cookingScript.SH_tomato || onionCount < cookingScript.SH_onion || cheeseCount < cookingScript.SH_cheese)
            {
                playerAlreadyShown_SH = false;
            }
        }
    }

    IEnumerator UpdateRecipeStatus_SemiAutoRifle()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if(firstSpotTaken == false)
        {
            RecipeStatus_SR.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else 
        {
            if(secondSpotTaken == false)
            {
                RecipeStatus_SR.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if(thirdSpotTaken == false)
                {
                    RecipeStatus_SR.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if(fourthSpotTaken == false)
                    {
                        RecipeStatus_SR.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if(fifthSpotTaken == false)
                        {
                            RecipeStatus_SR.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_SR.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_SR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SR.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_SR.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if(spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_BurstRifle()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_BR.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_BR.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_BR.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_BR.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_BR.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_BR.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_BR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_BR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_BR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_BR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_BR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_BR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_BR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_BR.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_BR.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_BR.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatusShotgun()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_SG.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_SG.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_SG.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_SG.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_SG.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_SG.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_SG.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SG.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SG.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SG.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SG.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SG.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SG.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SG.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SG.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_SG.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_WhipCheese()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_WC.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_WC.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_WC.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_WC.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_WC.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_WC.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_WC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WC.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WC.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WC.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WC.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WC.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_WC.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_WhipOnion()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_WO.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_WO.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_WO.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_WO.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_WO.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_WO.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_WO.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WO.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WO.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WO.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WO.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WO.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WO.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_WO.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_WO.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_WO.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_ShakeSpeed()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_SS.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_SS.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_SS.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_SS.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_SS.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_SS.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_SS.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SS.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SS.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SS.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SS.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SS.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SS.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SS.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SS.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_SS.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_ShakeDamage()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_SD.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_SD.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_SD.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_SD.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_SD.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_SD.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_SD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SD.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SD.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SD.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SD.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SD.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_SD.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    IEnumerator UpdateRecipeStatus_ShakeHealth()
    {
        int spotTaken;
        //this checks if the position is taken and if not, puts it there on player screen
        if (firstSpotTaken == false)
        {
            RecipeStatus_SH.transform.position = firstPos.transform.position;
            firstSpotTaken = true;
            spotTaken = 1;
        }
        else
        {
            if (secondSpotTaken == false)
            {
                RecipeStatus_SH.transform.position = secondPos.transform.position;
                secondSpotTaken = true;
                spotTaken = 2;
            }
            else
            {
                if (thirdSpotTaken == false)
                {
                    RecipeStatus_SH.transform.position = thirdPos.transform.position;
                    thirdSpotTaken = true;
                    spotTaken = 3;
                }
                else
                {
                    if (fourthSpotTaken == false)
                    {
                        RecipeStatus_SH.transform.position = fourthPos.transform.position;
                        fourthSpotTaken = true;
                        spotTaken = 4;
                    }
                    else
                    {
                        if (fifthSpotTaken == false)
                        {
                            RecipeStatus_SH.transform.position = fifthPos.transform.position;
                            fifthSpotTaken = true;
                            spotTaken = 5;
                        }
                        else
                        {
                            RecipeStatus_SH.transform.position = firstPos.transform.position;
                            firstSpotTaken = true;
                            spotTaken = 1;
                        }
                    }
                }
            }
        }
        //Every Half second it blinks on, then quarter second off, then stays on for four and a half seconds, then turns off
        RecipeStatus_SH.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SH.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SH.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SH.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SH.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SH.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SH.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RecipeStatus_SH.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        RecipeStatus_SH.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        RecipeStatus_SH.SetActive(false);

        //this makes the bool false so another resource can go in that spot when it goes away
        if (spotTaken == 1)
        {
            firstSpotTaken = false;
        }
        else if (spotTaken == 2)
        {
            secondSpotTaken = false;
        }
        else if (spotTaken == 3)
        {
            thirdSpotTaken = false;
        }
        else if (spotTaken == 4)
        {
            fourthSpotTaken = false;
        }
        else if (spotTaken == 5)
        {
            fifthSpotTaken = false;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Resource_Bread")
        {
            Destroy(other.gameObject);
            breadCount++;

            //Semi Auto Rifle
            if(weaponManagerScript.hasWeapon_SemiAutoRifle == false && playerAlreadyShown_SR == false && breadCount >= cookingScript.SR_bread && tomatoCount >= cookingScript.SR_tomato)
            {
                StartCoroutine(UpdateRecipeStatus_SemiAutoRifle());
                playerAlreadyShown_SR = true;
                SFX_recipeReady.Play();
            }
            //Burst Rifle
            if(weaponManagerScript.hasWeapon_BurstRifle == false && playerAlreadyShown_BR == false && breadCount >= cookingScript.BR_bread && tomatoCount >= cookingScript.BR_tomato)
            {
                StartCoroutine(UpdateRecipeStatus_BurstRifle());
                playerAlreadyShown_BR = true;
                SFX_recipeReady.Play();
            }
            //Shotgun
            if(weaponManagerScript.hasWeapon_Shotgun == false && playerAlreadyShown_SG == false && breadCount >= cookingScript.SG_bread && tomatoCount >= cookingScript.SG_tomato)
            {
                StartCoroutine(UpdateRecipeStatusShotgun());
                playerAlreadyShown_SG = true;
                SFX_recipeReady.Play();
            }
        }
        if (other.gameObject.tag == "Resource_Tomato")
        {
            Destroy(other.gameObject);
            tomatoCount++;

            //Semi Auto Rifle
            if (weaponManagerScript.hasWeapon_SemiAutoRifle == false && playerAlreadyShown_SR == false && breadCount >= cookingScript.SR_bread && tomatoCount >= cookingScript.SR_tomato)
            {
                StartCoroutine(UpdateRecipeStatus_SemiAutoRifle());
                playerAlreadyShown_SR = true;
                SFX_recipeReady.Play();
            }
            //Burst Rifle
            if (weaponManagerScript.hasWeapon_BurstRifle == false && playerAlreadyShown_BR == false && breadCount >= cookingScript.BR_bread && tomatoCount >= cookingScript.BR_tomato)
            {
                StartCoroutine(UpdateRecipeStatus_BurstRifle());
                playerAlreadyShown_BR = true;
                SFX_recipeReady.Play();
            }
            //Shotgun
            if (weaponManagerScript.hasWeapon_Shotgun == false && playerAlreadyShown_SG == false && breadCount >= cookingScript.SG_bread && tomatoCount >= cookingScript.SG_tomato)
            {
                StartCoroutine(UpdateRecipeStatusShotgun());
                playerAlreadyShown_SG = true;
                SFX_recipeReady.Play();
            }
            //Shake Speed
            if(specialManagerScript.hasSnack_SpeedBoost == false && playerAlreadyShown_SS == false && tomatoCount >= cookingScript.SS_tomato && cheeseCount >= cookingScript.SS_cheese && onionCount >= cookingScript.SS_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeSpeed());
                playerAlreadyShown_SS = true;
                SFX_recipeReady.Play();
            }
            //Shake Damage
            if (specialManagerScript.hasSnack_DamageBoost == false && playerAlreadyShown_SD == false && tomatoCount >= cookingScript.SD_tomato && cheeseCount >= cookingScript.SD_cheese && onionCount >= cookingScript.SD_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeDamage());
                playerAlreadyShown_SD = true;
                SFX_recipeReady.Play();
            }
            //Shake Health
            if (specialManagerScript.hasSnack_HealthBoost == false && playerAlreadyShown_SH == false && tomatoCount >= cookingScript.SH_tomato && cheeseCount >= cookingScript.SH_cheese && onionCount >= cookingScript.SH_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeHealth());
                playerAlreadyShown_SH = true;
                SFX_recipeReady.Play();
            }
        }
        if (other.gameObject.tag == "Resource_Spaghetti")
        {
            Destroy(other.gameObject);
            spaghettiCount++;

            //Whip Cheese
            if(weaponManagerScript.hasWeapon_SpaghettiWhipCheese == false && playerAlreadyShown_WC == false && spaghettiCount >= cookingScript.WC_spaghetti && cheeseCount >= cookingScript.WC_cheese)
            {
                StartCoroutine(UpdateRecipeStatus_WhipCheese());
                playerAlreadyShown_WC = true;
                SFX_recipeReady.Play();
            }
            //Whip Onion
            if (weaponManagerScript.hasWeapon_SpaghettiWhipOnion == false && playerAlreadyShown_WO == false && spaghettiCount >= cookingScript.WO_spaghetti && onionCount >= cookingScript.WO_onion)
            {
                StartCoroutine(UpdateRecipeStatus_WhipOnion());
                playerAlreadyShown_WO = true;
                SFX_recipeReady.Play();
            }
        }
        if(other.gameObject.tag == "Resource_Cheese")
        {
            Destroy(other.gameObject);
            cheeseCount++;

            //Whip Cheese
            if (weaponManagerScript.hasWeapon_SpaghettiWhipCheese == false && playerAlreadyShown_WC == false && spaghettiCount >= cookingScript.WC_spaghetti && cheeseCount >= cookingScript.WC_cheese)
            {
                StartCoroutine(UpdateRecipeStatus_WhipCheese());
                playerAlreadyShown_WC = true;
                SFX_recipeReady.Play();
            }
            //Shake Speed
            if (specialManagerScript.hasSnack_SpeedBoost == false && playerAlreadyShown_SS == false && tomatoCount >= cookingScript.SS_tomato && cheeseCount >= cookingScript.SS_cheese && onionCount >= cookingScript.SS_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeSpeed());
                playerAlreadyShown_SS = true;
                SFX_recipeReady.Play();
            }
            //Shake Damage
            if (specialManagerScript.hasSnack_DamageBoost == false && playerAlreadyShown_SD == false && tomatoCount >= cookingScript.SD_tomato && cheeseCount >= cookingScript.SD_cheese && onionCount >= cookingScript.SD_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeDamage());
                playerAlreadyShown_SD = true;
                SFX_recipeReady.Play();
            }
            //Shake Health
            if (specialManagerScript.hasSnack_HealthBoost == false && playerAlreadyShown_SH == false && tomatoCount >= cookingScript.SH_tomato && cheeseCount >= cookingScript.SH_cheese && onionCount >= cookingScript.SH_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeHealth());
                playerAlreadyShown_SH = true;
                SFX_recipeReady.Play();
            }
        }
        if(other.gameObject.tag == "Resource_Onion")
        {
            Destroy(other.gameObject);
            onionCount++;

            //Whip Onion
            if (weaponManagerScript.hasWeapon_SpaghettiWhipOnion == false && playerAlreadyShown_WO == false && spaghettiCount >= cookingScript.WO_spaghetti && onionCount >= cookingScript.WO_onion)
            {
                StartCoroutine(UpdateRecipeStatus_WhipOnion());
                playerAlreadyShown_WO = true;
                SFX_recipeReady.Play();
            }
            //Shake Speed
            if (specialManagerScript.hasSnack_SpeedBoost == false && playerAlreadyShown_SS == false && tomatoCount >= cookingScript.SS_tomato && cheeseCount >= cookingScript.SS_cheese && onionCount >= cookingScript.SS_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeSpeed());
                playerAlreadyShown_SS = true;
                SFX_recipeReady.Play();
            }
            //Shake Damage
            if (specialManagerScript.hasSnack_DamageBoost == false && playerAlreadyShown_SD == false && tomatoCount >= cookingScript.SD_tomato && cheeseCount >= cookingScript.SD_cheese && onionCount >= cookingScript.SD_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeDamage());
                playerAlreadyShown_SD = true;
                SFX_recipeReady.Play();
            }
            //Shake Health
            if (specialManagerScript.hasSnack_HealthBoost == false && playerAlreadyShown_SH == false && tomatoCount >= cookingScript.SH_tomato && cheeseCount >= cookingScript.SH_cheese && onionCount >= cookingScript.SH_onion)
            {
                StartCoroutine(UpdateRecipeStatus_ShakeHealth());
                playerAlreadyShown_SH = true;
                SFX_recipeReady.Play();
            }
        }
    }

}
