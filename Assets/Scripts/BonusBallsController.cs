using UnityEngine;
using System.Collections;

public class BonusBallsController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject ball = Instantiate(collider, transform.position, transform.rotation) as GameObject;
		ball.BroadcastMessage ("PushBall");
	}
}
