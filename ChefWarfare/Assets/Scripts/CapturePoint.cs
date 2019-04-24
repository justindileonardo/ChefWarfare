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

    private bool p1InZone, p2InZone, p3InZone, p4InZone;

    // Start is called before the first frame update
    void Start()
    {
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
        timerRed = 1;
        timerBlue = 1;
        timerGreen = 1;
        timerOrange = 1;
        p1InZone = false;
        p2InZone = false;
        p3InZone = false;
        p4InZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelLogic.mode == "2v2")
        {
            if(p1InZone || p3InZone)
            {
                if (timerRed >= 0)
                {
                    timerRed -= Time.deltaTime;
                }
                if (timerRed < 0)
                {
                    LevelLogic.scoreRed += 1;
                    timerRed = 1;
                }
            }
            if(p2InZone || p4InZone)
            {
                if (timerBlue >= 0)
                {
                    timerBlue -= Time.deltaTime;
                }
                if (timerBlue < 0)
                {
                    LevelLogic.scoreBlue += 1;
                    timerBlue = 1;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //2v2 Mode
        if (LevelLogic.mode == "2v2")
        {

            if (other.gameObject.name == "Player1")
            {
                p1InZone = true;
            }
            if (other.gameObject.name == "Player2")
            {
                p2InZone = true;
            }
            if (other.gameObject.name == "Player3")
            {
                p3InZone = true;
            }
            if (other.gameObject.name == "Player4")
            {
                p4InZone = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //FFA Mode
        if(LevelLogic.mode == "FFA" || LevelLogic.mode == "1v1")
        {
            if (other.gameObject.name == "Player1")
            {
                if (timerRed >= 0)
                {
                    timerRed -= Time.deltaTime;
                }
                if (timerRed < 0)
                {
                    LevelLogic.scoreRed += 1;
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
                    LevelLogic.scoreBlue += 1;
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
                    LevelLogic.scoreGreen += 1;
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
                   LevelLogic.scoreOrange += 1;
                    timerOrange = 1;
                }
            }
        }
        

        //2v2 Mode
        else if (LevelLogic.mode == "2v2")
        {

        }
        
            
            
        
        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(LevelLogic.mode == "FFA" || LevelLogic.mode == "1v1")
        {
            if (other.gameObject.name == "Player1")
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
        else if(LevelLogic.mode == "2v2")
        {
            if (other.gameObject.name == "Player1")
            {
                p1InZone = false;
                if(p3InZone == false)
                {
                    timerRed = 1;
                }
            }
            if (other.gameObject.name == "Player2")
            {
                p2InZone = false;
                if(p4InZone == false)
                {
                    timerBlue = 1;
                }
            }
            if (other.gameObject.name == "Player3")
            {
                p3InZone = false;
                if (p1InZone == false)
                {
                    timerRed = 1;
                }
            }
            if (other.gameObject.name == "Player4")
            {
                p4InZone = false;
                if(p2InZone == false)
                {
                    timerBlue = 1;
                }
            }
        }
        
    }

}
