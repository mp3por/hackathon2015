using UnityEngine;
using System.Collections;

public class BonusBrick : MonoBehaviour {
	private Rigidbody2D rb;

	void Start () {
	}

	public void PlayerTwo() {
		transform.position = new Vector3 (80, 0, 0);
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (-.05f, .05f));
		rb.AddForce(initialForce);
	}

	public void PlayerOne() {
		transform.position = new Vector3 (-80, 0, 0);
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (-.3f, -.4f), Random.Range (-.05f, .05f));
		rb.AddForce(initialForce);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.name == "TetrisTile") {
			Destroy (collision.collider.gameObject);
		} 
		else if (collision.collider.CompareTag ("tetrisTriggerOne") || collision.collider.CompareTag ("tetrisTriggerTwo")) {
			Destroy (gameObject);
		}
	}
}
