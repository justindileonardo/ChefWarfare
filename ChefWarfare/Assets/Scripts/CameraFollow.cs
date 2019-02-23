using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public variables
    public PlayerStatus playerScript;

    //private variables
    private float lerpSpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerScript.transform.position.x, playerScript.transform.position.y, transform.position.z), lerpSpeed);
    }
}
