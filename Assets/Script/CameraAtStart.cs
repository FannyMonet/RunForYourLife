using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is here to organize the stagging of the scene.
//At first, it freezes players movement .
//Then it changes the camera position with a translation and a reduction of the scale in order to show the player it position and where it has to go
//Finally, it show a countdown with a sound for each number.
//When the countdown is over, player's movement are unfreezed.

public class CameraAtStart : MonoBehaviour {

	public Transform target;
    public float speed;
    public float introTime;
    public float cameraSize;
    public float cameraFinalSize;
    public bool cameraIsSet;
	public bool StartingGame;

	public bool[] sounds;
    public float time;

    public Text colour;
    public Text shadow;

    public AudioSource ambianceSound;
    public AudioClip[] clips;


	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 5f;

  
	// Use this for initialization
	void Start () {
		cameraSize = this.gameObject.GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
		
     void Update ()
	{
		if (!StartingGame) {//if the game has'nt started yet
			if (introTime < 0) {//if the camera at it proper place
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards (transform.position, target.position, step);
				if (cameraSize < cameraFinalSize) {
					cameraSize += 0.08f;
					this.gameObject.GetComponent<Camera> ().orthographicSize += 0.08f;
				} 
				else {//if the camera is at the proper place
					time -= Time.deltaTime;
					colour.text = ((int)time + 1).ToString ();
					shadow.text = ((int)time + 1).ToString ();
					if(((int)time + 1)==3 && !sounds[0])
					{
					    Shake();
						sounds[0]= true;
						ambianceSound.PlayOneShot (clips [0]);

					}
					else if(((int)time + 1)==2 && !sounds[1])
					{
						Shake();

						sounds[1]= true;
						ambianceSound.PlayOneShot (clips [1]);
					}
					else if(((int)time + 1)==1 && !sounds[2])
					{
						Shake();

						sounds[2]= true;
						ambianceSound.PlayOneShot (clips [2]);
					}
					if (time < 0 && time > -1) {
						if (!StartingGame) {
							ambianceSound.PlayOneShot (clips [3]);
							StartingGame = true;
							colour.text = "";
						    shadow.text = "";
						}
					}


				}

			} else
				introTime -= 0.1f;
			//////////////////////////////////////////


		}

	
	}
	public void Shake(){

	transform.localPosition = transform.localPosition + Random.insideUnitSphere*shakeAmount;


	}
}
