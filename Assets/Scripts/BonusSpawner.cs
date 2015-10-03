using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject bonusPoints;
//	public GameObject bonusSplit;
//	public GameObject bonusBrick;
//	public GameObject bonusBomb;
//	public GameObject bonusViagra;
	public GameObject ball;

	public float bonusSpawnStartTime;
	public float bonusSpawnWaitTime;
	public Vector3 spawnValues;
	
	void Start ()
	{
		StartCoroutine (SpawnBonuses ());
	}
	
	IEnumerator SpawnBonuses ()
	{
		yield return new WaitForSeconds (bonusSpawnStartTime);
		while (true) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			GameObject bonus = Instantiate (bonusPoints, spawnPosition, spawnRotation) as GameObject;
			bonus.SendMessage("SetBall", ball);
			yield return new WaitForSeconds (bonusSpawnWaitTime);
		}
	}
}
