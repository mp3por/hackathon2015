using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {
	public Text back;
	private AudioSource audio;
	

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.Play();
		audio.Play(44100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Menu() {
		Application.LoadLevel("Menu");
	}

	public void Play() {
		Application.LoadLevel("Game");
	}



	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.type == EventType.KeyDown) {
			if (e.keyCode == KeyCode.Backspace || e.keyCode == KeyCode.Escape) {
				Menu ();
			} else if (e.keyCode == KeyCode.Return) {
				Play ();
			}
		}
		
	}
}
