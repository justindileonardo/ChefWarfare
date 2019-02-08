using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{

    private GameObject Weapon_PeaShooter;
    private GameObject Weapon_PivotPoint;
    private float speed = 10.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Weapon_PeaShooter = GameObject.Find("PeaShooter");
        Weapon_PivotPoint = GameObject.Find("Weapon_PivotPoint");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
