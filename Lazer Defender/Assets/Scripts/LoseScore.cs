using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text scoreText = GetComponent<Text>();
		scoreText.text = "Your Score :" + ScoreKeeper.score.ToString();
	}

}
