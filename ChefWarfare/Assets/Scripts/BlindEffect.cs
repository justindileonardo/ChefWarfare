using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEffect : MonoBehaviour
{

    public GameObject blindEffectSprite;
    public float blindEffectTimer;

    // Start is called before the first frame update
    void Start()
    {
        blindEffectSprite.SetActive(false);
        blindEffectTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(blindEffectTimer >= 0)
        {
            blindEffectTimer -= Time.deltaTime;
            blindEffectSprite.SetActive(true);
        }
        else if(blindEffectTimer < 0)
        {
            blindEffectSprite.SetActive(false);
        }

    }
}
