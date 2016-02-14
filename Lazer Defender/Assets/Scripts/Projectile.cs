using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hit() {
		Destroy(gameObject);
	}

	public int GetDamage() {
		return damage;
	}
}
