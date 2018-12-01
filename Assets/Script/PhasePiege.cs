using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhasePiege : MonoBehaviour {

    public GameObject prefab;//The appearance of the trap object
	public GameObject player;//The player 
    public GameObject trap; //the real trap object
    private bool canPlaceHere;//to know if the trap can be placed here

    private GameObject textPhase; // the transition Text
	private GameObject textPhaseShadow; // the transition Text shadow (design only)

	private int waitingTime; // the transition time

	public string playerNumber; // the number of the player



	// Use this for initialization
	void Start () {
		trap.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
		textPhase = GameObject.Find("TextPhase");
		textPhaseShadow = GameObject.Find("TextPhaseShadow");

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!canPlaceHere) {
			trap.GetComponent<SpriteRenderer> ().color = Color.red;
		} else {
			trap.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		if(Input.GetButtonDown ("Fire"+playerNumber)&& canPlaceHere){
		    GameObject trap = prefab;
		    trap.name = playerNumber;
		     //Change the name of the trap in order to know which player instantiated it
			//trap.name = trap.name.Remove(1);


			Instantiate (trap,this.gameObject.transform.position, this.gameObject.transform.rotation);

			GameObject.Find("Supervisor").GetComponent<Supervisor>().trapsSet++;
			Destroy(this.gameObject);
	}
		
	}

	void FixedUpdate ()
	{
		if (Input.GetAxis ("Horizontal" + playerNumber) < -0.1f) {//Allow to move left
			if (this.transform.position.x > -14) {
				this.gameObject.transform.Translate (new Vector3 (-0.1f, 0, 0));
			}
		} else if (Input.GetAxis ("Horizontal" + playerNumber) > 0.1f) {
			if (this.transform.position.x < 15) {
				this.gameObject.transform.Translate (new Vector3 (0.1f, 0, 0));
			}
		}
		if (Input.GetAxis ("Vertical" + playerNumber) < -0.1f) {//Allow to move left
			if (this.transform.position.y > -7) {
				this.gameObject.transform.Translate (new Vector3 (0, -0.1f, 0));
			}
		} else if (Input.GetAxis ("Vertical" + playerNumber) > 0.1f) {
			if (this.transform.position.y < 9) {
				this.gameObject.transform.Translate (new Vector3 (0, 0.1f, 0));
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag.Equals ("NoTrapsHere")) {
		   canPlaceHere = false;
		}
	}
	void OnTriggerStay2D (Collider2D col)
	{

		if (col.tag.Equals ("NoTrapsHere")) {
		   canPlaceHere = false;
		}
	}
	void OnTriggerExit2D (Collider2D col)
	{

		if (col.tag.Equals ("NoTrapsHere")) {
		   canPlaceHere = true;
		}
	}

	public void DestroyPhasePiege ()
	{
		GameObject.Find("Supervisor").GetComponent<Supervisor>().trapsSet++;
		Destroy(this.gameObject);
	}
}
