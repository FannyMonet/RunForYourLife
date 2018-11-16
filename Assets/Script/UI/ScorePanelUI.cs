using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUI : MonoBehaviour {


    public Text textJ1;
	public Text textJ2;
	public Text textJ3;
	public Text textJ4;

	public GameObject bar1;
	public GameObject bar2;
	public GameObject bar3;
	public GameObject bar4;

	public Image J1;
	public Image J2;
	public Image J3;
	public Image J4;




	public Supervisor supervisor;

	private int[] counter;
	// Use this for initialization
	void Start ()
	{
		textJ1 = GameObject.Find ("scoreJ1").GetComponent<Text> ();
		textJ2 = GameObject.Find ("scoreJ2").GetComponent<Text> ();
		textJ3 = GameObject.Find ("scoreJ3").GetComponent<Text> ();
		textJ4 = GameObject.Find ("scoreJ4").GetComponent<Text> ();

		bar1 = GameObject.Find ("barJ1");
		bar2 = GameObject.Find ("barJ2");
		bar3 = GameObject.Find ("barJ3");
		bar4 = GameObject.Find ("barJ4");

		supervisor = GameObject.Find ("Supervisor").GetComponent<Supervisor> ();
		counter = new int[supervisor.playerNbr];

		J1 = GameObject.Find ("ImageJ1").GetComponent<Image> ();
		J2 = GameObject.Find ("ImageJ2").GetComponent<Image> ();
		J3 = GameObject.Find ("ImageJ3").GetComponent<Image> ();
		J4 = GameObject.Find ("ImageJ4").GetComponent<Image> ();

		J1.sprite = supervisor.listOfAvatar [0].GetComponent<SpriteRenderer> ().sprite;
		J2.sprite = supervisor.listOfAvatar [1].GetComponent<SpriteRenderer> ().sprite;
		if (supervisor.playerNbr >= 3) {
			J3.sprite = supervisor.listOfAvatar [2].GetComponent<SpriteRenderer> ().sprite;
		} else {
			J3.gameObject.SetActive (false);
		}
		if (supervisor.playerNbr == 4) {
			J4.sprite = supervisor.listOfAvatar [3].GetComponent<SpriteRenderer> ().sprite;
		} else {
			J4.gameObject.SetActive(false);
		} 


	}
	
	// Update is called once per frame
	void Update ()
	{

		textJ1.text = supervisor.scores [0].ToString ();
		if (counter[0] != 75 * supervisor.scores [0] && supervisor.BoardIsDown) {
			//
			bar1.GetComponent<RectTransform> ().sizeDelta = new Vector2 (counter[0]++, 100);
		} else if (!supervisor.BoardIsDown) {
			bar1.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( 75 * supervisor.scores [0], 100);
		}
			bar1.GetComponent<RectTransform> ().localPosition = new Vector2 (120, 0);
		

		textJ2.text = supervisor.scores [1].ToString ();
		if (counter[1] != 75 * supervisor.scores [1] && supervisor.BoardIsDown) {
			//
			bar2.GetComponent<RectTransform> ().sizeDelta = new Vector2 (counter[1]++, 100);
		} else if (!supervisor.BoardIsDown) {
			bar2.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( 75 * supervisor.scores [1], 100);
		}
			bar2.GetComponent<RectTransform> ().localPosition = new Vector2 (120, 0);


		if (supervisor.playerNbr >= 3) {
			textJ3.text = supervisor.scores [2].ToString ();
			if (counter[2] != 75 * supervisor.scores [2] && supervisor.BoardIsDown) {
			//
			bar3.GetComponent<RectTransform> ().sizeDelta = new Vector2 (counter[2]++, 100);
		} else if (!supervisor.BoardIsDown) {
			bar3.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( 75 * supervisor.scores [2], 100);
		}
			bar3.GetComponent<RectTransform> ().localPosition = new Vector2 (120, 0);
		}
		else {
			bar3.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			textJ3.text = "";
		}
		if (supervisor.playerNbr >= 4) {
			textJ4.text = supervisor.scores [3].ToString ();
			if (counter[3] != 75 * supervisor.scores [3] && supervisor.BoardIsDown) {
			//
			bar4.GetComponent<RectTransform> ().sizeDelta = new Vector2 (counter[3]++, 100);
		} else if (!supervisor.BoardIsDown) {
			bar4.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( 75 * supervisor.scores [3], 100);
		}
			bar4.GetComponent<RectTransform> ().localPosition = new Vector2 (120, 0);
		}
		else {
			bar4.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			textJ4.text = "";
		}


	}
}
