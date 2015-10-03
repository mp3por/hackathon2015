using UnityEngine;
using System.Collections;

public class BonusMushroomController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		BallScript bs = collider.GetComponent<BallScript> ();

		GameObject player = bs.getLastPlayer ();

		PlayerOneScript p1s = player.GetComponent<PlayerOneScript> ();
		PlayerTwoScript p2s = player.GetComponent<PlayerTwoScript> ();

		if (p1s) {
			p1s.increaseSize();
		} else if (p2s) {
			p2s.increaseSize();
		} else {
			Debug.Log("WE ARE DOOMED");
		}
	}
}
