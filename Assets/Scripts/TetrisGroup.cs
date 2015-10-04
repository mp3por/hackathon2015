using UnityEngine;
using System.Collections;

public class TetrisGroup : MonoBehaviour
{

	void Start() {
		Debug.Log ("tetrisGroup start");
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}


	float lastFall = 0;

	bool isValidGridPos ()
	{        
		foreach (Transform child in transform) {
			Vector2 v = TetrisGrid.roundVec2 (child.position);
			
			// Not inside Border?
			if (!TetrisGrid.insideBorder (v))
				return false;
			
			// Block in grid cell (and not part of same group)?
			if (TetrisGrid.grid [(int)v.x, (int)v.y] != null &&
			    TetrisGrid.grid [(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid ()
	{
		// Remove old children from grid
		for (int y = 0; y < TetrisGrid.h; ++y)
			for (int x = 0; x < TetrisGrid.w; ++x)
				if (TetrisGrid.grid [x, y] != null)
					if (TetrisGrid.grid [x, y].parent == transform)
						TetrisGrid.grid [x, y] = null;
		
		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = TetrisGrid.roundVec2 (child.position);
			TetrisGrid.grid [(int)v.x, (int)v.y] = child;
		}        
	}

	void Update ()
	{
		// Move Left
		if (Input.GetKeyDown (KeyCode.E)) {
			transform.Rotate (0, 0, -90);
			
			// See if valid
			if (isValidGridPos ())
				// It's valid. Update grid.
				updateGrid ();
			else
				// It's not valid. revert.
				transform.Rotate (0, 0, 90);
		}

		if (Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3 (0, -1, 0);
			
			// See if valid
			if (isValidGridPos ()) {
				// It's valid. Update grid.
				updateGrid ();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3 (0, 1, 0);
				
				// Clear filled horizontal lines
				TetrisGrid.deleteFullRows ();

				// Disable script
				enabled = false;
			}
			
			lastFall = Time.time;
		}
	}
}
