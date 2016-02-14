using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for " + name);
		if (name == "Start") {
			ScoreKeeper.Reset();
		}
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		int currentLevel = Application.loadedLevel;
		Application.LoadLevel(currentLevel+1);
	}

	public void LostLevel() {
		StartCoroutine(GameOver());
	}

	public void QuitRequest() {
		Debug.Log("Quit Requested");
		Application.Quit();
	}

	IEnumerator GameOver() {
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel("Lose");
	}
		
}
