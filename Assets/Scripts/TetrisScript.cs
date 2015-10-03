using UnityEngine;
using System.Collections.Generic;

public class TetrisScript : MonoBehaviour {
	private const int columns = 14;
	private const int rows = 19;
	private int[,] tetrisMatrix;
	
	private const float heightUnits = 70;
	private float columnWidth = heightUnits/columns;

	private int startUnitX = -68;
	private int startUnitY = 35;

	private List<TetrisBlock> tetrisBlockList = new List<TetrisBlock>();
	public GameObject tetrisBlockObject;

	// Use this for initialization
	void Start () {
		for (int i=0; i<columns; i++) {
			for(int j=0;j<rows;j++) {
				GameObject tem = Instantiate(tetrisBlockObject);
				tem.gameObject.GetComponent<Renderer>().enabled = false;
				tem.transform.position = new Vector2(startUnitX - columnWidth*j, startUnitY - columnWidth*i);
				tem.gameObject.name = "left"+i+"_"+j;
			}
		}

		tetrisMatrix = new int[columns, rows];
		for (int i =0; i<columns; i++) {
			for (int j=0; j<rows; j++) {
				tetrisMatrix [i, j] = 0;
			}
		}

		InvokeRepeating("Update_custom", 0, 1F);
	}
	
	// Update is called once per frame
	void Update_custom () {
		if (tetrisBlockList.Count!=0) {
			for (int i=0; i<columns; i++) {
				for (int j=0;j<rows;j++) {
					if(tetrisMatrix[i,j] == 1) {
						GameObject tem = GameObject.Find("left"+i+"_"+j);
						tem.gameObject.GetComponent<Renderer>().enabled = true;
					} else {
						GameObject tem = GameObject.Find("left"+i+"_"+j);
						tem.gameObject.GetComponent<Renderer>().enabled = false;
					}
				}
			}

			for(int i=0;i<tetrisBlockList.Count;i++){
				TetrisBlock tetrisBlock = tetrisBlockList[i];
				if(tetrisBlock.checkBoard(tetrisMatrix)) {
					//Go one down without writing
					if(!tetrisBlock.progress()) {
						//Can't go down, need to write
						tetrisBlock.write(ref tetrisMatrix);
//						tetrisBlock.draw();
						tetrisBlockList.RemoveAt(i);
						i--;
					}
					tetrisBlock.draw();
				} else {
					//can't move down
					if(tetrisBlock.isOverflown()) {
						//End game
					} else {
						tetrisBlock.write(ref tetrisMatrix);
//						tetrisBlock.draw();
						tetrisBlockList.RemoveAt(i);
						i--;
					}
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.CompareTag ("ball")) {
			int column = (int)(columns*((-1*collision.gameObject.transform.position.y + 35) / heightUnits));
			Debug.Log(collision.gameObject.transform.position.y);
			if(column + 4 > columns) {
				column = columns - 4;
			}
			tetrisBlockList.Add(new TetrisBlock(Random.Range(0,7), new Vector2(column, 0)));
		}
	}
}
