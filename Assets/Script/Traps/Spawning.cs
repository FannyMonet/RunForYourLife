using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject prefab;                // The prefab to be spawned.
    public float spawnTime;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		//prefab.name = GetComponentInParent<GameObject>().name;
		foreach (Transform t in spawnPoints) {
		    t.name = this.name;
		}
    }


    void Spawn ()
	{

		// Find a random index between zero and one less than the number of spawn points.
		for (int i = 0; i < spawnPoints.Length; i++) {
		    prefab.name = spawnPoints[i].name;
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (prefab, spawnPoints [i].position, spawnPoints [i].rotation);
		}
    }
}
