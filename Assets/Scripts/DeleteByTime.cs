using UnityEngine;
using System.Collections;

public class DeleteByTime : MonoBehaviour {
	public float lifetime;
	void Start () {
		Destroy (gameObject, lifetime);
	}
}
