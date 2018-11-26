using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public bool player1IsIn;
	public bool player2IsIn;

	public bool player3IsIn;
	public bool player4IsIn;

	public Text textCantJoin;

	public supervisorScript supervisor;

  public Animator anim;

    void Start()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
		supervisor = GameObject.Find("Pre-supervisor").GetComponent<supervisorScript>();
  //  anim = textCantJoin.gameObject.GetComponent<Animator>();
    }
    void Update ()
	{

	    //textCantJoin.text.
		if (Input.GetButtonDown ("Fire1")) {
			Player1.SetActive (true);
			if (!player1IsIn) {
				supervisor.number += 1;
				player1IsIn = true;
			}



		}

		if (Input.GetButtonDown ("Fire2")) {
			if (player1IsIn) {
				Player2.SetActive (true);
				if (!player2IsIn) {
					supervisor.number += 1;
					player2IsIn = true;
				}
			} else {
        anim.SetTrigger("TryToJoin");
			    textCantJoin.text = "le premier joueur doit etre connecte pour que le second rejoigne la partie !";
			}
		}
		if (Input.GetButtonDown ("Fire3")) {
      if(player2IsIn){
			Player3.SetActive (true);
      if (!player3IsIn) {
        supervisor.number += 1;
        player3IsIn = true;
      }
    }
      else {
        anim.SetTrigger("TryToJoin");

          textCantJoin.text = "le second joueur doit etre connecte pour que le troisieme rejoigne la partie !";
      }
    }

		if (Input.GetButtonDown ("Fire4")) {
      if(player3IsIn){
			Player4.SetActive (true);
      if (!player4IsIn) {
        supervisor.number += 1;
        player4IsIn = true;
      }
    }
      else {
        anim.SetTrigger("TryToJoin");

          textCantJoin.text = "le troisieme joueur doit etre connecte pour que le quatrieme rejoigne la partie !";
      }
        }
    }

  }
