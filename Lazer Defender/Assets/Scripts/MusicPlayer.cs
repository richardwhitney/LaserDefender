using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake() {
		if (instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else {
			Destroy(gameObject);
			print("Duplicate Music player, self-destructing!");
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
