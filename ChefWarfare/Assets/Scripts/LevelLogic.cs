using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    //public variables
    public float gameTimer, gameLength;
    public bool wallsDropped;
    public GameObject temporaryWalls;
    public int scoreRed, scoreBlue, scoreGreen, scoreOrange;

    //private variables



    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {

        gameTimer -= Time.deltaTime;

        //at 5 minutes passed...
        if ((int)gameTimer == 300f)          //300f = 5 minutes
        {
            //drop walls
            if (wallsDropped == false)
            {
                temporaryWalls.SetActive(false);
                wallsDropped = true;
            }
        }
    }

    public void RestartGame()
    {
        gameLength = 600f;          //600f = 10 minutes
        gameTimer = gameLength;
        wallsDropped = false;
        temporaryWalls.SetActive(true);
        scoreRed = 0;
        scoreBlue = 0;
        scoreGreen = 0;
        scoreOrange = 0;
    }
}
