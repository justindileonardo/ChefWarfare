using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    private string inputB;
    private bool selectingMode, lookingAtControls, viewingTutorial;

    public GameObject PlayButton;
    public GameObject TutorialButton;
    public GameObject ControlsButton;
    public GameObject QuitButton;

    public GameObject BackToMenuButton;

    public GameObject ModeFFAButton;
    public GameObject ModeTeamUpButton;
    public GameObject ModeDuelButton;

    public GameObject ControlsImage;
    public GameObject ControlsImagePS;

    public GameObject Title;
    public GameObject Credits;

    public GameObject TutorialBackToMenuButton;
    public GameObject TutorialPreviousButton;
    public GameObject TutorialNextButton;

    public Image[] TutorialScreenshots;
    private int tutorialStatus;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneSwitchingScript.isMac == false)
        {
            if(SceneSwitchingScript.isXbox == true)
            {
                inputB = "Xbox_Button_B_ALL";
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                inputB = "PS4_Button_B_ALL";
            }

        }
        else if(SceneSwitchingScript.isMac == true)
        {
            if (SceneSwitchingScript.isXbox == true)
            {
                inputB = "Xbox_Button_B_ALL_MAC";
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                inputB = "PS4_Button_B_ALL";
            }
        }

        selectingMode = false;
        lookingAtControls = false;

        PlayButton.SetActive(true);
        TutorialButton.SetActive(true);
        ControlsButton.SetActive(true);
        QuitButton.SetActive(true);

        BackToMenuButton.SetActive(false);

        ModeFFAButton.SetActive(false);
        ModeTeamUpButton.SetActive(false);
        ModeDuelButton.SetActive(false);

        if(SceneSwitchingScript.isXbox == true)
        {
            ControlsImage.SetActive(false);
        }
        else if (SceneSwitchingScript.isXbox == false)
        {
            ControlsImagePS.SetActive(false);
        }

        PlayButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(inputB))
        {
            if(selectingMode == true || lookingAtControls == true)
            {
                ClickBackToMenuButton();
            }
        }
    }

    public void ClickPlayButton()
    {
        selectingMode = true;

        PlayButton.SetActive(false);
        TutorialButton.SetActive(false);
        ControlsButton.SetActive(false);
        QuitButton.SetActive(false);

        ModeFFAButton.SetActive(true);
        ModeTeamUpButton.SetActive(true);
        ModeDuelButton.SetActive(true);
        BackToMenuButton.SetActive(true);

        ModeFFAButton.GetComponent<Button>().Select();
    }

    public void ClickControlsButton()
    {
        lookingAtControls = true;

        PlayButton.SetActive(false);
        TutorialButton.SetActive(false);
        ControlsButton.SetActive(false);
        QuitButton.SetActive(false);

        BackToMenuButton.SetActive(true);

        if (SceneSwitchingScript.isXbox == true)
        {
            ControlsImage.SetActive(true);
        }
        else if (SceneSwitchingScript.isXbox == false)
        {
            ControlsImagePS.SetActive(true);
        }

        BackToMenuButton.GetComponent<Button>().Select();
    }

    public void ClickBackToMenuButton()
    {
        selectingMode = false;
        lookingAtControls = false;
        viewingTutorial = false;

        PlayButton.SetActive(true);
        TutorialButton.SetActive(true);
        ControlsButton.SetActive(true);
        QuitButton.SetActive(true);

        BackToMenuButton.SetActive(false);

        ModeFFAButton.SetActive(false);
        ModeTeamUpButton.SetActive(false);
        ModeDuelButton.SetActive(false);

        TutorialBackToMenuButton.SetActive(false);
        TutorialPreviousButton.SetActive(false);
        TutorialNextButton.SetActive(false);

        if (SceneSwitchingScript.isXbox == true)
        {
            ControlsImage.SetActive(false);
        }
        else if (SceneSwitchingScript.isXbox == false)
        {
            ControlsImagePS.SetActive(false);
        }

        Title.SetActive(true);
        Credits.SetActive(true);

        for (int i = 0; i < TutorialScreenshots.Length; i++)
        {
            TutorialScreenshots[i].enabled = false;
        }

        tutorialStatus = 0;

        PlayButton.GetComponent<Button>().Select();
    }

    public void ClickTutorialButton()
    {
        viewingTutorial = true;

        Title.SetActive(false);
        Credits.SetActive(false);

        PlayButton.SetActive(false);
        TutorialButton.SetActive(false);
        ControlsButton.SetActive(false);
        QuitButton.SetActive(false);

        TutorialBackToMenuButton.SetActive(true);
        TutorialPreviousButton.SetActive(true);
        TutorialNextButton.SetActive(true);

        TutorialNextButton.GetComponent<Button>().Select();

        tutorialStatus = 1;
        TutorialScreenshots[0].enabled = true;

        if (SceneSwitchingScript.isXbox == true)
        {
            
        }
        else if (SceneSwitchingScript.isXbox == false)
        {
            
        }

        
    }

    public void ClickTutorialPrevious()
    {
        if(tutorialStatus == 2)
        {
            TutorialScreenshots[1].enabled = false;
            TutorialScreenshots[2].enabled = false;

            TutorialScreenshots[0].enabled = true;

            tutorialStatus = 1;
        }
        else if (tutorialStatus == 3)
        {
            TutorialScreenshots[3].enabled = false;

            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[1].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[2].enabled = true;
            }

            tutorialStatus = 2;
        }
        else if (tutorialStatus == 4)
        {
            TutorialScreenshots[4].enabled = false;

            TutorialScreenshots[3].enabled = true;

            tutorialStatus = 3;
        }
        else if (tutorialStatus == 5)
        {
            TutorialScreenshots[5].enabled = false;
            TutorialScreenshots[6].enabled = false;

            TutorialScreenshots[4].enabled = true;

            tutorialStatus = 4;
        }
        else if (tutorialStatus == 6)
        {
            TutorialScreenshots[7].enabled = false;
            TutorialScreenshots[8].enabled = false;

            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[5].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[6].enabled = true;
            }

            tutorialStatus = 5;
        }
        else if (tutorialStatus == 7)
        {
            TutorialScreenshots[9].enabled = false;
            TutorialScreenshots[10].enabled = false;

            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[7].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[8].enabled = true;
            }

            tutorialStatus = 6;
        }
        else if (tutorialStatus == 8)
        {
            TutorialScreenshots[11].enabled = false;

            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[9].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[10].enabled = true;
            }

            tutorialStatus = 7;
        }
        else if (tutorialStatus == 9)
        {

            TutorialScreenshots[12].enabled = false;

            TutorialScreenshots[11].enabled = true;

            TutorialNextButton.SetActive(true);

            tutorialStatus = 8;
        }
    }

    public void ClickTutorialNext()
    {
        if (tutorialStatus == 1)
        { 
            TutorialScreenshots[0].enabled = false;
            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[1].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[2].enabled = true;
            }
            tutorialStatus = 2;
        }
        else if (tutorialStatus == 2)
        {
            TutorialScreenshots[1].enabled = false;
            TutorialScreenshots[2].enabled = false;
            
            TutorialScreenshots[3].enabled = true;
            tutorialStatus = 3;
        }
        else if (tutorialStatus == 3)
        {
            TutorialScreenshots[3].enabled = false;

            TutorialScreenshots[4].enabled = true;

            tutorialStatus = 4;
        }
        else if (tutorialStatus == 4)
        {
            TutorialScreenshots[4].enabled = false;
            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[5].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[6].enabled = true;
            }
            tutorialStatus = 5;
        }
        else if (tutorialStatus == 5)
        {
            TutorialScreenshots[5].enabled = false;
            TutorialScreenshots[6].enabled = false;
            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[7].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[8].enabled = true;
            }
            tutorialStatus = 6;
        }
        else if (tutorialStatus == 6)
        {
            TutorialScreenshots[7].enabled = false;
            TutorialScreenshots[8].enabled = false;
            if (SceneSwitchingScript.isXbox == true)
            {
                TutorialScreenshots[9].enabled = true;
            }
            else if (SceneSwitchingScript.isXbox == false)
            {
                TutorialScreenshots[10].enabled = true;
            }
            tutorialStatus = 7;
        }
        else if (tutorialStatus == 7)
        {
            TutorialScreenshots[9].enabled = false;
            TutorialScreenshots[10].enabled = false;

            TutorialScreenshots[11].enabled = true;

            tutorialStatus = 8;
        }
        else if (tutorialStatus == 8)
        {
            TutorialScreenshots[11].enabled = false;

            TutorialScreenshots[12].enabled = true;

            tutorialStatus = 9;

            TutorialNextButton.SetActive(false);
            TutorialPreviousButton.GetComponent<Button>().Select();

        }
    }

}
