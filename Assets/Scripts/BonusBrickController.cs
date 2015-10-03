using UnityEngine;
using System.Collections;

public class BonusBrickController : MonoBehaviour {
	public GameObject bonusBrick;
	
	void OnTriggerEnter2D (Collider2D collider) {
		Instantiate(bonusBrick,new Vector2(0,0), transform.rotation);
	}
}
