using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelLogic : MonoBehaviour
{
    //public variables
    public float gameTimerPre, gameTimerPost, eachGameLength;
    public bool wallsDropped;
    int min, sec;
    public GameObject temporaryWalls;
    public int scoreRed, scoreBlue, scoreGreen, scoreOrange;
    public Text scoreRedText, scoreBlueText, scoreGreenText, scoreOrangeText, TimeText, GameStateText;

    //Event System first button not highlighting initially
    [HideInInspector] public EventSystem es1;
    [HideInInspector] public EventSystem es2;
    [HideInInspector] public EventSystem es3;
    [HideInInspector] public EventSystem es4;
    public GameObject es1_firstSelected;
    public GameObject es2_firstSelected;
    public GameObject es3_firstSelected;
    public GameObject es4_firstSelected;

    //Audio
    public AudioSource SFX_10SecsAndWallsDrop;
    public AudioSource SFX_10Secs;

    private bool sfx_10sawd_played;
    private bool sfx_10s_played;

    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
        es1 = GameObject.Find("EventSystem1").GetComponent<EventSystem>();
        es2 = GameObject.Find("EventSystem2").GetComponent<EventSystem>();
        es3 = GameObject.Find("EventSystem3").GetComponent<EventSystem>();
        es4 = GameObject.Find("EventSystem4").GetComponent<EventSystem>();
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

        //at 10 seconds before walls...
        if((int)gameTimerPre == 10f)
        {
            if(wallsDropped == false && sfx_10sawd_played == false)
            {
                sfx_10sawd_played = true;
                SFX_10SecsAndWallsDrop.Play();
            }
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

        //at 10 seconds left in game...
        if((int)gameTimerPost == 10f)
        {
            if(sfx_10s_played == false)
            {
                sfx_10s_played = true;
                SFX_10Secs.Play();
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
        sfx_10sawd_played = false;
        sfx_10s_played = false;
    }

    public void EndGame()
    {
        print("GAME OVER");
        SceneManager.LoadScene("MainMenu");
        //go to end game scene
        //show scores in each corner
        //show winner in middle with prized possession- player sprite?
    }
}
