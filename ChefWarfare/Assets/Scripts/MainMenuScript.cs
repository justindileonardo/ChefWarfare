using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    private string inputB;
    private bool selectingMode, lookingAtControls;

    public GameObject PlayButton;
    public GameObject TutorialButton;
    public GameObject ControlsButton;
    public GameObject QuitButton;

    public GameObject BackToMenuButton;

    public GameObject ModeFFAButton;
    public GameObject ModeTeamUpButton;
    public GameObject ModeDuelButton;

    public GameObject ControlsImage;

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

        ControlsImage.SetActive(false);

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

        //ModeFFAButton.GetComponent<Button>().OnSelect();
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

        ControlsImage.SetActive(true);

        BackToMenuButton.GetComponent<Button>().Select();
    }

    public void ClickBackToMenuButton()
    {
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

        ControlsImage.SetActive(false);

        PlayButton.GetComponent<Button>().Select();
    }



}
