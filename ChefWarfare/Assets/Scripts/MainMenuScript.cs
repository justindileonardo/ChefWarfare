using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{

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
        
    }

    public void ClickPlayButton()
    {

    }

    public void ClickControlsButton()
    {
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
