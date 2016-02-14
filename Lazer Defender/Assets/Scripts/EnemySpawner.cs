using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10.0f;
	public float hight = 5.0f;
	public float speed = 5.0f;
	public float respawnDelay = 0.5f;

	private float xMin;
	private float xMax;
	private bool movingRight;
	private float padding;

	// Use this for initialization
	void Start () {
		SpawnUntilFull() ;
		padding = width * 0.5f;
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MoveFormation(movingRight);

		if (AllMembersDead()) {
			Debug.Log("Empty formation.");
			SpawnUntilFull();
		}
	}

	void MoveFormation(bool direction) {
		if (!direction) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (direction) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		float posX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(posX, transform.position.y, transform.position.z);

		if (posX >= xMax || posX <= xMin) {
			movingRight = !movingRight;
		}
	}

	bool AllMembersDead() {
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	Transform NextFreePosition() {
		foreach (Transform child in transform) {
			if (child.childCount <= 0) {
				return child;
			}
		}
		return null;
	}

	void RespawnEnemies() {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition();
		if (freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition()) {
			Invoke("SpawnUntilFull", respawnDelay);
		}

	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, hight));
	}
}
