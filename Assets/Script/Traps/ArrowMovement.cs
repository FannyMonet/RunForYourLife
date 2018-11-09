using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

    public Animator anim;
    public bool contact;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("contact", contact);
		if (!contact) {
			
			this.transform.Translate (0.1f, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
	    contact = true;
	    Destroy(gameObject, 0.2f);
	}
}
