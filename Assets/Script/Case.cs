using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is used in the selection of character scene.
//it only plays the character's sound if the cursor of the player touch a non-selected Case

public class Case : MonoBehaviour {
    public Sprite sprite;
    public GameObject prefab;
    public bool selected;
    public AudioClip clip;

	void OnTriggerEnter2D (Collider2D col)
	{
	if(!selected)
	    col.GetComponent<AudioSource>().PlayOneShot(clip, 1f);
	}
}
