using UnityEngine;
using System.Collections;

public class PlayerOneScript : MonoBehaviour {
	public float speed;

	void Start () {
	
	}
	
	void Update () {
		Vector3 new_speed = new Vector3 (0, 0, 0);
		if (Input.GetKey ("w")) {
			new_speed.y += speed * Time.deltaTime;
		}
		if (Input.GetKey ("s")) {
			new_speed.y -= speed * Time.deltaTime;
		}
		transform.Translate (new_speed);
	}
}
