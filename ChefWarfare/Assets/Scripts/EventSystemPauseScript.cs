using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemPauseScript : MonoBehaviour
{

    private SceneSwitchingScript sss;

    // Start is called before the first frame update
    void Start()
    {
        sss = GameObject.Find("SceneSwitchingScript").GetComponent<SceneSwitchingScript>();

        if(sss.isMac == false)
        {
            GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_ALL";
        }
        else if (sss.isMac == true)
        {
            GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_ALL_MAC";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
