using UnityEngine;
using System.Collections;

public class SpawnerOne : MonoBehaviour {

	public void spawnNext(Vector3 position, GameObject piece) {
		position.y = (int)(position.y / 5) * 5;
		position.x = -65;
		
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