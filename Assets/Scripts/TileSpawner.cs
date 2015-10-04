using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour {

	public GameObject[] groups;

	public void SpawnNext (Vector2 position)
	{
		Debug.Log ("SpawnNext:" + groups.Length );
		Vector2 spawnPosition = new Vector2 (position.y, position.x);
		int i = Random.Range(0, groups.Length);

		Instantiate (Resources.Load("GroupI V"), transform.position, Quaternion.identity);
	}
}
