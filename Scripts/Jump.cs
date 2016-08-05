using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	bool jumping;
	//the starting position of the player
	private float startingYPos;
	// the velocity of the player
	private float velocity;
	// jump sound
	public AudioClip jumpSound;

	// Use this for initialization
	void Start () {
		jumping = false;
		startingYPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < startingYPos) {
			transform.position = new Vector2 (transform.position.x, startingYPos);
		} else if (transform.position.y == startingYPos) {
			jumping = false;
			velocity = 0.3f;
		} else {
			jumping = true;
		}

		if (Input.GetKeyDown("space") && !jumping) {
			jumping = true;
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
		}

		if (jumping) {
			rigidbody2D.position = new Vector2(rigidbody2D.position.x, rigidbody2D.position.y + velocity);
		}

		velocity -= 0.01f;
	}
}
