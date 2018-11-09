using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallJump : MonoBehaviour {
    public Movement player;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Movement>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.CompareTag("WallJumpAllowed") && !player.isGrounded) {
		    player.canWallJump = true;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		
		if (col.gameObject.CompareTag("WallJumpAllowed") && !player.isGrounded) {
		    player.canWallJump = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (player.canWallJump) {
			player.canWallJump = false;
		}
	}
	 
}
