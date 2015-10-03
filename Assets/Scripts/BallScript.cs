﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	public Text p1t;
	public Text p2t;

	private PlayerTwoScript p1s;
	private PlayerOneScript p2s;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);

		p1s = player1.GetComponent<PlayerTwoScript> ();
		p2s = player2.GetComponent<PlayerOneScript> ();
	}

	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle1")) {
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			p1s.score = p1s.score + 1;
			p1t.text = "Score: " + p1s.score;
		} else if (collision.gameObject.CompareTag ("paddle2")) {
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			p2s.score = p2s.score + 1;
			p2t.text = "Score: " + p2s.score;
		} else if (collision.gameObject.CompareTag ("tetrisTriggerOne")) {
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<SpawnerOne>().spawnNext(collision.contacts[0].point);
			Start ();
		} else if (collision.gameObject.CompareTag ("tetrisTriggerTwo")) {
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<SpawnerTwo>().spawnNext(collision.contacts[0].point);
			Start ();
		}
	}
}
