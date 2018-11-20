using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMenu : MonoBehaviour {

    public Rigidbody2D aRgbd;//2D rigidBody
    public int aMaxSpeed;//Maximum speed of the object
    public int aSpeed;//Current speed of the object
    public int aJumpForce;//the force of the jump
    public bool isJumping;//know if the player is jumping
    public bool isGrounded;//know if the player is on the ground
    public Animator anim;//Control the animation of the player
    public AudioSource source;//display jump sound, death, ...
    public bool dead;
    public bool isUsingTaunt;
    public bool canWallJump;

    public AudioClip clip;
    public AudioClip taunt;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpTimeCounter;
    public float jumpTime;

    public string playerNumber;

    // Use this for initialization
    void Start () {
        aRgbd = gameObject.GetComponent<Rigidbody2D>();
        source = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isGrounded)
            canWallJump = false;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        anim.SetBool("Dead", dead);
        //anim.SetBool("Taunt", taunt);
        if (!dead)
        {
            if (isGrounded)
                jumpTimeCounter = jumpTime;

            if (Input.GetButtonDown("Fire" + playerNumber) && isGrounded)
            {
                aRgbd.velocity = new Vector2(aRgbd.velocity.x, aJumpForce);
                source.Play();
                isJumping = true;
            }
            if (Input.GetButton("Fire" + playerNumber) && isJumping)
            {//Allow the player to jump higher if it press the jump button longer
                if (jumpTimeCounter > 0)
                {
                    aRgbd.velocity = new Vector2(aRgbd.velocity.x, aJumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                    isJumping = true;
                }
                else
                {
                    isJumping = false;
                }

            }
            if (Input.GetButtonUp("Fire" + playerNumber))
            {
                isJumping = false;
            }

            if (Input.GetButtonDown("Fire" + playerNumber) && canWallJump)
            {
                aRgbd.velocity = new Vector2(35 * -gameObject.transform.localScale.x, aJumpForce * 2);
                source.Play();
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, 1, 1);
            }
        }
    }
    // FixedUpdate is called once per frame after Update
    void FixedUpdate()
    {
        if (!dead)
        {
            Vector2 easeVelocity = aRgbd.velocity;
            easeVelocity.y *= 0.75f;
            easeVelocity.x *= 0.75f;
            float moveHorizontal = Input.GetAxis("Horizontal" + playerNumber);//Get the control pad direction

            if (Input.GetAxis("Horizontal" + playerNumber) < -0.1f)
            {//Allow to move left

                aRgbd.AddForce(new Vector2(moveHorizontal * aSpeed, 0));
                transform.localScale = new Vector2(-1, 1);//Change the direction to look left
            }
            else if (Input.GetAxis("Horizontal" + playerNumber) > 0.1f)
            {//Allow to move right
                aRgbd.AddForce(new Vector2(moveHorizontal * aSpeed, 0));
                transform.localScale = new Vector2(1, 1);//Change the direction to look right
            }


            aRgbd.velocity = easeVelocity;//Ease the velocity to get more control on the object


            aRgbd.AddForce(new Vector2(aRgbd.velocity.x, aRgbd.velocity.y));

            if (aRgbd.velocity.x > aMaxSpeed)
            {//Control if current speed > max speed
                aRgbd.velocity = new Vector2(aMaxSpeed, aRgbd.velocity.y);
            }
            if (aRgbd.velocity.x < -aMaxSpeed)
            {//Control if current speed > max speed
                aRgbd.velocity = new Vector2(-aMaxSpeed, aRgbd.velocity.y);
            }
        }
    }
}
