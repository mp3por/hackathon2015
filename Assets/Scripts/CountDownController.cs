using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{

	public Text countDownText;
	public GameObject ball;

	public int privateCountDownTime = 4;

	private int resetTime;

	public void SetBall (GameObject ball){
		this.ball = ball;
		resetTime = privateCountDownTime;
	}

	public void StartCountDown (){
		StartCoroutine (SpawnBall ());
	}

	IEnumerator SpawnBall ()
	{
		do {
			countDownText.text = "" + resetTime;
			resetTime -= 1;
			yield return new WaitForSeconds (1);
		} while (resetTime > 0);

		countDownText.text = "";
		ball.BroadcastMessage ("PushBall");
	}
}
