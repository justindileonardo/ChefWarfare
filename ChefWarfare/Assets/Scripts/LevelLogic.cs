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
    public static int scoreRed, scoreBlue, scoreGreen, scoreOrange;
    public Text scoreRedText, scoreBlueText, scoreGreenText, scoreOrangeText, TimeText, GameStateText, GameStateText2;

    private PlayerMovement thePlayer1;

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
    public AudioSource MUSIC;

    private bool sfx_10sawd_played;
    private bool sfx_10s_played;

    public bool gameIsPaused;

    private float horizontalInput1;
    private float horizontalInput2;
    private float horizontalInput3;
    private float horizontalInput4;

    private float verticalInput1;
    private float verticalInput2;
    private float verticalInput3;
    private float verticalInput4;

    public GameObject PauseMenu;

    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public EventSystem pauseEventSystem;
    public EventSystem eventSystem1, eventSystem2, eventSystem3, eventSystem4;
    public GameObject resumeButton;

    public static string mode;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            mode = "FFA";
        }
        else if (SceneManager.GetActiveScene().name == "Main_2v2")
        {
            mode = "2v2";
        }
        else if (SceneManager.GetActiveScene().name == "Main_1v1")
        {
            mode = "1v1";
        }
        Debug.Log(mode);
        RestartGame();
        es1 = GameObject.Find("EventSystem1").GetComponent<EventSystem>();
        es2 = GameObject.Find("EventSystem2").GetComponent<EventSystem>();
        es3 = GameObject.Find("EventSystem3").GetComponent<EventSystem>();
        es4 = GameObject.Find("EventSystem4").GetComponent<EventSystem>();

        thePlayer1 = GameObject.Find("Player1").GetComponent<PlayerMovement>();
        gameIsPaused = false;
        PauseMenu.SetActive(false);
        pauseEventSystem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {



        if(thePlayer1.isMac == false)
        {
            if(SceneSwitchingScript.isXbox == true)
            {
                if (Input.GetButtonDown("Xbox_Button_Start") && gameIsPaused == false)
                {
                    //pause game
                    Time.timeScale = 0;
                    gameIsPaused = true;
                    PauseMenu.SetActive(true);
                    eventSystem1.enabled = false;
                    eventSystem2.enabled = false;
                    eventSystem3.enabled = false;
                    eventSystem4.enabled = false;
                    pauseEventSystem.enabled = true;
                    pauseEventSystem.SetSelectedGameObject(resumeButton);
                    MUSIC.Pause();
                    if (SFX_10SecsAndWallsDrop.isPlaying == true)
                    {
                        SFX_10SecsAndWallsDrop.Pause();
                    }
                    if (SFX_10Secs.isPlaying == true)
                    {
                        SFX_10Secs.Pause();
                    }
                }
                else if (Input.GetButtonDown("Xbox_Button_Start") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
                else if (Input.GetButtonDown("Xbox_Button_B_ALL") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
            }
            else if(SceneSwitchingScript.isXbox == false)
            {
                if (Input.GetButtonDown("PS4_Button_Start") && gameIsPaused == false)
                {
                    //pause game
                    Time.timeScale = 0;
                    gameIsPaused = true;
                    PauseMenu.SetActive(true);
                    eventSystem1.enabled = false;
                    eventSystem2.enabled = false;
                    eventSystem3.enabled = false;
                    eventSystem4.enabled = false;
                    pauseEventSystem.enabled = true;
                    pauseEventSystem.SetSelectedGameObject(resumeButton);
                    MUSIC.Pause();
                    if (SFX_10SecsAndWallsDrop.isPlaying == true)
                    {
                        SFX_10SecsAndWallsDrop.Pause();
                    }
                    if (SFX_10Secs.isPlaying == true)
                    {
                        SFX_10Secs.Pause();
                    }
                }
                else if (Input.GetButtonDown("PS4_Button_Start") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
                else if (Input.GetButtonDown("PS4_Button_B_ALL") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
            }
        
        }
            
        else if (thePlayer1.isMac == true)
        {
            if(SceneSwitchingScript.isXbox == true)
            {
                if (Input.GetButtonDown("Xbox_Button_Start_MAC") && gameIsPaused == false)
                {
                    //pause game
                    Time.timeScale = 0;
                    gameIsPaused = true;
                    PauseMenu.SetActive(true);
                    eventSystem1.enabled = false;
                    eventSystem2.enabled = false;
                    eventSystem3.enabled = false;
                    eventSystem4.enabled = false;
                    pauseEventSystem.enabled = true;
                    pauseEventSystem.SetSelectedGameObject(resumeButton);
                    MUSIC.Pause();
                    if(SFX_10SecsAndWallsDrop.isPlaying == true)
                    {
                        SFX_10SecsAndWallsDrop.Pause();
                    }
                    if(SFX_10Secs.isPlaying == true)
                    {
                        SFX_10Secs.Pause();
                    }
                }
                else if (Input.GetButtonDown("Xbox_Button_Start_MAC") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if(gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if(gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
                else if (Input.GetButtonDown("Xbox_Button_B_ALL_MAC") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
            }
            else if(SceneSwitchingScript.isXbox == false)
            {
                if (Input.GetButtonDown("PS4_Button_Start") && gameIsPaused == false)
                {
                    //pause game
                    Time.timeScale = 0;
                    gameIsPaused = true;
                    PauseMenu.SetActive(true);
                    eventSystem1.enabled = false;
                    eventSystem2.enabled = false;
                    eventSystem3.enabled = false;
                    eventSystem4.enabled = false;
                    pauseEventSystem.enabled = true;
                    pauseEventSystem.SetSelectedGameObject(resumeButton);
                    MUSIC.Pause();
                    if (SFX_10SecsAndWallsDrop.isPlaying == true)
                    {
                        SFX_10SecsAndWallsDrop.Pause();
                    }
                    if (SFX_10Secs.isPlaying == true)
                    {
                        SFX_10Secs.Pause();
                    }
                }
                else if (Input.GetButtonDown("PS4_Button_Start") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
                else if (Input.GetButtonDown("PS4_Button_B_ALL") && gameIsPaused == true)
                {
                    Time.timeScale = 1;
                    gameIsPaused = false;
                    PauseMenu.SetActive(false);
                    pauseEventSystem.enabled = false;
                    eventSystem1.enabled = true;
                    eventSystem2.enabled = true;
                    eventSystem3.enabled = true;
                    eventSystem4.enabled = true;
                    MUSIC.UnPause();
                    if (gameTimerPre <= 10f && gameTimerPre > 0)
                    {
                        SFX_10SecsAndWallsDrop.UnPause();
                    }
                    if (gameTimerPost <= 10f && gameTimerPost > 0)
                    {
                        SFX_10Secs.UnPause();
                    }
                }
            }

        }



        if (wallsDropped == true)
        {
            gameTimerPost -= Time.deltaTime;
            min = Mathf.FloorToInt(gameTimerPost / 60);
            sec = Mathf.FloorToInt(gameTimerPost % 60);
            GameStateText.text = "FIGHT!";
            if (mode == "1v1")
            {
                GameStateText2.text = "FIGHT!";
            }
            
        }
        else
        {
            gameTimerPre -= Time.deltaTime;
            min = Mathf.FloorToInt(gameTimerPre / 60);
            sec = Mathf.FloorToInt(gameTimerPre % 60);
            GameStateText.text = "WALLS";
            if (mode == "1v1")
            {
                GameStateText2.text = "FIGHT!";
            }
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

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        PauseMenu.SetActive(false);
        pauseEventSystem.enabled = false;
        eventSystem1.enabled = true;
        eventSystem2.enabled = true;
        eventSystem3.enabled = true;
        eventSystem4.enabled = true;
        MUSIC.UnPause();
        if (gameTimerPre <= 10f && gameTimerPre > 0)
        {
            SFX_10SecsAndWallsDrop.UnPause();
        }
        if (gameTimerPost <= 10f && gameTimerPost > 0)
        {
            SFX_10Secs.UnPause();
        }
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
        SceneManager.LoadScene("Win");
        //go to end game scene
        //show scores in each corner
        //show winner in middle with prized possession- player sprite?
    }
}
