using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script transmits the character selected between scenes

public class supervisorScript : MonoBehaviour {

    public GameObject[] players;// all the players
    public int number;//the total number of player
    public int numberSelected;//the number of players that has picked their character

    public int lvlNumber;


    void Start ()
	{

		players = new GameObject[4];
		DontDestroyOnLoad(this.gameObject);
		number = 0;
	}

}
