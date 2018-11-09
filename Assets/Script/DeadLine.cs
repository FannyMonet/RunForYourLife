using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script simulate the line that destroy any game object if it fall down.
//If the object is a player, it plays a sound first.
//Then, whatever the object is, it destroys it so that Unity doesn't have to calculate an endless fall.
public class DeadLine : MonoBehaviour {


public AudioSource audio;
public AudioClip clip;


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag.Equals ("Player")) {//If the game object is a player, it play a sound of falling
			audio.PlayOneShot (clip);
		} 
		if(!col.tag.Equals("CharacterTrap"))
	   Destroy(col.gameObject, 2f);
	}
}
