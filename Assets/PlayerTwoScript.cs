using UnityEngine;
using System.Collections;

public class PlayerTwoScript : MonoBehaviour {
	public float speed;
	
	private Rigidbody2D rb;
	
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float direction = 0.0f;
		if (Input.GetKey (KeyCode.UpArrow)) {
			direction += 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			direction -= 1;
		}
		rb.AddForce(new Vector3(0.0f,speed*direction*Time.deltaTime,0.0f));
	}
}
