using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float padding = 1.0f;
	public GameObject lazerPrefab;
	public float lazerSpeed = 15.0f;
	public float shootingRate = 0.2f;
	public GameObject hitParticle;
	public GameObject deathParticle;
	public int health = 100;
	public AudioClip lazerAudio;

	private float xMin;
	private float xMax;
	private UIManager uiManager;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;

		uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			MoveShip(-1);
		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			MoveShip(1);
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Shoot", 0.00001f, shootingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Shoot");
		}

	}

	void MoveShip(int direction) {
		if (direction < 0 ) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (direction > 0) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		float posX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
	}

	void Shoot() {
		GameObject projectile = Instantiate(lazerPrefab, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D>().velocity = Vector3.up * lazerSpeed;
		AudioSource.PlayClipAtPoint(lazerAudio, transform.position);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy Lazer") {
			Debug.Log("Player hit.");
			Projectile enemyLazer = other.gameObject.GetComponent<Projectile>();
			Instantiate(hitParticle, other.gameObject.transform.position, Quaternion.identity);
			enemyLazer.Hit();
			health -= enemyLazer.GetDamage();
			uiManager.SetHealthText(health);
			if (health <= 0) {
				Death();
			}
		}
	}

	void Death() {
		Instantiate(deathParticle, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Debug.Log("Player Dead");
		Debug.Log("Load Lose scene");
		LevelManager levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
		levelManager.LostLevel();
	}

}
