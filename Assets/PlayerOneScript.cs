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

		//Bound element on y
		var viewpointCoord = Camera.main.WorldToViewportPoint(transform.position);
		if (viewpointCoord.y < 0.0f) {
			Debug.Log("Bottom edge of view");
			viewpointCoord.y = 0.0f;
			transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
		}
		else if (viewpointCoord.y > 1.0f) {
			Debug.Log("Top edge of view");
			viewpointCoord.y = 1.0f;
			transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
		}
	}
}
