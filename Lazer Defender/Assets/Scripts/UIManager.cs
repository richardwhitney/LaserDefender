using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text healthText;

	// Use this for initialization
	void Start () {
		healthText.text = "100";
	}
	
	public void SetHealthText(int health) {
		healthText.text = health.ToString();
	}
}
