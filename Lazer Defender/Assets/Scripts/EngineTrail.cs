using UnityEngine;
using System.Collections;

public class EngineTrail : MonoBehaviour {

	public TrailRenderer engineTrail;

	// Use this for initialization
	void Start () {
		engineTrail = gameObject.GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StopTrail() {
		engineTrail.gameObject.transform.parent = null;
	}
}
