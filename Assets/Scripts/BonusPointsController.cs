using UnityEngine;
using System.Collections;

public class BonusPointsController : MonoBehaviour {
	private GameObject ball;

	void SetBall (GameObject ball){
		this.ball = ball;
	}

	void OnTriggerEnter2D (Collider2D other) {
		BallScript ballScript = other.GetComponent<BallScript> ();
		GameObject lastPlayer = ballScript.getLastPlayer ();
		if (lastPlayer.CompareTag("paddle1")) {
			ballScript.incrementPlayerOneScore(10);
		} else if (lastPlayer.CompareTag("paddle2")) {
			ballScript.incrementPlayerTwoScore(10);
		}
	}
}
