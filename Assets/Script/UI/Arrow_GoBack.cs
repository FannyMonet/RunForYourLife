using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Arrow_GoBack : MonoBehaviour {


    public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{

	   

	}
	void OnTriggerStay2D (Collider2D col)
	{

	    anim.SetTrigger("isTouching");
		int playerNumber = int.Parse(col.name);
		if (Input.GetButton ("Fire"+playerNumber)) {
		    Destroy(GameObject.Find("Pre-supervisor"));
		    SceneManager.LoadScene(0);
		}

	}

}
