using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	public Text p1t;
	public Text p2t;
	public Text winT;

	private PlayerTwoScript p1s;
	private PlayerOneScript p2s;

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
		p2t.text = "Score: " + p1s.score;
	}

	public void incrementPlayerTwoScore (int amount){
		p2s.score = p2s.score + amount;
		p1t.text = "Score: " + p2s.score;
	}



	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);

		shufflePiece ();

		p1s = player1.GetComponent<PlayerTwoScript> ();
		p2s = player2.GetComponent<PlayerOneScript> ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle1")) {
			lastPlayer = collision.gameObject;
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			incrementPlayerOneScore  (1);
		} else if (collision.gameObject.CompareTag ("paddle2")) {
			lastPlayer = collision.gameObject;
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
			incrementPlayerTwoScore  (1);
		} else if (collision.gameObject.CompareTag ("tetrisTriggerOne")) {
			p2s.score = p2s.score - 2;
			p1s.score = p1s.score + 3;
			p1t.text =  p2s.score.ToString();
			p2t.text = p1s.score.ToString();
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<SpawnerOne>().spawnNext(collision.contacts[0].point, piecesOne[nextPiece]);
			shufflePiece();
			Start ();
		} else if (collision.gameObject.CompareTag ("tetrisTriggerTwo")) {
			p1s.score = p1s.score - 2;
			p2s.score = p2s.score + 3;
			p1t.text = p2s.score.ToString();
			p2t.text = p1s.score.ToString();
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<SpawnerTwo>().spawnNext(collision.contacts[0].point, piecesTwo[nextPiece]);
			shufflePiece();
			Start ();
		}
	}

	void shufflePiece() {
		nextPiece = Random.Range (0, pieces.GetLength (0));
		Destroy (nextPieceObj);
		nextPieceObj = Instantiate (pieces[nextPiece], new Vector3 (0, 75, 0), Quaternion.identity) as GameObject;
	}

	public void PlayerWin(int p) {
		if (p == 1) {
			winT.text = "Player Right Wins";
		} else {
			winT.text = "Player Left Wins";
		}
	}
}
