using UnityEngine;
using System.Collections;

public class PlayerTwoScript : MonoBehaviour {
	public float speed;
	
	void Start () {
		
	}
	
	void Update () {
		Vector3 new_speed = new Vector3 (0, 0, 0);
		if (Input.GetKey (KeyCode.UpArrow)) {
			new_speed.y += speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			new_speed.y -= speed * Time.deltaTime;
		}
		transform.Translate (new_speed);
	}
}
