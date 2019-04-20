using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private LevelLogic levelLogicScript;

    //Music
    [SerializeField] private AudioSource[] AS_Music;

    //Sound effects
    [SerializeField] private AudioSource[] AS_LevelLogic;
    [SerializeField] private AudioSource[] AS_CookingScript;
    [SerializeField] private AudioSource[] AS_Player1;
    [SerializeField] private AudioSource[] AS_Player2;
    [SerializeField] private AudioSource[] AS_Player3;
    [SerializeField] private AudioSource[] AS_Player4;
    [SerializeField] private AudioSource[] AS_WhipC1;
    [SerializeField] private AudioSource[] AS_WhipC2;
    [SerializeField] private AudioSource[] AS_WhipC3;
    [SerializeField] private AudioSource[] AS_WhipC4;
    [SerializeField] private AudioSource[] AS_WhipO1;
    [SerializeField] private AudioSource[] AS_WhipO2;
    [SerializeField] private AudioSource[] AS_WhipO3;
    [SerializeField] private AudioSource[] AS_WhipO4;

    

    // Start is called before the first frame update
    void Start()
    {

        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();

        AS_Music = GameObject.Find("MusicPlayer").GetComponents<AudioSource>();

        AS_LevelLogic = GameObject.Find("LevelLogic").GetComponents<AudioSource>();
        AS_CookingScript = GameObject.Find("CookingScript").GetComponents<AudioSource>();
        AS_Player1 = GameObject.Find("Player1").GetComponents<AudioSource>();
        AS_Player2 = GameObject.Find("Player2").GetComponents<AudioSource>();
        AS_Player3 = GameObject.Find("Player3").GetComponents<AudioSource>();
        AS_Player4 = GameObject.Find("Player4").GetComponents<AudioSource>();
        /*
        //Whips are set publicly bc they start disabled
        AS_WhipC1 = GameObject.Find("Weapon_SpaghettiWhip_Cheese_Attack1").GetComponents<AudioSource>();
        AS_WhipC2 = GameObject.Find("Weapon_SpaghettiWhip_Cheese_Attack2").GetComponents<AudioSource>();
        AS_WhipC3 = GameObject.Find("Weapon_SpaghettiWhip_Cheese_Attack3").GetComponents<AudioSource>();
        AS_WhipC4 = GameObject.Find("Weapon_SpaghettiWhip_Cheese_Attack4").GetComponents<AudioSource>();
        AS_WhipO1 = GameObject.Find("Weapon_SpaghettiWhip_Onion_Attack1").GetComponents<AudioSource>();
        AS_WhipO2 = GameObject.Find("Weapon_SpaghettiWhip_Onion_Attack2").GetComponents<AudioSource>();
        AS_WhipO3 = GameObject.Find("Weapon_SpaghettiWhip_Onion_Attack3").GetComponents<AudioSource>();
        AS_WhipO4 = GameObject.Find("Weapon_SpaghettiWhip_Onion_Attack4").GetComponents<AudioSource>();
        */
        foreach(AudioSource AS in AS_LevelLogic)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_CookingScript)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_Player1)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_Player2)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_Player3)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_Player4)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipC1)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipC2)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipC3)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipC4)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipO1)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipO2)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipO3)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }
        foreach (AudioSource AS in AS_WhipO4)
        {
            AS.volume = levelLogicScript.sfxVolumeSlider.value;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(levelLogicScript.gameIsPaused == true)
        {
            foreach (AudioSource AS in AS_LevelLogic)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_CookingScript)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_Player1)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_Player2)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_Player3)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_Player4)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipC1)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipC2)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipC3)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipC4)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipO1)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipO2)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipO3)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
            foreach (AudioSource AS in AS_WhipO4)
            {
                AS.volume = levelLogicScript.sfxVolumeSlider.value;
            }
        }
    }
}
