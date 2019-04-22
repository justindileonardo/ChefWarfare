using UnityEngine.EventSystems;
using UnityEngine;

public class MyEventSystem : EventSystem
{

    public PlayerMovement playerMovementScript;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        EventSystem originalCurrent = EventSystem.current;
        current = this;
        base.Update();
        current = originalCurrent;
    }
    protected override void Start()
    {
        if(this.gameObject.name != "EventSystemPause")
        {
            if (playerMovementScript.isMac == false)
            {
                if (playerMovementScript.player1 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P1";
                }
                else if (playerMovementScript.player2 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P2";
                }
                else if (playerMovementScript.player3 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P3";
                }
                else if (playerMovementScript.player4 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P4";
                }
            }
            else if (playerMovementScript.isMac == true)
            {
                if (playerMovementScript.player1 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P1_MAC";
                }
                else if (playerMovementScript.player2 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P2_MAC";
                }
                else if (playerMovementScript.player3 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P3_MAC";
                }
                else if (playerMovementScript.player4 == true)
                {
                    GetComponent<StandaloneInputModule>().submitButton = "Xbox_Button_A_P4_MAC";
                }
            }
        }
        



    }
    

}