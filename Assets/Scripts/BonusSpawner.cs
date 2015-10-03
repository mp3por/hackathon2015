using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject bonusPoints;
	public GameObject bonusBalls;
//	public GameObject bonusBrick;
	public GameObject bonusBomb;
	public GameObject bonusMushroom;
	public GameObject ball;

	public float bonusSpawnStartTime;
	public float bonusSpawnWaitTime;
	public Vector2 spawnValues;
	

	GameObject[] objects;
	
	void Start ()
	{
		objects = new GameObject[]{bonusPoints,bonusBalls,bonusBomb,bonusMushroom};
		StartCoroutine (SpawnBonuses ());
	}

	private int getRandomIndex (int min, int max){
		return Mathf.RoundToInt(Random.Range (min, max));
	}
	
	IEnumerator SpawnBonuses ()
	{
		yield return new WaitForSeconds (bonusSpawnStartTime);
		while (true) {
			Vector3 spawnPosition = new Vector2 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y));
			Quaternion spawnRotation = Quaternion.identity;
			GameObject bonus = Instantiate (objects[getRandomIndex(0,objects.Length)], spawnPosition, spawnRotation) as GameObject;
			bonus.SendMessage("SetBall", ball);
			yield return new WaitForSeconds (bonusSpawnWaitTime);
		}
	}
}
