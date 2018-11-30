using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioClip[] clip;

    public AudioSource S1;
	public AudioSource S2;
	public AudioSource S3;
	public AudioSource S4;


	// Use this for initialization
	void Awake ()
	{
	    
		if (Instance == null) {

		    Instance = this;
		    S1 = GameObject.Find("S1").GetComponent<AudioSource>();
			S2 = GameObject.Find("S2").GetComponent<AudioSource>();
			S3 = GameObject.Find("S3").GetComponent<AudioSource>();
			S4 = GameObject.Find("S4").GetComponent<AudioSource>();

			DontDestroyOnLoad(Instance.gameObject);


		}
		else if(Instance!=this)
		Destroy(gameObject);
	}
}
