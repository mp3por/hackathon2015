using UnityEngine;
using System.Collections;

public class BonusBallsController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		Instantiate(collider, transform.position, transform.rotation);
	}
}
