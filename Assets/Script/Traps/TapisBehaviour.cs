using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisBehaviour : MonoBehaviour {

    public int sens;

	// Use this for initialization
	void Start () {
		sens = 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.attachedRigidbody != null && col.CompareTag ("Player")) {
	      col.attachedRigidbody.AddForce(new Vector2(100*sens,0));
	   }

	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.attachedRigidbody != null && col.CompareTag ("Player")) {
	      col.attachedRigidbody.AddForce(new Vector2(100*sens,0));
	   }

	}
}
