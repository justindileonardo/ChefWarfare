using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        /*breadCount = 0;           TESTING
        tomatoCount = 0;
        spaghettiCount = 0;
        cheeseCount = 0;
        onionCount = 0;*/

        NotInRecipeBook();
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
