using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This script controls the cursor in the PlayerSlection scene
public class Move : MonoBehaviour {
    public int playerNumber;//the number of the player, it allows to attribute the prefab to the player
    public float speed; //the speed of the cursor
	public Case caseSelec; // the selected case 
    public Aleatoire listeAleatoire; // 
    public supervisorScript supervisor;//The reference to the pre-supervisor

    private bool clicked; 

    public SoundManager soundManager;

    void Start ()
	{
	     listeAleatoire = GameObject.Find("Aleatoire").GetComponent<Aleatoire>();
		 supervisor = GameObject.Find("Presupervisor").GetComponent<supervisorScript>();
		 soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}

	void Update ()
	{
		clicked = false;
		if(Input.GetButtonDown ("Fire" + playerNumber.ToString ())){
		    clicked = true;
		}

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal" + playerNumber.ToString ());
		float v = Input.GetAxis ("Vertical" + playerNumber.ToString ());

		if (Input.GetAxis ("Horizontal" + playerNumber.ToString ()) > 0.01f) {
			if (this.transform.position.x < 13) {
				this.transform.Translate (new Vector3 (h * speed, 0, 0));
			}
		} else if (Input.GetAxis ("Horizontal" + playerNumber.ToString ()) < -0.01f) {
			if (this.transform.position.x > -13) {
				this.transform.Translate (new Vector3 (h * speed, 0, 0));
			}
		}

		if (Input.GetAxis ("Vertical" + playerNumber.ToString ()) > 0.01f) {
			if (this.transform.position.y < 6) {
				this.transform.Translate (new Vector3 (0, v * speed, 0));
			}
		} else if (Input.GetAxis ("Vertical" + playerNumber.ToString ()) < -0.01f) {
			if (this.transform.position.y > -6) {
				this.transform.Translate (new Vector3 (0, v * speed, 0));

			}
		}
	}
    void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Alea")) {
		other.GetComponent<SpriteRenderer>().color = Color.gray;
		}
        else if (other.CompareTag("Case"))
        {
            other.GetComponent<Animator>().enabled = true;
        }

		if (clicked) {
			if (other.CompareTag ("Case")) {
				GameObject.FindWithTag ("ImageP" + playerNumber).transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);
				GameObject.FindWithTag ("ImageP" + playerNumber+"Shadow").transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);

				if (caseSelec != null)
					Unselected (other);
				else {
					supervisor.numberSelected += 1;

				}
				Selected (other);
				supervisor.players [playerNumber - 1] = other.gameObject.GetComponent<Case> ().prefab;
			}

			if (other.CompareTag ("Alea")) {
				int rand = Random.Range (0, 10);
				Case caseSel = listeAleatoire.listePerso [rand];
				Debug.Log (rand);
				GameObject.FindWithTag ("ImageP" + playerNumber).transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);
				GameObject.FindWithTag ("ImageP" + playerNumber+"Shadow").transform.localScale = new Vector3 (5.832718F, 6.893026F, 1F);

				if (caseSelec != null) {
					UnselectAlea (caseSel);
				} else {
					supervisor.numberSelected += 1;
				}
                    
				SelectAlea (caseSel);
			}

			if (other.CompareTag ("Start")) {
			    SceneManager.LoadScene(supervisor.lvlNumber);
			}

        }

    }

    void OnTriggerExit2D (Collider2D col)
	{
		if (col.CompareTag ("Alea")) {
			col.GetComponent<SpriteRenderer> ().color = Color.white;
		} else if (col.CompareTag ("Case")) {
		    col.GetComponent<Animator>().enabled = false;
		}
	}

    void Unselected(Collider2D other)
    {
        if (GameObject.FindWithTag("ImageP"+playerNumber).GetComponent<SpriteRenderer>().sprite != other.GetComponent<Case>().sprite)
        {
			caseSelec.GetComponent<SpriteRenderer>().color = Color.white;

            caseSelec.GetComponent<Collider2D>().enabled = true;
            caseSelec.GetComponent<Case>().selected = false;
            caseSelec = null;
        }
    }

    void Selected(Collider2D other)
    {
		other.GetComponent<SpriteRenderer>().color = Color.gray;
        other.GetComponent<Collider2D>().enabled = false;
        //other.gameObject.transform.localScale = new Vector3(0.7665361F, 0.7969171F, 0);
        GameObject.FindWithTag("ImageP"+playerNumber).GetComponent<SpriteRenderer>().sprite = other.GetComponent<Case>().sprite;
		GameObject.FindWithTag("ImageP"+playerNumber+"Shadow").GetComponent<SpriteRenderer>().sprite = other.GetComponent<Case>().sprite;

        other.GetComponent<Case>().selected = true;
        caseSelec = other.GetComponent<Case>();
		bool isInListe;
		int rand;
        do{
            isInListe = false;
			rand = Random.Range(0,8);
            for(int i =0; i<soundManager.indexS.Length; i++)
            {
				if(rand==soundManager.indexS[i])
				{
				  isInListe = true;
				}
            }

        } while(isInListe);
       
		soundManager.indexS[playerNumber-1] = rand;
		soundManager.sourceList[playerNumber-1].clip = soundManager.clip[rand];

		soundManager.sourceList[0].Play();
		soundManager.sourceList[1].Play();
		soundManager.sourceList[2].Play();
		soundManager.sourceList[3].Play();

		

    }

    void SelectAlea (Case caseSel)
	{
		if (!caseSel.selected) {
			caseSel.GetComponent<SpriteRenderer>().color = Color.gray;

			caseSel.gameObject.GetComponent<Collider2D> ().enabled = false;
			caseSel.gameObject.transform.localScale = new Vector3 (0.7665361F, 0.7969171F, 0);
			GameObject.FindWithTag ("ImageP" + playerNumber).GetComponent<SpriteRenderer> ().sprite = caseSel.sprite;
			GameObject.FindWithTag ("ImageP" + playerNumber+"Shadow").GetComponent<SpriteRenderer> ().sprite = caseSel.sprite;
			caseSel.gameObject.GetComponent<Case> ().selected = true;
			caseSelec = caseSel;
			supervisor.players[playerNumber-1] = caseSel.gameObject.GetComponent<Case>().prefab;

			bool isInListe;
		   int rand;
        do{
            isInListe = false;
			rand = Random.Range(0,8);
            for(int i =0; i<soundManager.indexS.Length; i++)
            {
				if(rand==soundManager.indexS[i])
				{
				  isInListe = true;
				}
            }

        } while(isInListe);
       
		soundManager.indexS[playerNumber-1] = rand;
		soundManager.sourceList[playerNumber-1].clip = soundManager.clip[rand];

		soundManager.sourceList[0].Play();
		soundManager.sourceList[1].Play();
		soundManager.sourceList[2].Play();
		soundManager.sourceList[3].Play();



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
			caseSelec.GetComponent<SpriteRenderer>().color = Color.white;

            caseSelec.gameObject.GetComponent<Collider2D>().enabled = true;
            caseSelec.gameObject.GetComponent<Case>().selected = false;
            caseSelec = null;
        }
    }
}
