using UnityEngine;
using System.Collections;

public class DeleteByContact : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D (Collider2D other) {
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
