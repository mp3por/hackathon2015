using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public int previous = -1;
	public int choice = 0;
	public Text play;
	public Text exit;
	public Text powerups;
	public Text[] texts;

	private AudioSource audio;

	public AudioClip menuChange;
	
	// Use this for initialization
	void Start () {
		texts = new Text[3]{play, powerups, exit};
		audio = GetComponent<AudioSource>();
		audio.Play();
		audio.Play(44100);
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey && e.type == EventType.KeyDown) {
			if(e.keyCode == KeyCode.DownArrow) {
				removeCursor();
				if(choice == 2) {
					choice = 0;
				} else {
					choice++;
				}
				addCursor();
			} else if (e.keyCode == KeyCode.UpArrow) {
				removeCursor();
				if(choice == 0) {
					choice = 2;
				} else {
					choice--;
				}
				addCursor();
			} else if(e.keyCode == KeyCode.Return) {
				switch (choice) {
				case 0:
					Play ();
					break;
				case 1:
					PowerUps();
					break;
				case 2:
					Exit ();
					break;
				}
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Exit() {
		Application.Quit();
	}

	public void Play() {
		Application.LoadLevel("Game");
	}

	public void PowerUps() {
		Application.LoadLevel ("PowerUps");
	}

	private void addCursor() {
		texts [choice].text = "- " + texts [choice].text;
	}

	private void removeCursor() {
		texts [choice].text = texts [choice].text.Substring (2);
	}
}
