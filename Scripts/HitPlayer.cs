using UnityEngine;
using System.Collections;

public class HitPlayer : MonoBehaviour {

	// The game manager
	private GameManager gameManager;
	
	void Start()
	{
		GameObject gameManagerObject = GameObject.FindWithTag ("GameManager");
		if (gameManagerObject != null) {
			gameManager = gameManagerObject.GetComponent<GameManager>();
		} else {
			Debug.Log ("Cannot find 'GameManager' script");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			gameManager.GameOver ();
		}
	}
}
