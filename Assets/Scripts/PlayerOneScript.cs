﻿using UnityEngine;
using System.Collections;

public class PlayerOneScript : MonoBehaviour {
	public float speed;

	public int score = 0;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void incrementScore (int amount) {
		Debug.Log ("increment");
		score += amount;
	}

	void Update () {
		float direction = 0.0f;
		if (Input.GetKey (KeyCode.W)) {
			direction += 1;
		}
		if (Input.GetKey (KeyCode.S)) {
			direction -= 1;
		}
		if (direction != 0) {
			rb.position += new Vector2 (0.0f, speed * direction * Time.deltaTime);
		} else {
			rb.velocity = new Vector2(0f,0f);
		}
		rb.rotation = 0f;
	}
}