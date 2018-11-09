using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallBehaviour : MonoBehaviour {

    public Rigidbody2D aRgbd;
    public int Strength;

	// Use this for initialization
	void Start () {
		aRgbd = gameObject.GetComponent<Rigidbody2D>();
		aRgbd.AddForce(new Vector2(-Strength, Strength));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
	    Destroy(gameObject, 0.2f);
	}
}
