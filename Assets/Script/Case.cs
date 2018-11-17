using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
