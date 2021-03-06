﻿using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {

	// sound to play when collected
	public AudioClip sound;
	// the speed at whic the object moves
	public float speed;
	// the current transform of the object
	private Transform currPos;
	// an instance of the game manager
	GameManager GM;
	
	void Start () {
		GameObject gameManagerObject = GameObject.FindGameObjectWithTag ("GameManager");
		if (gameManagerObject != null) {
			GM = gameManagerObject.GetComponent<GameManager> ();
		} else {
			Debug.Log ("Cannot find GameManager");
		}
	}
	
	void Update () {
		transform.position = new Vector3 (transform.position.x - (speed / 3), transform.position.y - (speed / 5.5f), transform.position.z);
		CheckOutOfBounds ();
	}
	
	void CheckOutOfBounds () {
		if (transform.position.x < -11.0f) {
			GameObject.Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")) {
			GM.addScore();
			AudioSource.PlayClipAtPoint(sound, transform.position);
			GameObject.Destroy(this.gameObject);
		}
	}
}
