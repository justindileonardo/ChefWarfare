using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int breadCount;

    // Start is called before the first frame update
    void Start()
    {
        breadCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Resource_Bread")
        {
            Destroy(other.gameObject);
            breadCount++;
            print("Bread: " + breadCount);
        }
    }

}
