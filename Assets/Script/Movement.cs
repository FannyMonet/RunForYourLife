using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script code the player movement (Jump, Left, Right) with a sound for each action
//It also describe what append if a player touch a trap.
public class Movement : MonoBehaviour {

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

    public CameraAtStart camera;

    public FlagBehaviourScript flag;
    public GameObject SoundManager;


	void Start () {
	    Destroy(GameObject.Find("SoundManager"));
		aRgbd = gameObject.GetComponent<Rigidbody2D>();
		source = gameObject.GetComponent<AudioSource>();
		anim = gameObject.GetComponent<Animator>();
		camera = GameObject.Find("Main Camera").GetComponent<CameraAtStart>();
		flag = GameObject.Find("FLAG").GetComponent<FlagBehaviourScript>();
	}
	void Update ()
	{
	if(isGrounded)
	canWallJump = false;
		if (camera.StartingGame) {//If the camera movement at the begining is over
			isGrounded = Physics2D.OverlapCircle (feetPos.position, checkRadius, whatIsGround);
			anim.SetBool ("Dead", dead); 
			anim.SetBool ("Taunt", taunt);   
			if (!dead) {
				if (isGrounded)
					jumpTimeCounter = jumpTime;
			
				if (Input.GetButtonDown ("Fire"+playerNumber) && isGrounded) {
					aRgbd.velocity = new Vector2 (aRgbd.velocity.x, aJumpForce);
					source.Play ();
					isJumping = true;
				}
				if (Input.GetButton ("Fire"+playerNumber) && isJumping) {//Allow the player to jump higher if it press the jump button longer
					if (jumpTimeCounter > 0) {
						aRgbd.velocity = new Vector2 (aRgbd.velocity.x, aJumpForce);
						jumpTimeCounter -= Time.deltaTime;
						isJumping = true;
					} else {
						isJumping = false;
					}

				}
				if (Input.GetButtonUp ("Fire"+playerNumber)) {
					isJumping = false;
				}

				if (Input.GetButtonDown ("Fire"+playerNumber) && canWallJump) {
					aRgbd.velocity = new Vector2 (35* -gameObject.transform.localScale.x, aJumpForce*2);
					source.Play ();
					gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, 1,1);
				}
			}
		}
	}
	// FixedUpdate is called once per frame after Update
	void FixedUpdate ()
	{
		if (camera.StartingGame) {
			if (!dead) {
				Vector2 easeVelocity = aRgbd.velocity;
				easeVelocity.y *= 0.75f;
				easeVelocity.x *= 0.75f; 
				float moveHorizontal = Input.GetAxis ("Horizontal"+playerNumber);//Get the control pad direction

				if (Input.GetAxis ("Horizontal"+playerNumber) < -0.1f) {//Allow to move left

					aRgbd.AddForce (new Vector2 (moveHorizontal * aSpeed, 0));
					transform.localScale = new Vector2 (-1, 1);//Change the direction to look left
				} else if (Input.GetAxis ("Horizontal"+playerNumber) > 0.1f) {//Allow to move right
					aRgbd.AddForce (new Vector2 (moveHorizontal * aSpeed, 0));
					transform.localScale = new Vector2 (1, 1);//Change the direction to look right
				}
	

				aRgbd.velocity = easeVelocity;//Ease the velocity to get more control on the object
	
		
				aRgbd.AddForce (new Vector2 (aRgbd.velocity.x, aRgbd.velocity.y));
		
				if (aRgbd.velocity.x > aMaxSpeed) {//Control if current speed > max speed
					aRgbd.velocity = new Vector2 (aMaxSpeed, aRgbd.velocity.y);
				}
				if (aRgbd.velocity.x < -aMaxSpeed) {//Control if current speed > max speed
					aRgbd.velocity = new Vector2 (-aMaxSpeed, aRgbd.velocity.y);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
	    if(col.tag.Equals("Trap")&& !dead){
		   flag.playerList[flag.nbFinis] = this.gameObject;
	       flag.nbFinis++;
		   //Debug.Log((int)char.GetNumericValue(col.name,0));
		   if (!col.name.Equals("DeadLine_Limit")) {
			   flag.scoresKills[(int)char.GetNumericValue(col.name,0)-1] += 1;
           }
	       flag.someoneDead = true;

	       dead = true;
	       source.PlayOneShot(clip);
	    }

	}
}
