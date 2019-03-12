using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook_ButtonDisabler : MonoBehaviour
{

    private Image thisButton;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Image>();
        thisButton.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableButtonWhenClicked()
    {
        thisButton.color = Color.red;
    }

}
