using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int score;
	private SpawnTree treeSpawner;
	private bool gameOver = false;
	public GUIText endText;
	private string scoreText;
	private GameObject[] treeSpawnerObjects;

	// Use this for initialization
	void Start () {
		score = 0;
		treeSpawnerObjects = GameObject.FindGameObjectsWithTag ("TreeSpawner");
		scoreText = "";
	}
	
	// Update is called once per frame
	void Update () {
		endText.text = scoreText;

		if (gameOver) {
			treeSpawner.isSpawning = false;
			if (Input.GetKeyDown ("space")) {
				Application.LoadLevel ("GameScene");
			}
		}
	}

	public void GameOver () {
		for (int i = 0; i < treeSpawnerObjects.Length; i++) {
			if (treeSpawnerObjects[i] != null) {
				treeSpawner = treeSpawnerObjects[i].GetComponent<SpawnTree> ();
				treeSpawner.isSpawning = false;
			} else {
				Debug.Log ("Cannot find tree spawner");
			}
		}
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
		for (int i = 0; i < obstacles.Length; i++) {
			GameObject.Destroy (obstacles [i].gameObject);
		}
		GameObject player = GameObject.FindWithTag ("Player");
		GameObject.Destroy (player.gameObject);
		scoreText = "GAME OVER! SCORE: " + score + "\nPRESS SPACE TO PLAY AGAIN!";
		gameOver = true;
	}

	public void addScore () {
		score++;
	}
}
