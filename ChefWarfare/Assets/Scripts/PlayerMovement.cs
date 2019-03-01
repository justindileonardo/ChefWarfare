using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables

    //setting player number
    public bool player1;
    public bool player2;
    public bool player3;
    public bool player4;

    public PlayerStatus myPlayerStatusScript;
    public float rotSpeed;
    public Vector3 respawnPosition;

    //Weapons
    public GameObject weaponPivotPoint;
    public GameObject Weapon_PeaShooter;
    public SpriteRenderer Weapon_PeaShooterSpriteRenderer;
    public GameObject Weapon_SemiAutoRifle;
    public SpriteRenderer Weapon_SemiAutoRifleSpriteRenderer;
    public GameObject Weapon_BurstRifle;
    public SpriteRenderer Weapon_BurstRifleSpriteRenderer;
    public GameObject Weapon_Shotgun;
    public SpriteRenderer Weapon_ShotgunSpriteRenderer;
    public GameObject Weapon_SpaghettiWhipCheese;
    public SpriteRenderer Weapon_SpaghttiWhipCheeseWindUpSpriteRenderer;
    public SpriteRenderer Weapon_SpaghttiWhipCheeseAttackSpriteRenderer;
    public GameObject Weapon_SpaghettiWhipOnion;
    public SpriteRenderer Weapon_SpaghttiWhipOnionWindUpSpriteRenderer;
    public SpriteRenderer Weapon_SpaghttiWhipOnionAttackSpriteRenderer;


    //Sprites for Character
    public SpriteRenderer armsSpriteL;
    public SpriteRenderer armsSpriteR;
    public SpriteRenderer chefSpriteHead;
    public SpriteRenderer chefSpriteBody;
    public SpriteRenderer chefSpriteLegL;
    public SpriteRenderer chefSpriteLegR;

    public Animator playerAnimator;

    //private variables
    private Rigidbody2D rb;
    private float xPos;
    private float yPos;
    private float xRot;
    private float yRot;
    private float moveSpeedDefault;
    private float moveSpeedEffectTimer;
    private float cheeseMoveSpeedSlowLength;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        
        if(player1 == true)
        {
            //Inputs for Left Joystick (Moving the player)
            xPos = Input.GetAxis("Xbox_HorizontalLS_P1");
            yPos = Input.GetAxis("Xbox_VerticalLS_P1");
            //Inputs for Right Joystick (Rotating the player)
            xRot = Input.GetAxis("Xbox_HorizontalRS_P1");
            yRot = Input.GetAxis("Xbox_VerticalRS_P1");
        }
        else if (player2 == true)
        {
            //Inputs for Left Joystick (Moving the player)
            xPos = Input.GetAxis("Xbox_HorizontalLS_P2");
            yPos = Input.GetAxis("Xbox_VerticalLS_P2");
            //Inputs for Right Joystick (Rotating the player)
            xRot = Input.GetAxis("Xbox_HorizontalRS_P2");
            yRot = Input.GetAxis("Xbox_VerticalRS_P2");
        }
        else if (player3 == true)
        {
            //Inputs for Left Joystick (Moving the player)
            xPos = Input.GetAxis("Xbox_HorizontalLS_P3");
            yPos = Input.GetAxis("Xbox_VerticalLS_P3");
            //Inputs for Right Joystick (Rotating the player)
            xRot = Input.GetAxis("Xbox_HorizontalRS_P3");
            yRot = Input.GetAxis("Xbox_VerticalRS_P3");
        }
        else if (player4 == true)
        {
            //Inputs for Left Joystick (Moving the player)
            xPos = Input.GetAxis("Xbox_HorizontalLS_P4");
            yPos = Input.GetAxis("Xbox_VerticalLS_P4");
            //Inputs for Right Joystick (Rotating the player)
            xRot = Input.GetAxis("Xbox_HorizontalRS_P4");
            yRot = Input.GetAxis("Xbox_VerticalRS_P4");
        }

        //Moving the player
        rb.velocity = new Vector2(xPos * myPlayerStatusScript.moveSpeed, yPos * myPlayerStatusScript.moveSpeed);

        //Animating the player
        if (xPos != .0 || yPos != .0)
        {
            playerAnimator.SetBool("playerIsMoving", true);
        }
        else
        {
            playerAnimator.SetBool("playerIsMoving", false);
        }

        

        //If the joystick is let go, it won't change the joystick angle
        if (xRot != 0 || yRot != 0)
        {
            float angle = Mathf.Atan2(yRot, -xRot) * Mathf.Rad2Deg * rotSpeed;
            weaponPivotPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //print(angle);

            //if weapon is pointed above x axis, gun appears behind player
            if (angle <= 90 && angle >= -90)
            {
                Weapon_PeaShooterSpriteRenderer.sortingOrder = -2;
                Weapon_SemiAutoRifleSpriteRenderer.sortingOrder = -2;
                Weapon_BurstRifleSpriteRenderer.sortingOrder = -2;
                Weapon_ShotgunSpriteRenderer.sortingOrder = -2;
                Weapon_SpaghttiWhipCheeseWindUpSpriteRenderer.sortingOrder = -2;
                Weapon_SpaghttiWhipCheeseAttackSpriteRenderer.sortingOrder = -2;
                Weapon_SpaghttiWhipOnionWindUpSpriteRenderer.sortingOrder = -2;
                Weapon_SpaghttiWhipOnionAttackSpriteRenderer.sortingOrder = -2;
                armsSpriteL.sortingOrder = -1;
                armsSpriteR.sortingOrder = -3;
            }
            //if weapon is pointed below x axis, gun appears in front of player
            else
            {
                Weapon_PeaShooterSpriteRenderer.sortingOrder = 2;
                Weapon_SemiAutoRifleSpriteRenderer.sortingOrder = 2;
                Weapon_BurstRifleSpriteRenderer.sortingOrder = 2;
                Weapon_ShotgunSpriteRenderer.sortingOrder = 2;
                Weapon_SpaghttiWhipCheeseWindUpSpriteRenderer.sortingOrder = 2;
                Weapon_SpaghttiWhipCheeseAttackSpriteRenderer.sortingOrder = 2;
                Weapon_SpaghttiWhipOnionWindUpSpriteRenderer.sortingOrder = 2;
                Weapon_SpaghttiWhipOnionAttackSpriteRenderer.sortingOrder = 2;
                armsSpriteL.sortingOrder = 1;
                armsSpriteR.sortingOrder = 3;
            }

            //flipping sprite
            if(angle <= 0)
            {
                chefSpriteHead.flipX = false;
                chefSpriteBody.flipX = false;
                chefSpriteLegL.flipX = false;
                chefSpriteLegR.flipX = false;
                armsSpriteL.flipX = false;
                armsSpriteR.flipX = false;
            }
            else
            {
                chefSpriteHead.flipX = true;
                chefSpriteBody.flipX = true;
                chefSpriteLegL.flipX = true;
                chefSpriteLegR.flipX = true;
                armsSpriteL.flipX = true;
                armsSpriteR.flipX = true;
            }


        }

       

    }




}
