using UnityEngine;
using System.Collections;

public class TetrisScript : MonoBehaviour {
	private const int heightUnits = 70;
	private const int numberOfTetrisCells = 14;
	private int columns = heightUnits/numberOfTetrisCells;
	private const int rows = 14;
	private int[,] tetrisMatrix;

	// Use this for initialization
	void Start () {
		tetrisMatrix = new int[columns,rows];
		for (int i =0; i<columns; i++) {
			for(int j=0;j<rows;j++) {
				tetrisMatrix[i,j] = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.CompareTag ("ball")) {
			// Generate tetris block
			int [,] block = {{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};

		}
	}
}
