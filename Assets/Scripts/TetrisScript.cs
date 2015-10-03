using UnityEngine;
using System.Collections.Generic;

public class TetrisScript : MonoBehaviour {
	private const int heightUnits = 70;
	private const int numberOfTetrisCells = 14;
	private int columns = heightUnits/numberOfTetrisCells;
	private const int rows = 18;
	private int[,] tetrisMatrix;
	private const int numberOfBlocks = 7;
	private List<int[,]> blocks = new List<int[,]>();

	// Use this for initialization
	void Start () {
		blocks.Add(new int[,] {{1,1},{1,0},{1,0},{0,0}});
		blocks.Add(new int[,] {{1,0},{1,1},{0,1},{0,0}});
		blocks.Add(new int[,] {{0,1},{1,1},{1,0},{0,0}});
		blocks.Add(new int[,] {{1,1},{1,1},{0,0},{0,0}});
		blocks.Add(new int[,] {{1,1},{0,1},{0,1},{0,0}});
		blocks.Add(new int[,] {{1,0},{1,1},{1,0},{0,0}});
		blocks.Add(new int[,] {{1,0},{1,0},{1,0},{1,0}});

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
			int[,] block = blocks[Random.Range(0,numberOfBlocks)];

			// Append block to tetrisMatrix
			int column = (int)(collision.gameObject.transform.position.y + 35) / heightUnits;

			if(column == 0) {
				column++;
			}


		}
	}
}
