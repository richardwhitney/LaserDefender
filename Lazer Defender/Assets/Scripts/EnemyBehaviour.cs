using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 100.0f;
	public GameObject lazerPrefab;
	public float lazerSpeed = 15.0f;
	public float fireRate = 0.5f;
	public GameObject deathParticle;
	public GameObject hitParticle;
	public int scoreValue = 150;
	public AudioClip lazerSound;
	public AudioClip deathSound;

	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * fireRate;
		if (Random.value < probability) {
			Shoot();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player Lazer") {
			Projectile playerLazer = other.gameObject.GetComponent<Projectile>();
			health -= playerLazer.GetDamage();
			Instantiate(hitParticle, other.gameObject.transform.position, Quaternion.identity);
			playerLazer.Hit();
			if (health <= 0) {
				Instantiate(deathParticle, transform.position, Quaternion.identity);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				scoreKeeper.Score(scoreValue);
				Destroy(gameObject);
			}
		}
	}

	void Shoot() {
		GameObject projectile = Instantiate(lazerPrefab, transform.position, lazerPrefab.transform.rotation) as GameObject;
		projectile.GetComponent<Rigidbody2D>().velocity = Vector3.down * lazerSpeed;
		AudioSource.PlayClipAtPoint(lazerSound, transform.position);
	}

	void StopEngineEffect() {
		EngineTrail engineEffect = GetComponentInChildren<EngineTrail>();
		engineEffect.StopTrail();
	}
}
