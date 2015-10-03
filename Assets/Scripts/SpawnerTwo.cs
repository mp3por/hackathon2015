using UnityEngine;
using System.Collections;

public class SpawnerTwo : MonoBehaviour {

	public void spawnNext(Vector3 position, GameObject piece) {
		position.y = (int)(position.y / 5) * 5;
		position.x = 75;

		piece.AddComponent<GroupTwo>();
		
		Instantiate(piece,
		            position,
		            Quaternion.identity);
	}

	void Start(){
//		spawnNext ();
	}

	void Update() {

	}
}