using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe_Behaviour : MonoBehaviour {

    public CircleCollider2D circleCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(this.gameObject,1.6f);

		if(circleCollider.radius<1.3)
			circleCollider.radius+=0.02f;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
	    Debug.Log("ENTER");
	    Debug.Log("Bombe est entre en collision avec : "+col.name);
		if (col.name.Equals("1(Clone)")|| col.name.Equals("2(Clone)") || col.name.Equals("3(Clone)")|| col.name.Equals("4(Clone)")) {
			   Destroy(col.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{
	    Debug.Log("STAY");
		Debug.Log("Bombe est entre en collision avec : "+col.name);

		if (col.name.Equals("1(Clone)")|| col.name.Equals("2(Clone)") || col.name.Equals("3(Clone)")|| col.name.Equals("4(Clone)")) {
		   Destroy(col.gameObject);
		}
	}
}
