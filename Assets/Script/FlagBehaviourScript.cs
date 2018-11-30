using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	public Image winnerSprite;

    public Animator pictureScore;
    public Animator WinPanel;
    public GameObject textPhase;
    public GameObject textPhaseShadow;

    public Supervisor supervisor;

    public GameObject tropFacile;

    public int n1;
	public int n2;
	public int n3;
	public int n4;
	public int n5;

	public int scoreMax;
	public bool aGagne;
	public int gagnant;
	public bool partieFinie;

	public Countdown countdown;

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
		winnerSprite = GameObject.Find("Sprite Winner").GetComponent<Image>();
		pictureScore = GameObject.Find("pictureScore").GetComponent<Animator>();
		WinPanel = GameObject.Find("WINNER").GetComponent<Animator>();

		textPhase = GameObject.Find("TextPhase");
		textPhaseShadow = GameObject.Find("TextPhaseShadow");

		scoresProvisoires = new int[nbPlayers];
		scoresKills = new int[nbPlayers];
		premier = true;
		boardDown = false;
		scoresKills = new int[nbPlayers];
		scoreMax = 9;

		countdown = GameObject.Find("Countdown").GetComponent<Countdown>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (countdown.countdown == 0) {
			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject p in players) {
				if (p.GetComponent<Movement> ().enabled) {
					p.GetComponent<Movement> ().countdownEnd ();
				}
			}
		}
		if (nbPlayers == nbFinis && !partieFinie) {
		    countdown.countdown = -1;
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


						//
					}
				}
				if (someoneDead) {
					tropFacile.SetActive (false);//Si quelqu'un perd, "trop facile disparait"
					//Debug.Log("TropFacileDesactive");
					for (int i = 0; i < nbPlayers; i++) {
						if (playerList [i] != null) {
							supervisor.scores [int.Parse (playerList [i].GetComponent<Movement> ().playerNumber) - 1] += scoresProvisoires [int.Parse (playerList [i].GetComponent<Movement> ().playerNumber) - 1];
							if (supervisor.scores [int.Parse (playerList [i].GetComponent<Movement> ().playerNumber) - 1] > scoreMax) {
								scoreMax = supervisor.scores [int.Parse (playerList [i].GetComponent<Movement> ().playerNumber) - 1];
								aGagne = true;
								gagnant = int.Parse (playerList [i].GetComponent<Movement> ().playerNumber) - 1;
							} 
						}
					}

				}
				for (int i = 0; i < supervisor.playerNbr; i++)
					Destroy (playerList [i]);
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

				if (Input.GetButton ("Fire1") || Input.GetButton ("Fire2") || Input.GetButton ("Fire3") || Input.GetButton ("Fire4")) {
					if (!aGagne) {
						pictureScore.SetTrigger ("RemonteTableau");
						boardUp = true;
						boardDown = false;
						supervisor.BoardIsDown = false;
					} else {
						winnerSprite.sprite = supervisor.listOfAvatar [gagnant].GetComponent<SpriteRenderer> ().sprite;
						WinPanel.SetTrigger ("down");
						partieFinie = true;
					}
				}
				/*else if (unjoueurAsGagne)*/
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
					bomb = Random.Range (0, supervisor.playerNbr);
				}
				for (int i = 0; i < nbPlayers; i++) {
					playerTrapList.GetComponentInChildren<SpriteRenderer> ().sprite = supervisor.listOfAvatar [i].GetComponent<SpriteRenderer> ().sprite;
					playerTrapList.GetComponentInChildren<Animator> ().runtimeAnimatorController = supervisor.listOfAvatar [i].GetComponent<Animator> ().runtimeAnimatorController;
					playerTrapList.GetComponent<PhasePiege> ().playerNumber = (i + 1).ToString ();

					if (order [i] == 1) {
						if (nbPlayers == 2) {
							rand = Random.Range (0, n4 + 1);
						} else if (nbPlayers == 3) {
							rand = Random.Range (0, n3 + 1);
						} else {
							rand = Random.Range (0, n2 + 1);
						}
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];//0
					} else if (order [i] == 2) {
						if (nbPlayers == 2) {
							rand = Random.Range (n1 + 1, n5 + 1);
						} else if (nbPlayers == 3) {
							rand = Random.Range (n1 + 1, n4 + 1);
						} else {
							rand = Random.Range (n1 + 1, n3 + 1);
						}
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];//2 et 3
					} else if (order [i] == 3) {
						if (nbPlayers == 3) {
							rand = Random.Range (n2 + 1, n5 + 1);
						} else {
							rand = Random.Range (n2 + 1, n4 + 1);
						}
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];
					} else if (order [i] == 4) {
						rand = Random.Range (n3 + 1, n5 + 1);
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [rand];
					}

					if (i == bomb) {
						playerTrapList.GetComponent<PhasePiege> ().prefab = supervisor.TrapList [0];
					}


					Debug.Log ("Le " + i + " e element a eu pour random : " + rand); 
					Instantiate (playerTrapList, supervisor.spawner [i].transform.position, Quaternion.identity);

				}
				nbFinis = 0;
				waitingTime = waitingTimeAtStart;
				waitingTime2 = waitingTimeAtStart;
				waitingTime3 = waitingTimeAtStart;
				waitingTime4 = waitingTimeAtStart * 2;
				boardDown = false;
				boardUp = false;
				endCinematic = false;
				someoneDead = false;
				supervisor.phasePiege = true;
				countdown.countdown = 15;





			} else if (endCinematic) {
				waitingTime4--;

			}

		

				
					
				
		} else if (partieFinie) {
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2") || Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire4")) {
				Destroy (supervisor.gameObject);
				Destroy (GameObject.Find ("Presupervisor"));
				Destroy(GameObject.Find ("SoundManager"));
				SceneManager.LoadScene (0);
			}
		}
	}

	

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Player") && !col.GetComponent<Movement>().dead) {
		    playerList[nbFinis] = col.gameObject;
			nbFinis += 1;
			col.GetComponent<Movement>().enabled=false;
			col.GetComponent<Rigidbody2D>().AddForce(new Vector2(-col.GetComponent<Rigidbody2D>().velocity.x,-20));

		}
	}
}
