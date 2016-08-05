using UnityEngine;
using System.Collections;

public class SpawnCloud : MonoBehaviour {

	private float timeToSpawn = 0;

	
	public GameObject item;
	private float spawnRate;
	
	void Update () {
		spawnRate = Random.Range (0.3f, 0.6f);
		if ( Time.time > timeToSpawn) {
			timeToSpawn = Time.time + 10/spawnRate;	
			SpawnItem();
		}
	}
	
	
	void SpawnItem () {
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (item, transform.position, spawnRotation);
	}
}
