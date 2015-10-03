using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce(new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f)));
	}

	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle")) {
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
		} else if (collision.gameObject.CompareTag ("tetrisTrigger")) {
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			Start();
		}
	}
}
