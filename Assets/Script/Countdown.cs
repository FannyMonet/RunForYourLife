using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour {


    public int countdown;

    public FlagBehaviourScript flag;

    public Text countText;

    public bool coroutineLaunched;

    public bool soundPlayed;

    public AudioSource klaxon;

	// Use this for initialization
	void Start () {
		klaxon = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (countdown >= 0) {
			if (countdown == 0 && !soundPlayed) {
			klaxon.Play();
			soundPlayed = true;
			}
			countText.enabled = true;
			countText.text = countdown.ToString ();
			if (!coroutineLaunched) {
				StartCoroutine(Example());
				coroutineLaunched = true;
			}
		}
		 else {
		  countText.enabled = false;
		  coroutineLaunched = false;
		  soundPlayed = false;
		}

	}


	IEnumerator Example ()
	{
	  // Debug.Log("Countdown :" +Time.time);
	   yield return new WaitForSeconds(1);
	   countdown--;
	   if(countdown>=0)
	       StartCoroutine(Example());
	}



}
