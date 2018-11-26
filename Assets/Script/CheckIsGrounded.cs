using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsGrounded : MonoBehaviour {

	public Movement player;
	public MovementMenu player_menu;

	public bool inMenu;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Movement>();
		if(inMenu){
		    player_menu = GameObject.Find("Vanilla").GetComponentInParent<MovementMenu>();
		}
	
	}


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer.Equals (8)) {
		if(player!=null)
			player.isGrounded = true;
		if(inMenu)
			player_menu.isGrounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.layer.Equals (8)) {
			if(player!=null)
			player.isGrounded = true;
			if(inMenu)
			player_menu.isGrounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.layer.Equals (8)) {
			if(player!=null)
			    player.isGrounded = false;
			if(inMenu)
			    player_menu.isGrounded = false;
		}
	}
}
