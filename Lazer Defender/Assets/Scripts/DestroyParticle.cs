using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	public float timeToLive = 0.7f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeToLive);
	}

}
