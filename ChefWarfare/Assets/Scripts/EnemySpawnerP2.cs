﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerP2 : MonoBehaviour
{

    //public variables
    public bool enemySpawnerActive;
    public bool inMyZone;
    public enum EnemyType { Enemy_enum_Bread = 1, Enemy_enum_Tomato = 2, Enemy_enum_Spaghetti = 3, Enemy_enum_Onion = 4, Enemy_enum_Cheese = 5 };
    public EnemyType theEnemyType;
    public Transform[] enemySpawnLocation;
    public bool enemyReadyToSpawn;
    public GameObject[] enemyPrefabs;

    public Image spawnerBox;
    public Image enemyBread;
    public Image enemyTomato;
    public Image enemySpaghetti;
    public Image enemyOnion;
    public Image enemyCheese;

    public PlayerMovement playerMovementScript;

    public List<GameObject> EnemiesAliveInZone = new List<GameObject>();

    //private variables
    private float dpadVertical;
    private float dpadHorizontal;
    private float switchEnemyTypeTimer;

    public float enemySpawnTimer;
    private float enemySpawnLength;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerActive = false;
        inMyZone = false;
        enemyReadyToSpawn = false;
        //sets default enemy type to bread
        theEnemyType = EnemyType.Enemy_enum_Bread;
        playerMovementScript = GameObject.Find("Player2").GetComponent<PlayerMovement>();
        enemySpawnTimer = 0;
        enemySpawnLength = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.isMac == false)
        {
            //axis for dpad Up/Down
            dpadVertical = Input.GetAxisRaw("Xbox_Button_DPAD_Vertical_P2");
            dpadHorizontal = Input.GetAxisRaw("Xbox_Button_DPAD_Horizontal_P2");
        }
        /*else if(playerMovementScript.isMac == true)
        {
            //axis for dpad Up/Down
            dpadVertical = Input.GetAxisRaw("Xbox_Button_DPAD_Vertical_P1_MAC");
            dpadHorizontal = Input.GetAxisRaw("Xbox_Button_DPAD_Horizontal_P1");
        }*/



        //setting box to red or green for off/on
        if (enemySpawnerActive == true)
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
        else if (theEnemyType == EnemyType.Enemy_enum_Tomato)
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
            if (playerMovementScript.isMac == false)
            {
                //Activating/Deactivating spawner
                //click dpad-up, activates spawner
                if (enemySpawnerActive == false && dpadVertical == 1)
                {
                    enemySpawnerActive = true;
                }
                //click dpad-down, deactivates spawner
                else if (enemySpawnerActive == true && dpadVertical == -1)
                {
                    enemySpawnerActive = false;
                }


                //Switching Enemy Type To Spawn
                //timer - how long in between dpad clicks to switch enemy
                if (switchEnemyTypeTimer >= 0)
                {
                    switchEnemyTypeTimer -= Time.deltaTime;
                }
                //if hit right dpad
                if (dpadHorizontal == 1 && switchEnemyTypeTimer < 0)
                {
                    switchEnemyTypeTimer = .5f;
                    theEnemyType += 1;
                    //loops enum back to Bread(1) if player pushes too much to the right
                    if (theEnemyType == EnemyType.Enemy_enum_Bread) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Tomato) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Onion) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Cheese) { }
                    else { theEnemyType = EnemyType.Enemy_enum_Bread; }

                }
                //if hit left dpad
                else if (dpadHorizontal == -1 && switchEnemyTypeTimer < 0)
                {
                    switchEnemyTypeTimer = .5f;
                    theEnemyType -= 1;
                    //loops enum to Cheese(5) if player pushes too much to the left
                    if (theEnemyType == EnemyType.Enemy_enum_Bread) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Tomato) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Onion) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Cheese) { }
                    else { theEnemyType = EnemyType.Enemy_enum_Cheese; }
                }

            }

            else if (playerMovementScript.isMac == true)
            {
                //Activating/Deactivating spawner
                //click dpad-up, activates spawner
                if (enemySpawnerActive == false && Input.GetButtonDown("Xbox_Button_DPAD_VerticalUp_P2_MAC"))
                {
                    enemySpawnerActive = true;
                }
                //click dpad-down, deactivates spawner
                else if (enemySpawnerActive == true && Input.GetButtonDown("Xbox_Button_DPAD_VerticalDown_P2_MAC"))
                {
                    enemySpawnerActive = false;
                }


                //Switching Enemy Type To Spawn
                //timer - how long in between dpad clicks to switch enemy
                if (switchEnemyTypeTimer >= 0)
                {
                    switchEnemyTypeTimer -= Time.deltaTime;
                }
                //if hit right dpad
                if (Input.GetButtonDown("Xbox_Button_DPAD_HorizontalRight_P2_MAC") && switchEnemyTypeTimer < 0)
                {
                    switchEnemyTypeTimer = .5f;
                    theEnemyType += 1;
                    //loops enum back to Bread(1) if player pushes too much to the right
                    if (theEnemyType == EnemyType.Enemy_enum_Bread) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Tomato) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Onion) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Cheese) { }
                    else { theEnemyType = EnemyType.Enemy_enum_Bread; }

                }
                //if hit left dpad
                else if (Input.GetButtonDown("Xbox_Button_DPAD_HorizontalLeft_P2_MAC") && switchEnemyTypeTimer < 0)
                {
                    switchEnemyTypeTimer = .5f;
                    theEnemyType -= 1;
                    //loops enum to Cheese(5) if player pushes too much to the left
                    if (theEnemyType == EnemyType.Enemy_enum_Bread) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Tomato) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Onion) { }
                    else if (theEnemyType == EnemyType.Enemy_enum_Cheese) { }
                    else { theEnemyType = EnemyType.Enemy_enum_Cheese; }
                }

            }

            if (enemySpawnTimer > 0 && enemySpawnerActive == true && enemyReadyToSpawn == false)
            {
                enemySpawnTimer -= Time.deltaTime;
            }

            if (enemySpawnTimer <= 0 && enemySpawnerActive == true && enemyReadyToSpawn == false)
            {
                enemySpawnTimer = enemySpawnLength;
                enemyReadyToSpawn = true;
            }


            //Spawning Enemies

            if (enemySpawnerActive == true && enemyReadyToSpawn == true)
            {
                int randomSpawnLocationInt = Random.Range(0, enemySpawnLocation.Length);
                enemyReadyToSpawn = false;
                if (theEnemyType == EnemyType.Enemy_enum_Bread)
                {
                    Instantiate(enemyPrefabs[0], enemySpawnLocation[randomSpawnLocationInt].transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Tomato)
                {
                    Instantiate(enemyPrefabs[1], enemySpawnLocation[randomSpawnLocationInt].transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Spaghetti)
                {
                    Instantiate(enemyPrefabs[2], enemySpawnLocation[randomSpawnLocationInt].transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Onion)
                {
                    Instantiate(enemyPrefabs[3], enemySpawnLocation[randomSpawnLocationInt].transform.position, Quaternion.identity);
                }
                else if (theEnemyType == EnemyType.Enemy_enum_Cheese)
                {
                    Instantiate(enemyPrefabs[4], enemySpawnLocation[randomSpawnLocationInt].transform.position, Quaternion.identity);
                }
            }


        }

    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in EnemiesAliveInZone)
        {
            Destroy(enemy);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player2" && inMyZone == false)
        {
            inMyZone = true;
        }

        //Enemy types, when enemy spawns
        if (other.gameObject.tag == "Enemy_Bread" /*&& enemyReadyToSpawn == true*/)
        {
            //enemyReadyToSpawn = false;
            EnemiesAliveInZone.Add(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy_Tomato" /*&& enemyReadyToSpawn == true*/)
        {
            //enemyReadyToSpawn = false;
            EnemiesAliveInZone.Add(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy_Spaghetti" /*&& enemyReadyToSpawn == true*/)
        {
            //enemyReadyToSpawn = false;
            EnemiesAliveInZone.Add(other.gameObject);

        }
        if (other.gameObject.tag == "Enemy_Onion" /*&& enemyReadyToSpawn == true*/)
        {
            //enemyReadyToSpawn = false;
            EnemiesAliveInZone.Add(other.gameObject);

        }
        if (other.gameObject.tag == "Enemy_Cheese" /*&& enemyReadyToSpawn == true*/)
        {
            //enemyReadyToSpawn = false;
            EnemiesAliveInZone.Add(other.gameObject);

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player2" && inMyZone == true)
        {
            inMyZone = false;
            enemySpawnerActive = false;
        }

        /*//Enemy types, when enemy dies
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
        }*/
    }

}
