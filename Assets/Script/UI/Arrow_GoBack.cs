﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//this script is used in the character slection scene.
//It allows to go back to the main menu

public class Arrow_GoBack : MonoBehaviour {


    public Animator anim;

    public SoundManager soundManager;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col)
	{

		anim.SetTrigger ("isTouching");
		int playerNumber = int.Parse (col.name);
		if (Input.GetButton ("Fire" + playerNumber)) {
			Destroy (GameObject.Find ("Presupervisor"));
			soundManager.GetComponent<AudioSource> ().Play ();
			foreach (AudioSource audio in soundManager.sourceList) {
			audio.Stop();
			}
			SceneManager.LoadScene (0);

		}

	}

}
