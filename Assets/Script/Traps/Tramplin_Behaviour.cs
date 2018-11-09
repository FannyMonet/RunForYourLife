using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin_Behaviour : MonoBehaviour {


    public Animator anim;


	// Use this for initialization
	void Start () {
	anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			anim.SetTrigger ("TramplinActif");
			col.GetComponent<Movement >().aRgbd.velocity = new Vector2 (col.GetComponent<Movement >().aRgbd.velocity.x, 150);
		}
	}
}
