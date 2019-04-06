using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{

    private PlayerStatus myPlayerStatusScript;
    private PlayerMovement myPlayerMovementScript;
    private PlayerInventory myPlayerInventoryScript;

    private Vector3 playerStartPosWhenEnteringCookingStation;

    private EnemySpawnerP1 ESP1;
    private EnemySpawnerP2 ESP2;
    private EnemySpawnerP3 ESP3;
    private EnemySpawnerP4 ESP4;

    public GameObject recipeBookImage;


    private string inputB;
    private string inputA;
    [SerializeField] private bool onCookingStation;
    private LevelLogic levelLogicScript;

    // Start is called before the first frame update
    void Start()
    {
        onCookingStation = false;
        recipeBookImage.SetActive(false);
        ESP1 = GameObject.Find("EnemySpawnerP1").GetComponent<EnemySpawnerP1>();
        ESP2 = GameObject.Find("EnemySpawnerP2").GetComponent<EnemySpawnerP2>();
        ESP3 = GameObject.Find("EnemySpawnerP3").GetComponent<EnemySpawnerP3>();
        ESP4 = GameObject.Find("EnemySpawnerP4").GetComponent<EnemySpawnerP4>();
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        //disables cooking station
        if (onCookingStation == true && Input.GetButtonDown(inputB))
        {
            StartCoroutine(ExitCookingStationDelay());
        }

        if(onCookingStation == true)
        {
            myPlayerStatusScript.moveSpeed = 0;
            myPlayerMovementScript.transform.position = playerStartPosWhenEnteringCookingStation;
        }

    }


    IEnumerator EnterCookingStationDelay()
    {
        yield return new WaitForSeconds(0.05f);
        onCookingStation = true;
        recipeBookImage.SetActive(true);
        myPlayerStatusScript.canMove = false;
        myPlayerStatusScript.moveSpeed = 0;
        playerStartPosWhenEnteringCookingStation = myPlayerMovementScript.transform.position;

        if (myPlayerMovementScript.player1)
        {
            ESP1.InRecipeBook();
            myPlayerInventoryScript.InRecipeBook();
            //makes first box highlighted
            levelLogicScript.es1.SetSelectedGameObject(null);
            levelLogicScript.es1.SetSelectedGameObject(levelLogicScript.es1_firstSelected);
        }
        else if (myPlayerMovementScript.player2)
        {
            ESP2.InRecipeBook();
            myPlayerInventoryScript.InRecipeBook();
            //makes first box highlighted
            levelLogicScript.es2.SetSelectedGameObject(null);
            levelLogicScript.es2.SetSelectedGameObject(levelLogicScript.es2_firstSelected);
        }
        else if (myPlayerMovementScript.player3)
        {
            ESP3.InRecipeBook();
            myPlayerInventoryScript.InRecipeBook();
            //makes first box highlighted
            levelLogicScript.es3.SetSelectedGameObject(null);
            levelLogicScript.es3.SetSelectedGameObject(levelLogicScript.es3_firstSelected);
        }
        else if (myPlayerMovementScript.player4)
        {
            ESP4.InRecipeBook();
            myPlayerInventoryScript.InRecipeBook();
            //makes first box highlighted
            levelLogicScript.es4.SetSelectedGameObject(null);
            levelLogicScript.es4.SetSelectedGameObject(levelLogicScript.es4_firstSelected);
        }

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator ExitCookingStationDelay()
    {
        yield return new WaitForSeconds(0.2f);
        onCookingStation = false;
        recipeBookImage.SetActive(false);
        myPlayerStatusScript.canMove = true;
        myPlayerStatusScript.moveSpeed = myPlayerStatusScript.moveSpeedDefault;

        if (myPlayerMovementScript.player1)
        {
            ESP1.NotInRecipeBook();
            myPlayerInventoryScript.NotInRecipeBook();
        }
        else if (myPlayerMovementScript.player2)
        {
            ESP2.NotInRecipeBook();
            myPlayerInventoryScript.NotInRecipeBook();
        }
        else if (myPlayerMovementScript.player3)
        {
            ESP3.NotInRecipeBook();
            myPlayerInventoryScript.NotInRecipeBook();
        }
        else if (myPlayerMovementScript.player4)
        {
            ESP4.NotInRecipeBook();
            myPlayerInventoryScript.NotInRecipeBook();
        }

        yield return new WaitForSeconds(0.5f);
    }

    public void ExitCookingStationDelayFunction()
    {
        StartCoroutine(ExitCookingStationDelay());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //sets the player when a player hits the cooking station
            myPlayerStatusScript = other.gameObject.GetComponent<PlayerStatus>();
            myPlayerMovementScript = other.gameObject.GetComponent<PlayerMovement>();
            myPlayerInventoryScript = other.gameObject.GetComponent<PlayerInventory>();

            //sets the input to correct player input
            if(other.gameObject.GetComponent<PlayerMovement>().isMac == false)
            {
                if(other.gameObject.GetComponent<PlayerMovement>().player1 == true)
                {
                    inputB = "Xbox_Button_B_P1";
                    inputA = "Xbox_Button_A_P1";
                }
            else if (other.gameObject.GetComponent<PlayerMovement>().player2 == true)
                {
                    inputB = "Xbox_Button_B_P2";
                    inputA = "Xbox_Button_A_P2";
                }
                else if (other.gameObject.GetComponent<PlayerMovement>().player3 == true)
                {
                    inputB = "Xbox_Button_B_P3";
                    inputA = "Xbox_Button_A_P3";
                }
                else if (other.gameObject.GetComponent<PlayerMovement>().player4 == true)
                {
                    inputB = "Xbox_Button_B_P4";
                    inputA = "Xbox_Button_A_P4";

                }
            }
            else if (other.gameObject.GetComponent<PlayerMovement>().isMac == true)
            {
                if (other.gameObject.GetComponent<PlayerMovement>().player1 == true)
                {
                    inputB = "Xbox_Button_B_P1_MAC";
                    inputA = "Xbox_Button_A_P1_MAC";
                }
                else if (other.gameObject.GetComponent<PlayerMovement>().player2 == true)
                {
                    inputB = "Xbox_Button_B_P2_MAC";
                    inputA = "Xbox_Button_A_P2_MAC";
                }
                else if (other.gameObject.GetComponent<PlayerMovement>().player3 == true)
                {
                    inputB = "Xbox_Button_B_P3_MAC";
                    inputA = "Xbox_Button_A_P3_MAC";
                }
                else if (other.gameObject.GetComponent<PlayerMovement>().player4 == true)
                {
                    inputB = "Xbox_Button_B_P4_MAC";
                    inputA = "Xbox_Button_A_P4_MAC";

                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //enables cooking station
            if(onCookingStation == false && Input.GetButtonDown(inputB))
            {
                StartCoroutine(EnterCookingStationDelay());
            }
        }
    }
}
