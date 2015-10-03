using UnityEngine;
using System.Collections;

public class BonusPointsController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		BallScript ballScript = other.GetComponent<BallScript> ();
		GameObject lastPlayer = ballScript.getLastPlayer ();
		if (lastPlayer != null) {
			if (lastPlayer.CompareTag ("paddle1")) {
				ballScript.incrementPlayerOneScore (10);
			} else if (lastPlayer.CompareTag ("paddle2")) {
				ballScript.incrementPlayerTwoScore (10);
			}
		}
	}
}
