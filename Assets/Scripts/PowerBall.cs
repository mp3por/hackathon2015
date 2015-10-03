using UnityEngine;
using System.Collections;

public class PowerBall : MonoBehaviour {
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (-100, 0, 0);
		rb = GetComponent<Rigidbody2D> ();
		Vector2 initialForce = new Vector2 (Random.Range (.3f, .4f), Random.Range (.01f, .05f));
		if (Random.Range (0, 100) < 50) {
			initialForce.x *= -1;
		}
		rb.AddForce(initialForce);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "tetrisTile")
		{
			Debug.Log ("HASDHAUISBFASJNCLFMA> <DCS?");		
		}
	}
}
