using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{

    private LevelLogic levelLogicScript;
    private float timerRed;
    private float timerBlue;
    private float timerGreen;
    private float timerOrange;

    // Start is called before the first frame update
    void Start()
    {
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
        timerRed = 1;
        timerBlue = 1;
        timerGreen = 1;
        timerOrange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            if(timerRed >= 0)
            {
                timerRed -= Time.deltaTime;
            }
            if (timerRed < 0)
            {
                levelLogicScript.scoreRed += 1;
                timerRed = 1;
            } 
        }
        if (other.gameObject.name == "Player2")
        {
            if (timerBlue >= 0)
            {
                timerBlue -= Time.deltaTime;
            }
            if (timerBlue < 0)
            {
                levelLogicScript.scoreBlue += 1;
                timerBlue = 1;
            }
        }
        if (other.gameObject.name == "Player3")
        {
            if (timerGreen >= 0)
            {
                timerGreen -= Time.deltaTime;
            }
            if (timerGreen < 0)
            {
                levelLogicScript.scoreGreen += 1;
                timerGreen = 1;
            }
        }
        if (other.gameObject.name == "Player4")
        {
            if (timerOrange >= 0)
            {
                timerOrange -= Time.deltaTime;
            }
            if (timerOrange < 0)
            {
                levelLogicScript.scoreOrange += 1;
                timerOrange = 1;
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {
            timerRed = 1;
        }
        if (other.gameObject.name == "Player2")
        {
            timerBlue = 1;
        }
        if (other.gameObject.name == "Player3")
        {
            timerGreen = 1;
        }
        if (other.gameObject.name == "Player4")
        {
            timerOrange = 1;
        }
    }

}
