using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This trap move during the game so this script reinitialize the trap position at every run phases
public class PlanchePiege_Behaviour : MonoBehaviour {

    public Vector3 pos_;
    public FlagBehaviourScript flag;

	// Use this for initialization
	void Start () {
	    pos_ = transform.position;	
	    flag = GameObject.Find("FLAG").GetComponent<FlagBehaviourScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flag.boardDown) {
		this.transform.position = pos_;
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
	}
}
