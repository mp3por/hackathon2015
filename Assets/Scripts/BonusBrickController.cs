using UnityEngine;
using System.Collections;

public class BonusBrickController : MonoBehaviour {
	public GameObject bonusBrick;
	
	void OnTriggerEnter2D (Collider2D collider) {
		bonusBrick = Instantiate(bonusBrick,new Vector3(0,0,0), transform.rotation) as GameObject;
		GameObject bs = GameObject.FindGameObjectWithTag ("ball") as GameObject;

		GameObject player = bs.GetComponent<BallScript>().getLastPlayer ();
		if (player.CompareTag ("paddle1")) {
			bonusBrick.GetComponent<BonusBrick> ().PlayerOne ();
		} else {
			bonusBrick.GetComponent<BonusBrick> ().PlayerOne ();
		}
	}
}
