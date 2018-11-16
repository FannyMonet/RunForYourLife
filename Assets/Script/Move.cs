using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {
    public int playerNumber;
    public float speed;
	public Case caseSelec;
    public Aleatoire listeAleatoire;
    public supervisorScript supervisor;

    void Start ()
	{
	     listeAleatoire = GameObject.Find("Aleatoire").GetComponent<Aleatoire>();
		 supervisor = GameObject.Find("Pre-supervisor").GetComponent<supervisorScript>();
	}


	// Update is called once per frame
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal" +playerNumber.ToString());
        float v = Input.GetAxis("Vertical" + playerNumber.ToString());

		if (Input.GetAxis("Horizontal"+playerNumber.ToString()) > 0.01f)
            this.transform.Translate( new Vector3(h * speed, 0, 0));
		else if(Input.GetAxis("Horizontal"+playerNumber.ToString()) <- 0.01f)
                        this.transform.Translate(new Vector3(h * speed, 0, 0));

		if (Input.GetAxis("Vertical"+playerNumber.ToString()) > 0.01f)
            this.transform.Translate(new Vector3(0,v * speed, 0));
		else if (Input.GetAxis("Vertical"+playerNumber.ToString()) < -0.01f)
            this.transform.Translate(new Vector3(0, v * speed, 0));

    }

    void OnTriggerStay2D (Collider2D other)
	{
		if (Input.GetButtonDown ("Fire" + playerNumber.ToString ())) {
			if (other.gameObject.CompareTag ("Case")) {
				GameObject.FindWithTag ("ImageP" + playerNumber).transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);
				if (caseSelec != null)
					Unselected (other);
				else {
					supervisor.numberSelected += 1;
				}
				Selected (other);
				supervisor.players [playerNumber - 1] = other.gameObject.GetComponent<Case> ().prefab;
			}

			if (other.gameObject.CompareTag ("Alea")) {
				int rand = Random.Range (0, 10);
				Case caseSel = listeAleatoire.listePerso [rand];
				Debug.Log (rand);
				GameObject.FindWithTag ("ImageP" + playerNumber).transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);

				if (caseSelec != null) {
					UnselectAlea (caseSel);
				} else {
					supervisor.numberSelected += 1;
				}
                    
				SelectAlea (caseSel);
			}

			if (other.gameObject.CompareTag ("Start")) {
			    SceneManager.LoadScene(1);
			}
        }
        
    }

    void Unselected(Collider2D other)
    {
        if (GameObject.FindWithTag("ImageP"+playerNumber).GetComponent<SpriteRenderer>().sprite != other.GetComponent<Case>().sprite)
        {
            caseSelec.GetComponent<Collider2D>().enabled = true;
            caseSelec.GetComponent<Case>().selected = false;
            caseSelec = null;
        }
    }

    void Selected(Collider2D other)
    {
        other.GetComponent<Collider2D>().enabled = false;
        other.gameObject.transform.localScale = new Vector3(0.7665361F, 0.7969171F, 0);
        GameObject.FindWithTag("ImageP"+playerNumber).GetComponent<SpriteRenderer>().sprite = other.GetComponent<Case>().sprite;
        other.GetComponent<Case>().selected = true;
        caseSelec = other.GetComponent<Case>();
    }

    void SelectAlea (Case caseSel)
	{
		if (!caseSel.selected) {
			caseSel.gameObject.GetComponent<Collider2D> ().enabled = false;
			caseSel.gameObject.transform.localScale = new Vector3 (0.7665361F, 0.7969171F, 0);
			GameObject.FindWithTag ("ImageP" + playerNumber).GetComponent<SpriteRenderer> ().sprite = caseSel.sprite;
			caseSel.gameObject.GetComponent<Case> ().selected = true;
			caseSelec = caseSel;
			supervisor.players[playerNumber-1] = caseSel.gameObject.GetComponent<Case>().prefab;

		} else {

			int rand = Random.Range(0, 10);
			Debug.Log("Rand :" + rand);

			SelectAlea(listeAleatoire.listePerso[rand]);
		}
    }

    void UnselectAlea(Case caseSel)
    {
        if (GameObject.FindWithTag("ImageP"+playerNumber).GetComponent<SpriteRenderer>().sprite != caseSel.sprite)
        {
            caseSelec.gameObject.GetComponent<Collider2D>().enabled = true;
            caseSelec.gameObject.GetComponent<Case>().selected = false;
            caseSelec = null;
        }
    }
}
