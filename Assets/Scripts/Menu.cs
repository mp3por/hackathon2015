using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	private int choice = 0;
	public Text play;
	public Text exit;

	private AudioSource audio;

	public AudioClip menuChange;
	
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.Play();
		audio.Play(44100);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			play.text = "LOCAL MULTIPLAYER";
			exit.text = "- EXIT";
			audio.PlayOneShot(menuChange);
			choice = 1;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			play.text = "- LOCAL MULTIPLAYER";
			exit.text = "EXIT";
			audio.PlayOneShot(menuChange);
			choice = 0;
		} else if(Input.GetKey(KeyCode.Return)) {
			switch (choice) {
			case 0:
				Application.LoadLevel("Game");
				break;
			case 1:
				Application.Quit();
				break;
			}
		}
	}

	public void Exit() {
		Application.Quit();
	}

	public void Play() {
		Application.LoadLevel("Game");
	}
}
