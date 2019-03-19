using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public int breadCount;
    public int tomatoCount;
    public int spaghettiCount;
    public int cheeseCount;
    public int onionCount;

    public Text breadText;
    public Text tomatoText;
    public Text spaghettiText;
    public Text onionText;
    public Text cheeseText;

    // Start is called before the first frame update
    void Start()
    {
        /*breadCount = 0;           TESTING
        tomatoCount = 0;
        spaghettiCount = 0;
        cheeseCount = 0;
        onionCount = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
        breadText.text = breadCount.ToString();
        tomatoText.text = tomatoCount.ToString();
        spaghettiText.text = spaghettiCount.ToString();
        onionText.text = onionCount.ToString();
        cheeseText.text = cheeseCount.ToString();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Resource_Bread")
        {
            Destroy(other.gameObject);
            breadCount++;
            print("Bread: " + breadCount);
        }
        if (other.gameObject.tag == "Resource_Tomato")
        {
            Destroy(other.gameObject);
            tomatoCount++;
            print("Tomato: " + tomatoCount);
        }
        if (other.gameObject.tag == "Resource_Spaghetti")
        {
            Destroy(other.gameObject);
            spaghettiCount++;
            print("Spaghetti: " + spaghettiCount);
        }
        if(other.gameObject.tag == "Resource_Cheese")
        {
            Destroy(other.gameObject);
            cheeseCount++;
            print("Cheese: " + cheeseCount);
        }
        if(other.gameObject.tag == "Resource_Onion")
        {
            Destroy(other.gameObject);
            onionCount++;
            print("Onion: " + onionCount);
        }
    }

}
