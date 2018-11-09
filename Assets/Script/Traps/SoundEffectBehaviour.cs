using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectBehaviour : MonoBehaviour {

	// Use this for initialization
	public float direction; //0.1f to go right
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (direction, 0, 0);
		if (transform.localScale.x < 0.1f) {
			Destroy(gameObject);
		}
	}
}
