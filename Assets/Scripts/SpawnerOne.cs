using UnityEngine;
using System.Collections;
using System;

public class SpawnerOne : MonoBehaviour {

	public GameObject[] pieces;

	public void spawnNext(Vector3 position, int piecePosition) {
		position.y = Mathf.RoundToInt(position.y / 5) * 5;
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