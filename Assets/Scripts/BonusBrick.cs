﻿using UnityEngine;
using System.Collections;

public class BonusBrick : MonoBehaviour {
	private Rigidbody2D rb;

	void Start () {
		transform.position = new Vector3 (-100, 0, 0);
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
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
