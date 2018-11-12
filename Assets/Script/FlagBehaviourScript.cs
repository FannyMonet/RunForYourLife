using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagBehaviourScript : MonoBehaviour {

    public int nbPlayers;
    public int nbFinis;

    public GameObject[] playerList;
    public GameObject playerTrapList;
	public int waitingTimeAtStart;
    private int waitingTime;
    private int waitingTime2;
	private int waitingTime3;
	private int waitingTime4;
	private bool premier;
	public bool someoneDead;
	private int[] scoresProvisoires;
	public int[] scoresKills;

    public bool boardDown;
	public bool boardUp;
	public bool endCinematic;

    public Animator pictureScore;
    public GameObject textPhase;
    public GameObject textPhaseShadow;

    public Supervisor supervisor;

    public GameObject tropFacile;

    public int n1;
	public int n2;
	public int n3;
	public int n4;
	public int n5;

	// Use this for initialization
	void Start () {
	    supervisor = GameObject.Find("Supervisor").GetComponent<Supervisor>();
		nbPlayers = supervisor.playerNbr;
		playerList =new GameObject[nbPlayers];// supervisor.listOfAvatar;
		waitingTime = waitingTimeAtStart;
		waitingTime2 = waitingTimeAtStart;
		waitingTime3 = waitingTimeAtStart;
		waitingTime4 = waitingTimeAtStart*2;

		tropFacile = GameObject.Find("tropFacile");
		pictureScore = GameObject.Find("pictureScore").GetComponent<Animator>();
		textPhase = GameObject.Find("TextPhase");
		textPhaseShadow = GameObject.Find("TextPhaseShadow");

		scoresProvisoires = new int[nbPlayers];
		scoresKills = new int[nbPlayers];
		premier = true;
		boardDown = false;
		scoresKills = new int[nbPlayers];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (nbPlayers == nbFinis) {

			tropFacile.SetActive (!someoneDead);//Reinitialisation du tableau des scores, le message "trop facile" reapparait

			waitingTime--;
			if (waitingTime < 0 && !boardDown && !(boardUp || endCinematic)) {
				textPhase.GetComponent<Text> ().text = "Phase Piege";
				textPhaseShadow.GetComponent<Text> ().text = "Phase Piege";




				for (int i = 0; i < nbPlayers; i++) {
					GameObject currentPlayer = playerList [i];
					if (currentPlayer != null) {
						Debug.Log ("Player number : " + i);
						if (currentPlayer.GetComponent<Movement> ().dead) {
							someoneDead = true;
						} else {
							if (premier) {
								scoresProvisoires [int.Parse (currentPlayer.GetComponent<Movement> ().playerNumber) - 1] = 2 + scoresKills [int.Parse (currentPlayer.GetComponent<Movement> ().playerNumber) - 1];
								premier = false;
							} else {
								scoresProvisoires [int.Parse (currentPlayer.GetComponent<Movement> ().playerNumber) - 1] = 1 + scoresKills [int.Parse (currentPlayer.GetComponent<Movement> ().playerNumber) - 1];
							}

						}


						Destroy (playerList [i]);
					}
				}
				if (someoneDead) {
					tropFacile.SetActive (false);//Si quelqu'un perd, "trop facile disparait"
					//Debug.Log("TropFacileDesactive");
					for (int i = 0; i < nbPlayers; i++) {
						supervisor.scores [i] += scoresProvisoires [i];
					}
				}
				pictureScore.SetTrigger ("DescendTableau");
				boardDown = true;
				supervisor.BoardIsDown = true;
				premier = true;
				scoresProvisoires = new int[nbPlayers];
				scoresKills = new int[nbPlayers];

			}
			if (boardDown)
				waitingTime2--;
			if (waitingTime2 < 0 && boardDown) {
				if (Input.GetButton ("Fire1")) {
					pictureScore.SetTrigger ("RemonteTableau");
					boardUp = true;
					boardDown = false;
					supervisor.BoardIsDown = false;

				}
			}
			if (waitingTime3 < 0 && boardUp) {
				textPhase.GetComponent<Animator> ().SetTrigger ("ActivatePhase");
				textPhaseShadow.GetComponent<Animator> ().SetTrigger ("ActivatePhase");
				endCinematic = true;
				boardUp = false;
			} else if (boardUp) {
				waitingTime3--;
			}

			if (waitingTime4 < 0 && endCinematic) {
				int[] order = supervisor.sortScore ();
				int rand = 0;
				int bomb = 4;
				//Get all traps in scene
				GameObject[] listOfTraps = GameObject.FindGameObjectsWithTag ("Trap");
				if (listOfTraps.Length > 5) {
					bomb = Random.Range (0, 4);
				}
				for (int i = 0; i < nbPlayers; i++) {
					playerTrapList.GetComponentInChildren<SpriteRenderer> ().sprite = supervisor.listOfAvatar [i].GetComponent<SpriteRenderer> ().sprite;
					playerTrapList.GetComponentInChildren<Animator> ().runtimeAnimatorController = supervisor.listOfAvatar [i].GetComponent<Animator> ().runtimeAnimatorController;
					playerTrapList.GetComponent<PhasePiege> ().playerNumber = (i + 1).ToString ();

					if (order [i] == 1) {
						rand = Random.Range (0, n2 + 1);
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];//0
					} else if (order [i] == 2) {
						rand = Random.Range (n1 + 1, n3 + 1);
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];//2 et 3
					} else if (order [i] == 3) {
						rand = Random.Range (n2 + 1, n4 + 1);
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];
					} else if (order [i] == 4) {
						rand = Random.Range (n3 + 1, n5 + 1);
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];
					}
					if (i == bomb) {
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [0];
					}


					Debug.Log("Le "+i+" e element a eu pour random : "+rand); 
					Instantiate (playerTrapList, supervisor.spawner [i].transform.position, Quaternion.identity);
				}
				nbFinis = 0;
				waitingTime = waitingTimeAtStart;
				waitingTime2 = waitingTimeAtStart;
				waitingTime3 = waitingTimeAtStart;
				waitingTime4 = waitingTimeAtStart*2;
				boardDown = false;
				boardUp = false;
				endCinematic = false;
				someoneDead = false;



			} else if (endCinematic) {
			waitingTime4--;

			}

				
					
				
		}
			}

	

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Player")) {
		    playerList[nbFinis] = col.gameObject;
			nbFinis += 1;
			col.GetComponent<Movement>().enabled=false;
			col.GetComponent<Rigidbody2D>().AddForce(new Vector2(-col.GetComponent<Rigidbody2D>().velocity.x,0));

		}
	}
}
