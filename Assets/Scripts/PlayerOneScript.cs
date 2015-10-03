using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float yMin, yMax;
}

public class PlayerOneScript : MonoBehaviour
{
	public float speed;
	public int score = 0;
	private Rigidbody2D rb;
	public Boundary boundary;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	public void incrementScore (int amount)
	{
		Debug.Log ("increment");
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
		if (Input.GetKey (KeyCode.W)) {
			move (1);
		} else if (Input.GetKey (KeyCode.S)) {
			move (-1);
		}
	}
}