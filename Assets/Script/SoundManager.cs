using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

	// Use this for initialization
	void Awake ()
	{
	    
		if (Instance == null) {

		Instance = this;
			DontDestroyOnLoad(Instance.gameObject);

		}
		else if(Instance!=this)
		Destroy(gameObject);
	}
}
