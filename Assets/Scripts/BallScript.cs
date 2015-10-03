using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);
	}

	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle")) {
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
		} else if (collision.gameObject.CompareTag ("tetrisTrigger")) {
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<Spawner>().spawnNext(collision.contacts[0].point);
			Start ();
		}
	}
}
