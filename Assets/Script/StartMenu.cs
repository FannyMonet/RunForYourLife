using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
			if(Input.GetButton("Fire1"))
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
