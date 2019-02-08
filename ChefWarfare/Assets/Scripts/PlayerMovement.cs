using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables
    public float moveSpeed;
    public float rotSpeed;
    public GameObject Weapon_PeaShooter;
    public SpriteRenderer Weapon_PeaShooterSpriteRenderer;

    //private variables
    private Rigidbody2D rb;
    private GameObject weaponPivotPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponPivotPoint = GameObject.Find("Weapon_PivotPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    void FixedUpdate()
    {
        //Inputs for Left Joystick (Moving the player)
        float xPos = Input.GetAxis("HorizontalLS");
        float yPos = Input.GetAxis("VerticalLS");

        //Moving the player
        rb.velocity = new Vector2(xPos * moveSpeed, yPos * moveSpeed);

        //Inputs for Right Joystick (Rotating the player)
        float xRot = Input.GetAxis("HorizontalRS");
        float yRot = Input.GetAxis("VerticalRS");

        //If the joystick is let go, it won't change the joystick angle
        if (xRot != 0 || yRot != 0)
        {
            float angle = Mathf.Atan2(yRot, -xRot) * Mathf.Rad2Deg * rotSpeed;
            weaponPivotPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            //if weapon is pointed above x axis, gun appears behind player
            if (angle <= 90 && angle >= -90)
            {
                Weapon_PeaShooterSpriteRenderer.sortingOrder = -1;
            }
            //if weapon is pointed below x axis, gun appears in front of player
            else
            {
                Weapon_PeaShooterSpriteRenderer.sortingOrder = 1;
            }
        }

    }
}
