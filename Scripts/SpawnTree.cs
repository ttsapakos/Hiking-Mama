using UnityEngine;
using System.Collections;

public class SpawnTree : MonoBehaviour {

	// The tree object
	public GameObject tree;
	// the rock object
	public GameObject rock;
	// for use for the random number
	public float spawnRate;
	// For spawner use
	private float timeToSpawn = 0;
	// to determine if the trees are spawning
	public bool isSpawning = true;

	void Update () {
		float spawnRateTemp = Random.Range (spawnRate, spawnRate + 4.0f);
		if (isSpawning) {
			if (Time.time > timeToSpawn) {
				timeToSpawn = Time.time + 10 / spawnRateTemp;	
				SpawnItem ();
			}
		}
	}

	// Spawns the item
	void SpawnItem () {
		Quaternion spawnRotation = Quaternion.identity;
		float rockOrTree = Random.Range (-1, 1);
		if (rockOrTree < 0) {
			Instantiate (tree, transform.position, spawnRotation);
		} else {
			Vector2 rockSpawn = new Vector2 (transform.position.x, transform.position.y - 0.5f);
			Instantiate (rock, rockSpawn, spawnRotation);
		}
	}
}
