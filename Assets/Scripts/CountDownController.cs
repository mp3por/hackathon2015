using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{

	public Text countDownText;
	public GameObject ball;

	private int privateCountDownTime = 4;
	
//	void Start ()
//	{
//		StartCountDown ();
//	}

	public void SetBall (GameObject ball){
		this.ball = ball;
	}

	public void StartCountDown (){
		Debug.Log ("Start Count Down");
		this.privateCountDownTime = 4;
		StartCoroutine (SpawnBall ());
	}

	IEnumerator SpawnBall ()
	{
		do {
			countDownText.text = "" + privateCountDownTime;
			privateCountDownTime -= 1;
			yield return new WaitForSeconds (1);
		} while (privateCountDownTime > 0);

		countDownText.text = "";
		ball.BroadcastMessage ("PushBall");
		Debug.Log ("countdown end");
	}
}
