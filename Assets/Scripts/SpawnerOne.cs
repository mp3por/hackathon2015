using UnityEngine;
using System.Collections;

public class SpawnerOne : MonoBehaviour {

	public GameObject[] pieces;

	public void spawnNext(Vector3 position, int piecePosition) {
		position.y = (int)(position.y / 5) * 5;
		if (position.y < -40) {
			position.y = -40;
		}
		if (position.y > 40) {
			position.y = 40;
		}
		position.x = -80;

		GameObject go = Instantiate (pieces [piecePosition], position, Quaternion.identity) as GameObject;
		go.AddComponent<GroupOne> ();
	}
}