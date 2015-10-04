using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	public AudioClip paddleHit;
	public AudioClip dead;
	public AudioClip winSound;

	public AudioSource source;

	public Text p1t;
	public Text p2t;
	public Text winT;

	private int countDownTime = 3;

	private PlayerTwoScript p2s;
	private PlayerOneScript p1s;

	public GameObject countDown;

	public int trasitionToMenuTime = 10;

	private Rigidbody2D rb;
	public int nextPiece;
	private GameObject nextPieceObj;
	public GameObject[] piecesOne;
	public GameObject[] piecesTwo;
	public GameObject[] pieces;

	private GameObject lastPlayer;

	public GameObject getLastPlayer () {
		return lastPlayer;
	}

	public void incrementPlayerOneScore (int amount){
		p1s.score = p1s.score + amount;
		p1t.text = "" + p1s.score;
	}

	public void incrementPlayerTwoScore (int amount){
		p2s.score = p2s.score + amount;
		p2t.text = "" + p2s.score;
	}

//	public void setCountDownText (){
//		countDownText.text = "" + countDownTime;
//		countDownTime -= 1;
//	}
	
	void Start () {
		countDownTime = 3;
		lastPlayer = null;
		
		p2s = player2.GetComponent<PlayerTwoScript> ();
		p1s = player1.GetComponent<PlayerOneScript> ();

		countDown.BroadcastMessage ("SetBall", gameObject);
		countDown.BroadcastMessage ("StartCountDown");
	}

	void PushBall (){
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);
		shufflePiece ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle2")) {
			lastPlayer = collision.gameObject;
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			incrementPlayerTwoScore  (1);
			source.PlayOneShot(paddleHit, 1);
		} else if (collision.gameObject.CompareTag ("paddle1")) {
			lastPlayer = collision.gameObject;
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			incrementPlayerOneScore  (1);
			source.PlayOneShot(paddleHit, 1);
		} else if (collision.gameObject.CompareTag ("tetrisTriggerTwo")) {
			source.PlayOneShot(dead, 1);
			p2s.score = p2s.score - 2;
			p1s.score = p1s.score + 3;
			p2t.text =  p2s.score.ToString();
			p1t.text = p1s.score.ToString();
			FindObjectOfType<SpawnerTwo>().spawnNext(collision.contacts[0].point, piecesTwo[nextPiece]);
			if (GameObject.FindGameObjectsWithTag("ball").Length < 2) {
				Instantiate(gameObject, new Vector3(0, 0, 0), transform.rotation);
			}
			Destroy(gameObject);
			shufflePiece();
		} else if (collision.gameObject.CompareTag ("tetrisTriggerOne")) {
			source.PlayOneShot(dead, 1);
			p1s.score = p1s.score - 2;
			p2s.score = p2s.score + 3;
			p2t.text = p2s.score.ToString();
			p1t.text = p1s.score.ToString();
			FindObjectOfType<SpawnerOne>().spawnNext(collision.contacts[0].point, piecesOne[nextPiece]);
			if (GameObject.FindGameObjectsWithTag("ball").Length < 2) {
				Instantiate(gameObject, new Vector3(0, 0, 0), transform.rotation);
			}
			Destroy(gameObject);
			shufflePiece();
		}
	}

	void shufflePiece() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("nextPiece");
		foreach (GameObject obj in objs) {
			Destroy(obj);
		}
		nextPiece = Random.Range (0, pieces.GetLength (0));
		nextPieceObj = Instantiate (pieces[nextPiece], new Vector3 (0, 75, 0), Quaternion.identity) as GameObject;
	}

	public void PlayerWin(int p) {
		source.PlayOneShot(winSound);
		if (p == 2) {
			winT.text = "Player Right Wins";
		} else {
			winT.text = "Player Left Wins";
		}
		returnToMenu ();
	}

	IEnumerator returnToMenu () {
		yield return new WaitForSeconds (trasitionToMenuTime);
		Application.LoadLevel (1);
	} 
}
