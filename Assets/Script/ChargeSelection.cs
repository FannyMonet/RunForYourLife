using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChargeSelection : MonoBehaviour
{

    public GameObject buttonA;
    public int SceneToLoad;

    public supervisorScript preSupervisor;

    // Use this for initialization
    void Start()
    {
        buttonA.gameObject.SetActive(false);
        preSupervisor = GameObject.Find("Presupervisor").GetComponent<supervisorScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("background"))
        {
            buttonA.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D (Collider2D col)
	{
		if (!col.CompareTag ("background")) {
			if (Input.GetButtonDown ("Fire1")) {
			    preSupervisor.lvlNumber = SceneToLoad;
				SceneManager.LoadScene (2);//Player selection
			}

        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("background"))
        {
            buttonA.gameObject.SetActive(false);
        }
    }
}
