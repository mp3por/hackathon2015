﻿using UnityEngine;
using System.Collections;

public class PlayerTwoScript : MonoBehaviour {
	public float speed;
	public int score = 0;

	public Boundary boundary;

	public void incrementScore (int amount) {
		score += amount;
	}
	
	private void move (float amount)
	{
		Vector2 movement = new Vector2 (0.0f, amount);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;
		
		GetComponent<Rigidbody2D> ().position = new Vector2 (
			transform.position.x,
			Mathf.Clamp (GetComponent<Rigidbody2D> ().position.y, boundary.yMin, boundary.yMax) 
			);
	}
	
	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			move (1);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			move (-1);
		}
	}


}
