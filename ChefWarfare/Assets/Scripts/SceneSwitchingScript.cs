using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchingScript : MonoBehaviour
{
    public static bool isMac;
    public static bool isXbox;
    private string inputStart;

    public Text text_winner;

    public Text text_FFAScoreP1;
    public Text text_FFAScoreP2;
    public Text text_FFAScoreP3;
    public Text text_FFAScoreP4;

    public Text text_2v2_1v1ScoreRed;
    public Text text_2v2_1v1ScoreBlue;

    public Color[] colors;

    public Image chef_FFA_red;
    public Image chef_FFA_blue;
    public Image chef_FFA_green;
    public Image chef_FFA_orange;

    public Image chef_2v2_red;
    public Image chef_2v2_red2;
    public Image chef_2v2_blue;
    public Image chef_2v2_blue2;

    private void Awake()
    {
        isMac = false;              //NEEDS TO BE TRUE IF A MAC
        //isMac = true;
        //isXbox = false;             //NEEDS TO BE TRUE IF XBOX CONTROLLER
        isXbox = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(isMac == false)
        {
            if(isXbox == true)
            {
                inputStart = "Xbox_Button_Start";
            }
            else if(isXbox == false)
            {
                inputStart = "PS4_Button_Start";
            }
            
        }
        else if(isMac == true)
        {
            if (isXbox == true)
            {
                inputStart = "Xbox_Button_Start_MAC";
            }
            else if (isXbox == false)
            {
                inputStart = "PS4_Button_Start_MAC";
            }
        }

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            LevelLogic.scoreRed = 0;
            LevelLogic.scoreBlue = 0;
            LevelLogic.scoreGreen = 0;
            LevelLogic.scoreOrange = 0;
        }

        if(SceneManager.GetActiveScene().name == "Win")
        {

            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            if (LevelLogic.mode == "FFA")
            {
                text_FFAScoreP1.text = LevelLogic.scoreRed.ToString();
                text_FFAScoreP2.text = LevelLogic.scoreBlue.ToString();
                text_FFAScoreP3.text = LevelLogic.scoreGreen.ToString();
                text_FFAScoreP4.text = LevelLogic.scoreOrange.ToString();

                if (LevelLogic.scoreRed > LevelLogic.scoreBlue && LevelLogic.scoreRed > LevelLogic.scoreGreen && LevelLogic.scoreRed > LevelLogic.scoreOrange)
                {
                    text_winner.text = "Red Player Wins!";
                    text_winner.color = colors[0];
                    chef_FFA_red.enabled = true;
                }
                else if (LevelLogic.scoreBlue > LevelLogic.scoreRed && LevelLogic.scoreBlue > LevelLogic.scoreGreen && LevelLogic.scoreBlue > LevelLogic.scoreOrange)
                {
                    text_winner.text = "Blue Player Wins!";
                    text_winner.color = colors[1];
                    chef_FFA_blue.enabled = true;
                }
                else if (LevelLogic.scoreGreen > LevelLogic.scoreRed && LevelLogic.scoreGreen > LevelLogic.scoreBlue && LevelLogic.scoreGreen > LevelLogic.scoreOrange)
                {
                    text_winner.text = "Green Player Wins!";
                    text_winner.color = colors[2];
                    chef_FFA_green.enabled = true;
                }
                else if (LevelLogic.scoreOrange > LevelLogic.scoreRed && LevelLogic.scoreOrange > LevelLogic.scoreBlue && LevelLogic.scoreOrange > LevelLogic.scoreGreen)
                {
                    text_winner.text = "Orange Player Wins!";
                    text_winner.color = colors[3];
                    chef_FFA_orange.enabled = true;
                }
                else
                {
                    text_winner.text = "Draw!";
                    text_winner.color = Color.white;
                }
            }

            else if(LevelLogic.mode == "2v2")
            {
                text_2v2_1v1ScoreRed.text = LevelLogic.scoreRed.ToString();
                text_2v2_1v1ScoreBlue.text = LevelLogic.scoreBlue.ToString();

                if(LevelLogic.scoreRed > LevelLogic.scoreBlue)
                {
                    text_winner.text = "Red Team Wins!";
                    text_winner.color = colors[0];
                    chef_2v2_red.enabled = true;
                    chef_2v2_red2.enabled = true;
                }
                else if(LevelLogic.scoreBlue > LevelLogic.scoreRed)
                {
                    text_winner.text = "Blue Team Wins!";
                    text_winner.color = colors[1];
                    chef_2v2_blue.enabled = true;
                    chef_2v2_blue2.enabled = true;
                }
                else
                {
                    text_winner.text = "Draw!";
                    text_winner.color = Color.white;
                }

            }
            else if (LevelLogic.mode == "1v1")
            {
                text_2v2_1v1ScoreRed.text = LevelLogic.scoreRed.ToString();
                text_2v2_1v1ScoreBlue.text = LevelLogic.scoreBlue.ToString();

                if (LevelLogic.scoreRed > LevelLogic.scoreBlue)
                {
                    text_winner.text = "Red Player Wins!";
                    text_winner.color = colors[0];
                    chef_FFA_red.enabled = true;
                }
                else if (LevelLogic.scoreBlue > LevelLogic.scoreRed)
                {
                    text_winner.text = "Blue Player Wins!";
                    text_winner.color = colors[1];
                    chef_FFA_blue.enabled = true;
                }
                else
                {
                    text_winner.text = "Draw!";
                    text_winner.color = Color.white;
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
        if (Input.GetButtonDown(inputStart))
        {
            GoToMenu();
        }
        */
    }

    public void GoToGameFFA()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoToGameTeamUp()
    {
        SceneManager.LoadScene("Main_2v2");
    }
    public void GoToGameDuel()
    {
        SceneManager.LoadScene("Main_1v1");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
