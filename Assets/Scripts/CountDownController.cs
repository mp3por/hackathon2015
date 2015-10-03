using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
	public Text countDownText;
	public GameObject ball;

	private int privateCountDownTime = 4;
	
	void Start ()
	{
		startCountDown ();
	}

	public void startCountDown (){
		privateCountDownTime = 4;
		StartCoroutine (SpawnBall ());
	}

	IEnumerator SpawnBall ()
	{
		do {
			countDownText.text = "" + privateCountDownTime;
			privateCountDownTime -= 1;
			yield return new WaitForSeconds (1);
		} while (privateCountDownTime > 0);

		Vector3 spawnPosition = new Vector2 (0, 0);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (ball, spawnPosition, spawnRotation);

		countDownText.text = "";
	}
}
