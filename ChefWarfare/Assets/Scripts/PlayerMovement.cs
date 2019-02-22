using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables
    public float moveSpeed;
    public float rotSpeed;
    public int HP;

    //Weapons
    public GameObject weaponPivotPoint;
    public GameObject Weapon_PeaShooter;
    public SpriteRenderer Weapon_PeaShooterSpriteRenderer;
    public GameObject Weapon_SemiAutoRifle;
    public SpriteRenderer Weapon_SemiAutoRifleSpriteRenderer;
    public GameObject Weapon_BurstRifle;
    public SpriteRenderer Weapon_BurstRifleSpriteRenderer;

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
    private float moveSpeedDefault;
    private float moveSpeedEffectTimer;
    private float cheeseMoveSpeedSlowLength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = 100;
        weaponPivotPoint = GameObject.Find("Weapon_PivotPoint");
        moveSpeedDefault = 8.0f;
        moveSpeed = moveSpeedDefault;
        cheeseMoveSpeedSlowLength = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //print("HP: " + HP);
        

    }

    void FixedUpdate()
    {
        //Inputs for Left Joystick (Moving the player)
        float xPos = Input.GetAxis("Xbox_HorizontalLS_P1");
        float yPos = Input.GetAxis("Xbox_VerticalLS_P1");

        //Moving the player
        rb.velocity = new Vector2(xPos * moveSpeed, yPos * moveSpeed);

        //Animating the player
        if (xPos != .0 || yPos != .0)
        {
            playerAnimator.SetBool("playerIsMoving", true);
        }
        else
        {
            playerAnimator.SetBool("playerIsMoving", false);
        }

        //Inputs for Right Joystick (Rotating the player)
        float xRot = Input.GetAxis("Xbox_HorizontalRS_P1");
        float yRot = Input.GetAxis("Xbox_VerticalRS_P1");

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
                armsSpriteL.sortingOrder = -1;
                armsSpriteR.sortingOrder = -3;
            }
            //if weapon is pointed below x axis, gun appears in front of player
            else
            {
                Weapon_PeaShooterSpriteRenderer.sortingOrder = 2;
                Weapon_SemiAutoRifleSpriteRenderer.sortingOrder = 2;
                Weapon_BurstRifleSpriteRenderer.sortingOrder = 2;
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


            //adding effects to player
            //move speed slow, goes back to default after 1 second
            if(moveSpeed != moveSpeedDefault/*8.0f*/) 
            {
                moveSpeedEffectTimer += Time.deltaTime;
                if(moveSpeedEffectTimer > cheeseMoveSpeedSlowLength/*1.0f*/)
                {
                    moveSpeedEffectTimer = 0;
                    moveSpeed = moveSpeedDefault;
                }
            }

        }

    }




}
