﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The bomb destroys all traps that enter its area
public class Bombe_Behaviour : MonoBehaviour {

    public CircleCollider2D circleCollider;

    public bool hasExploded;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Destroy (this.gameObject, 1.6f);

		if (!hasExploded) {
		GetComponent<AudioSource>().Play();
		hasExploded = true;
		}

		if(circleCollider.radius<1.5)
			circleCollider.radius+=0.02f;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.name.Equals("1(Clone)")|| col.name.Equals("2(Clone)") || col.name.Equals("3(Clone)")|| col.name.Equals("4(Clone)")) {
			   Destroy(col.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{

		if (col.name.Equals("1(Clone)")|| col.name.Equals("2(Clone)") || col.name.Equals("3(Clone)")|| col.name.Equals("4(Clone)")) {
		   Destroy(col.gameObject);
		}
	}
}
