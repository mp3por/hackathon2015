using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Rigidbody2D rb;
	public int nextPiece;
	private GameObject nextPieceObj;
	public GameObject[] piecesOne;
	public GameObject[] piecesTwo;
	public GameObject[] pieces;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);
		shufflePiece ();
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("paddle")) {
			rb.AddForce (new Vector2 (.0f, Random.Range (-.1f, .1f)));
		} else if (collision.gameObject.CompareTag ("tetrisTriggerOne")) {
			rb.velocity = new Vector2(0f,0f);
			transform.position = new Vector2(0f,0f);
			FindObjectOfType<SpawnerOne>().spawnNext(collision.contacts[0].point, piecesOne[nextPiece]);
			shufflePiece();
			Start ();
		} else if (collision.gameObject.CompareTag ("tetrisTriggerTwo")) {
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
}
