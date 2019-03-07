using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{

    public PlayerStatus myPlayerStatusScript;

    public GameObject recipeBookImage;

    [SerializeField] private bool onCookingStation;

    // Start is called before the first frame update
    void Start()
    {
        onCookingStation = false;
        recipeBookImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //disables cooking station
        if (onCookingStation == true && Input.GetButtonDown("Xbox_Button_B_P1"))
        {
            StartCoroutine(ExitCookingStationDelay());
        }

    }


    IEnumerator EnterCookingStationDelay()
    {
        yield return new WaitForSeconds(0.05f);
        print("Enter 1");
        onCookingStation = true;
        recipeBookImage.SetActive(true);
        myPlayerStatusScript.canMove = false;
        myPlayerStatusScript.moveSpeed = 0;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator ExitCookingStationDelay()
    {
        yield return new WaitForSeconds(0.25f);
        print("exit 1");
        onCookingStation = false;
        recipeBookImage.SetActive(false);
        myPlayerStatusScript.canMove = true;
        myPlayerStatusScript.moveSpeed = myPlayerStatusScript.moveSpeedDefault;
        yield return new WaitForSeconds(0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {
            //sets the player when a player hits the cooking station
            myPlayerStatusScript = other.gameObject.GetComponent<PlayerStatus>();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {
            //enables cooking station
            if(onCookingStation == false && Input.GetButtonDown("Xbox_Button_B_P1"))
            {
                StartCoroutine(EnterCookingStationDelay());
            }
        }
    }
}
