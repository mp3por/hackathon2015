using UnityEngine;
using System.Collections;

public class DeleteByContact : MonoBehaviour {

	public GameObject explosion;
	
	public AudioClip pickupSound;

	private AudioSource source;

	void Start () {
		source = GameObject.FindObjectOfType<AudioSource> ();
		source = GameObject.FindGameObjectWithTag ("audio").GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		source.PlayOneShot (pickupSound);
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
