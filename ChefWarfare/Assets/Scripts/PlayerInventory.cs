using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    private PlayerMovement myPlayerMovementScript;
    private Cooking cookingScript;

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

    // Start is called before the first frame update
    void Start()
    {
        myPlayerMovementScript = GetComponent<PlayerMovement>();
        cookingScript = GameObject.Find("CookingScript").GetComponent<Cooking>();

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Resource_Bread")
        {
            Destroy(other.gameObject);
            breadCount++;
        }
        if (other.gameObject.tag == "Resource_Tomato")
        {
            Destroy(other.gameObject);
            tomatoCount++;
        }
        if (other.gameObject.tag == "Resource_Spaghetti")
        {
            Destroy(other.gameObject);
            spaghettiCount++;
        }
        if(other.gameObject.tag == "Resource_Cheese")
        {
            Destroy(other.gameObject);
            cheeseCount++;
        }
        if(other.gameObject.tag == "Resource_Onion")
        {
            Destroy(other.gameObject);
            onionCount++;
        }
    }

}
