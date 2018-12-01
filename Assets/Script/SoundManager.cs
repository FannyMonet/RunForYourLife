using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script create a singleton of a sound manager for the game
public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioClip[] clip;//List of all the instruments

    public AudioSource[] sourceList;//list of the 4 audioSources


	public int[] indexS;

	//4 AudioSource for the maximum 4 player
	private AudioSource  S1;
	private AudioSource  S2;
	private AudioSource  S3;
	private AudioSource  S4;


	// Use this for initialization
	void Awake ()
	{
	    indexS = new int[4] {-1,-1,-1,-1};
		if (!this.GetComponent<AudioSource> ().isPlaying) {
				this.GetComponent<AudioSource> ().Play();
			}
		if (Instance == null) {

			Instance = this;

		     S1 = GameObject.Find("S1").GetComponent<AudioSource>();
			 S2 = GameObject.Find("S2").GetComponent<AudioSource>();
			 S3 = GameObject.Find("S3").GetComponent<AudioSource>();
			 S4 = GameObject.Find("S4").GetComponent<AudioSource>();

			

			sourceList = new AudioSource[4] {S1,S2,S3,S4};

			DontDestroyOnLoad(Instance.gameObject);


		}
		else if(Instance!=this)
		  Destroy(gameObject);
	}
}
