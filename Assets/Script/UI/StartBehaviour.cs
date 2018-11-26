using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBehaviour : MonoBehaviour {

    public GameObject StartButton;
    public supervisorScript supervisor;

	// Use this for initialization
	void Start () {
		StartButton = GameObject.Find("Start");
		StartButton.SetActive(false);
		supervisor = GameObject.Find("Presupervisor").GetComponent<supervisorScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (supervisor.number >= 2 && supervisor.numberSelected == supervisor.number) {
			StartButton.SetActive (true);
		} else {
		    StartButton.SetActive(false);
		}
	}
}
