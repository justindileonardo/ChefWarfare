using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchingScript : MonoBehaviour
{
    public bool isMac;
    private string inputStart;

    // Start is called before the first frame update
    void Start()
    {
        
        if(isMac == false)
        {
            inputStart = "Xbox_Button_Start";
        }
        else if(isMac == true)
        {
            inputStart = "Xbox_Button_Start_MAC";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
        if (Input.GetButtonDown(inputStart))
        {
            GoToMenu();
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
