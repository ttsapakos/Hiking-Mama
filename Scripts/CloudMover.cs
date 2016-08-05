using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

	public float speed;
	private float currentPosition;
	
	
	void Start ()
	{
		currentPosition = transform.position.x;
	}
	
	void Update () {
		currentPosition -= speed;
		transform.position = new Vector3 (currentPosition, transform.position.y, transform.position.z);

		CheckOutOfBounds ();
	}
	
	void CheckOutOfBounds () {
		if (transform.position.x < -11.0f) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
