﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventSystemMainMenu : MonoBehaviour
{

    private SceneSwitchingScript sss;

    // Start is called before the first frame update
    void Start()
    {

        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Win")
        {
            sss = GameObject.Find("SceneSwitchingScript").GetComponent<SceneSwitchingScript>();

            if (SceneSwitchingScript.isMac == false)
            {
                if(SceneSwitchingScript.isXbox == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_ALL";
                }
                else if(SceneSwitchingScript.isXbox == false)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "PS4_Button_A_ALL";
                }
                
            }
            else if (SceneSwitchingScript.isMac == true)
            {
                if(SceneSwitchingScript.isXbox == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_ALL_MAC";
                }
                else if (SceneSwitchingScript.isXbox == false)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "PS4_Button_A_ALL";
                }

            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}