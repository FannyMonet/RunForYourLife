using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This script is here to help Test Mode.
//It allows developper to implement quickly traps and restart the scene
public class RestartScene : MonoBehaviour {

    public Animator transitionAnim;
	public string SceneName;

	public GameObject traps;

	// Use this for initialization
	public void restartScene ()
	{
       StartCoroutine(LoadSceneTransition());
	}
	public void activateTrap ()
	{
	traps.SetActive(true);
	}
	public void desactivateTrap ()
	{
	traps.SetActive(false);
	}

	IEnumerator LoadSceneTransition ()
	{
	transitionAnim.SetTrigger("end");
	yield return new WaitForSeconds(0.1f);
	SceneManager.LoadScene(SceneName);
	}
}
