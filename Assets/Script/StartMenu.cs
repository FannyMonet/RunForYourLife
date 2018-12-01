using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is used to animate the main menu.
//When the player touches a roc, it plays the animation of it
public class StartMenu : MonoBehaviour {

    public Animator anim;
    public GameObject buttonA;
    public int SceneToLoad;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        buttonA.gameObject.SetActive(false);
    }
	
    void OnTriggerEnter2D (Collider2D col)
	{
		if (!col.CompareTag ("background")) {
          
			anim.SetBool ("playerTouch", true);
			buttonA.gameObject.SetActive (true);

		}
	}

    void OnTriggerStay2D (Collider2D col)
	{
		if (!col.CompareTag ("background")) {
			anim.SetBool ("playerTouch", true);
			if(Input.GetButtonDown("Fire1"))
               SceneManager.LoadScene(SceneToLoad);
           
		}
        
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("background"))
        {
            anim.SetBool("playerTouch", false);
            buttonA.gameObject.SetActive(false); 
        }
    }
}
