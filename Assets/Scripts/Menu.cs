﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		audio.Play(44100);
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
}
