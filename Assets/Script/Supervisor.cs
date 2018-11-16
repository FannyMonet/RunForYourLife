using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Supervisor : MonoBehaviour {

    public static bool created;
	public GameObject J1;
	public GameObject J2;
	public GameObject J3;
	public GameObject J4;
    public GameObject[] listOfAvatar;
	public GameObject[] listOfAvatarInstantiated;
	public GameObject[] TrapList;
    public int playerNbr;
    public int trapsSet;
    public supervisorScript presupervisor;

	public bool BoardIsDown;


	public int[] order;

    public int[] scores;

    private int waitingTime;

    private bool trapSetOk;

	public GameObject[] spawner;

	public bool test;

	// Use this for initialization
	void Awake ()
	{
		presupervisor = GameObject.Find ("Pre-supervisor").GetComponent<supervisorScript> ();
		playerNbr = presupervisor.number;
		listOfAvatar = new GameObject[playerNbr];
		scores = new int[playerNbr];

		listOfAvatarInstantiated = listOfAvatar;
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
			waitingTime = 120;
			spawner = new GameObject[4];
			for (int i = 0; i < presupervisor.number; i++) {
				listOfAvatar [i] = presupervisor.players [i];
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (!test) {
			spawner [0] = GameObject.Find ("J1");
			spawner [1] = GameObject.Find ("J2");
			spawner [2] = GameObject.Find ("J3");
			spawner [3] = GameObject.Find ("J4");
			//
			for (int i = 0; i < playerNbr; i++) {

				listOfAvatar [i].GetComponent<Movement> ().playerNumber = (i + 1).ToString ();
				Instantiate (listOfAvatar [i], spawner [i].transform.position, Quaternion.identity);
				//GameObject.Find("FLAG").GetComponent<FlagBehaviourScript>().nbPlayers


			}
			test = true;//remove this line
			//Arrive dans la map = false;
			//}
		}

		if (playerNbr == trapsSet && !trapSetOk) {
			GameObject.Find ("TextPhase").GetComponent<Text> ().text = "Phase Course";
			GameObject.Find ("TextPhaseShadow").GetComponent<Text> ().text = "Phase Course";

			GameObject.Find ("TextPhase").GetComponent<Animator> ().SetTrigger ("ActivatePhase");
			GameObject.Find ("TextPhaseShadow").GetComponent<Animator> ().SetTrigger ("ActivatePhase");
			trapSetOk = true;
		} 
		if (trapSetOk) {
			if (waitingTime < 0) {
				for (int i = 0; i < playerNbr; i++) {
					Instantiate(listOfAvatar[i],spawner[i].transform.position, Quaternion.identity);
				}
				trapsSet = 0;
				waitingTime = 120;
				trapSetOk = false;
			} else
				waitingTime--;
		}
	}


	public int[] sortScore ()
	{
		int highest = 11;
		int higher;
		order = new int[playerNbr];
		ArrayList ind = new ArrayList ();
		for (int i = 1; i <= playerNbr; i++) {
			higher = -1;
			ind.Clear ();
			for (int j = 0; j < playerNbr; j++) {
			Debug.Log(higher);
				if (scores [j] > higher && scores [j] < highest) {
					higher = scores [j];
					ind.Clear ();
					ind.Add (j);
				} else if (scores [j] == higher) {
					ind.Add (j);
				}


			}
			foreach (int machin in ind) {
			   order[machin] = i;
			}
			i+=ind.Count-1;
			highest = higher;
		}
		return order;
	}

}

