using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
    //public variables
    public float gameTimerPre, gameTimerPost, eachGameLength;
    public bool wallsDropped;
    int min, sec;
    public GameObject temporaryWalls;
    public int scoreRed, scoreBlue, scoreGreen, scoreOrange;
    public Text scoreRedText, scoreBlueText, scoreGreenText, scoreOrangeText, TimeText, GameStateText;

    //private variables



    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(wallsDropped == true)
        {
            gameTimerPost -= Time.deltaTime;
            min = Mathf.FloorToInt(gameTimerPost / 60);
            sec = Mathf.FloorToInt(gameTimerPost % 60);
            GameStateText.text = "FIGHT!";
        }
        else
        {
            gameTimerPre -= Time.deltaTime;
            min = Mathf.FloorToInt(gameTimerPre / 60);
            sec = Mathf.FloorToInt(gameTimerPre % 60);
            GameStateText.text = "WALLS";
        }
        
        //if score goes below 0 put it to 0
        if(scoreRed < 0)
        {
            scoreRed = 0;
        }
        if(scoreBlue < 0)
        {
            scoreBlue = 0;
        }
        if(scoreGreen < 0)
        {
            scoreGreen = 0;
        }
        if(scoreOrange < 0)
        {
            scoreOrange = 0;
        }

        //at 5 minutes passed...
        if ((int)gameTimerPre == 0f)
        {
            //drop walls
            if (wallsDropped == false)
            {
                temporaryWalls.SetActive(false);
                wallsDropped = true;
            }
        }

        if((int)gameTimerPost == 0f)
        {
            EndGame();
        }


        TimeText.text = min.ToString("0") + ":" + sec.ToString("00");
        scoreRedText.text = scoreRed.ToString();
        scoreBlueText.text = scoreBlue.ToString();
        scoreGreenText.text = scoreGreen.ToString();
        scoreOrangeText.text = scoreOrange.ToString();
    }

    public void RestartGame()
    {
        eachGameLength = 300f;          //300f = 5 minutes      //180 = 3 minutes
        gameTimerPre = eachGameLength;
        gameTimerPost = eachGameLength;
        wallsDropped = false;
        temporaryWalls.SetActive(true);
        scoreRed = 0;
        scoreBlue = 0;
        scoreGreen = 0;
        scoreOrange = 0;
    }

    public void EndGame()
    {
        print("GAME OVER");
        //go to end game scene
        //show scores in each corner
        //show winner in middle with prized possession- player sprite?
    }
}
