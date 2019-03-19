using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerP1 : MonoBehaviour
{

    //public variables
    public bool enemySpawnerActive;
    public bool inMyZone;
    public enum EnemyType {Enemy_enum_Bread = 1, Enemy_enum_Tomato = 2, Enemy_enum_Spaghetti = 3, Enemy_enum_Onion = 4, Enemy_enum_Cheese = 5 };
    public EnemyType theEnemyType;
    public Transform enemySpawnLocation;
    public bool enemyReadyToSpawn;
    public GameObject[] enemyPrefabs;

    public Image spawnerBox;
    public Image enemyBread;
    public Image enemyTomato;
    public Image enemySpaghetti;
    public Image enemyOnion;
    public Image enemyCheese;

    //private variables
    private float dpadVertical;
    private float dpadHorizontal;
    private float switchEnemyTypeTimer;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerActive = false;
        inMyZone = false;
        enemyReadyToSpawn = true;
        //sets default enemy type to bread
        theEnemyType = EnemyType.Enemy_enum_Bread;
    }

    // Update is called once per frame
    void Update()
    {
        //axis for dpad Up/Down
        dpadVertical = Input.GetAxisRaw("Xbox_Button_DPAD_Vertical_P1");
        dpadHorizontal = Input.GetAxisRaw("Xbox_Button_DPAD_Horizontal_P1");

        //setting box to red or green for off/on
        if(enemySpawnerActive == true)
        {
            spawnerBox.color = Color.green;
        }
        else
        {
            spawnerBox.color = Color.red;
        }

        //setting enemy in box to enemy currently selected
        if (theEnemyType == EnemyType.Enemy_enum_Bread)
        {
            enemyBread.enabled = true;
            enemyTomato.enabled = false;
            enemySpaghetti.enabled = false;
            enemyOnion.enabled = false;
            enemyCheese.enabled = false;
        }
        else if(theEnemyType == EnemyType.Enemy_enum_Tomato)
        {
            enemyBread.enabled = false;
            enemyTomato.enabled = true;
            enemySpaghetti.enabled = false;
            enemyOnion.enabled = false;
            enemyCheese.enabled = false;
        }
        else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti)
        {
            enemyBread.enabled = false;
            enemyTomato.enabled = false;
            enemySpaghetti.enabled = true;
            enemyOnion.enabled = false;
            enemyCheese.enabled = false;
        }
        else if (theEnemyType == EnemyType.Enemy_enum_Onion)
        {
            enemyBread.enabled = false;
            enemyTomato.enabled = false;
            enemySpaghetti.enabled = false;
            enemyOnion.enabled = true;
            enemyCheese.enabled = false;
        }
        else if (theEnemyType == EnemyType.Enemy_enum_Cheese)
        {
            enemyBread.enabled = false;
            enemyTomato.enabled = false;
            enemySpaghetti.enabled = false;
            enemyOnion.enabled = false;
            enemyCheese.enabled = true;
        }

        //if currently in your respective square
        if (inMyZone == true)
        {
            //Activating/Deactivating spawner
            //click dpad-up, activates spawner
            if (enemySpawnerActive == false && dpadVertical == 1)
            {
                enemySpawnerActive = true;
            }
            //click dpad-down, deactivates spawner
            else if(enemySpawnerActive == true && dpadVertical == -1)
            {
                enemySpawnerActive = false;
            }


            //Switching Enemy Type To Spawn
            //timer - how long in between dpad clicks to switch enemy
            if(switchEnemyTypeTimer >= 0)
            {
                switchEnemyTypeTimer -= Time.deltaTime;
            }
            //if hit right dpad
            if (dpadHorizontal == 1 && switchEnemyTypeTimer < 0)
            {
                switchEnemyTypeTimer = .5f;
                theEnemyType += 1;
                //loops enum back to Bread(1) if player pushes too much to the right
                if(theEnemyType == EnemyType.Enemy_enum_Bread){}
                else if(theEnemyType == EnemyType.Enemy_enum_Tomato){}
                else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti){}
                else if (theEnemyType == EnemyType.Enemy_enum_Onion){}
                else if (theEnemyType == EnemyType.Enemy_enum_Cheese){}
                else{theEnemyType = EnemyType.Enemy_enum_Bread;}
                
            }
            //if hit left dpad
            else if(dpadHorizontal == -1 && switchEnemyTypeTimer < 0)
            {
                switchEnemyTypeTimer = .5f;
                theEnemyType -= 1;
                //loops enum to Cheese(5) if player pushes too much to the left
                if (theEnemyType == EnemyType.Enemy_enum_Bread){}
                else if (theEnemyType == EnemyType.Enemy_enum_Tomato){}
                else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti){}
                else if (theEnemyType == EnemyType.Enemy_enum_Onion){}
                else if (theEnemyType == EnemyType.Enemy_enum_Cheese){}
                else {theEnemyType = EnemyType.Enemy_enum_Cheese;}
            }


            //Spawning Enemies

            if(enemySpawnerActive == true && enemyReadyToSpawn == true)
            {
                enemyReadyToSpawn = false;
                if(theEnemyType == EnemyType.Enemy_enum_Bread)
                {
                    Instantiate(enemyPrefabs[0], enemySpawnLocation.transform.position, Quaternion.identity);
                }
                else if(theEnemyType == EnemyType.Enemy_enum_Tomato)
                {
                    Instantiate(enemyPrefabs[1], enemySpawnLocation.transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti)
                {
                    Instantiate(enemyPrefabs[2], enemySpawnLocation.transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Onion)
                {
                    Instantiate(enemyPrefabs[3], enemySpawnLocation.transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Cheese)
                {
                    Instantiate(enemyPrefabs[4], enemySpawnLocation.transform.position, Quaternion.identity);
                }
            }


        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1" && inMyZone == false)
        {
            inMyZone = true;
        }

        //Enemy types, when enemy spawns
        if(other.gameObject.tag == "Enemy_Bread" && enemyReadyToSpawn == true)
        {
            enemyReadyToSpawn = false;
        }
        if (other.gameObject.tag == "Enemy_Tomato" && enemyReadyToSpawn == true)
        {
            enemyReadyToSpawn = false;
        }
        if (other.gameObject.tag == "Enemy_Spaghetti" && enemyReadyToSpawn == true)
        {
            enemyReadyToSpawn = false;
        }
        if (other.gameObject.tag == "Enemy_Onion" && enemyReadyToSpawn == true)
        {
            enemyReadyToSpawn = false;
        }
        if (other.gameObject.tag == "Enemy_Cheese" && enemyReadyToSpawn == true)
        {
            enemyReadyToSpawn = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1" && inMyZone == true)
        {
            inMyZone = false;
            enemySpawnerActive = false;
        }

        //Enemy types, when enemy dies
        if (other.gameObject.tag == "Enemy_Bread" && enemyReadyToSpawn == false)
        {
            enemyReadyToSpawn = true;
        }
        if (other.gameObject.tag == "Enemy_Tomato" && enemyReadyToSpawn == false)
        {
            enemyReadyToSpawn = true;
        }
        if (other.gameObject.tag == "Enemy_Spaghetti" && enemyReadyToSpawn == false)
        {
            enemyReadyToSpawn = true;
        }
        if (other.gameObject.tag == "Enemy_Onion" && enemyReadyToSpawn == false)
        {
            enemyReadyToSpawn = true;
        }
        if (other.gameObject.tag == "Enemy_Cheese" && enemyReadyToSpawn == false)
        {
            enemyReadyToSpawn = true;
        }
    }

}
