using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supervisorScript : MonoBehaviour {

    public GameObject[] players;
    public int number;
    public int numberSelected;

    public int lvlNumber;


    void Start ()
	{

		players = new GameObject[4];
		DontDestroyOnLoad(this.gameObject);
		number = 0;
	}

}
