using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();
		scoreText.text = "Score: " + score.ToString();
	}

	public void Score(int points) {
		score += points;
		scoreText.text = "Score: " + score.ToString();
	}

	public static void Reset() {
		score = 0;
		//scoreText.text = "Score: " + score.ToString();
	}
}
