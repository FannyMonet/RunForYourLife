using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dezoom : MonoBehaviour {
    public float width = 1;
    public float height = 1;

    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Alea")) {
		    return;
		}
        else if (other.gameObject.CompareTag("Cursor1"))
        {
            this.GetComponent<Animator>().enabled = true;
        }
        else if (other.gameObject.CompareTag("Cursor2"))
        {
			this.GetComponent<Animator>().enabled = true;
        }
       else if (other.gameObject.CompareTag("Cursor3"))
        {
			this.GetComponent<Animator>().enabled = true;
        }
        else if (other.gameObject.CompareTag("Cursor4"))
        {
			this.GetComponent<Animator>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("Alea")) {
		    return;
		}
        else if (other.gameObject.CompareTag("Cursor1"))
        {
			this.GetComponent<Animator>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Cursor2"))
        {
			this.GetComponent<Animator>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Cursor3"))
        {
			this.GetComponent<Animator>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Cursor4"))
        {
			this.GetComponent<Animator>().enabled = false;
        }
    }
}
