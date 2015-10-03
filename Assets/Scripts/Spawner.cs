using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	// Groups
	public GameObject[] groups;

	public void spawnNext(Vector3 position) {
		// Random Index
		int i = Random.Range(0, groups.Length);
		position.y = (int)(position.y / 5) * 5;
		position.x = -65;
		
		// Spawn Group at current Position
		GameObject go = (GameObject)Instantiate(groups[i],
		            position,
		            Quaternion.identity);
	}

	void Start(){
//		spawnNext ();
	}

	void Update() {

	}
}