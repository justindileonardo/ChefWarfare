using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HighlightButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{

    public Image chef_FFA_red;
    public Image chef_FFA_blue;
    public Image chef_FFA_green;
    public Image chef_FFA_orange;

    public Image chef_2v2_red;
    public Image chef_2v2_red2;
    public Image chef_2v2_blue;
    public Image chef_2v2_blue2;

    public Image chef_1v1_red;
    public Image chef_1v1_blue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(gameObject.name == "Button_ModeFFA" || gameObject.name == "Button_Play")
        {
            chef_FFA_red.enabled = true;
            chef_FFA_blue.enabled = true;
            chef_FFA_green.enabled = true;
            chef_FFA_orange.enabled = true;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
        else if(gameObject.name == "Button_ModeTeamUp")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = true;
            chef_2v2_red2.enabled = true;
            chef_2v2_blue.enabled = true;
            chef_2v2_blue2.enabled = true;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
        else if(gameObject.name == "Button_ModeDuel")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = true;
            chef_1v1_blue.enabled = true;
        }
        else if(gameObject.name == "Button_TutorialNext")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "Button_ModeFFA" || gameObject.name == "Button_Play")
        {
            chef_FFA_red.enabled = true;
            chef_FFA_blue.enabled = true;
            chef_FFA_green.enabled = true;
            chef_FFA_orange.enabled = true;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
        else if (gameObject.name == "Button_ModeTeamUp")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = true;
            chef_2v2_red2.enabled = true;
            chef_2v2_blue.enabled = true;
            chef_2v2_blue2.enabled = true;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
        else if (gameObject.name == "Button_ModeDuel")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = true;
            chef_1v1_blue.enabled = true;
        }
        else if (gameObject.name == "Button_TutorialNext")
        {
            chef_FFA_red.enabled = false;
            chef_FFA_blue.enabled = false;
            chef_FFA_green.enabled = false;
            chef_FFA_orange.enabled = false;

            chef_2v2_red.enabled = false;
            chef_2v2_red2.enabled = false;
            chef_2v2_blue.enabled = false;
            chef_2v2_blue2.enabled = false;

            chef_1v1_red.enabled = false;
            chef_1v1_blue.enabled = false;
        }
    }
    
}
