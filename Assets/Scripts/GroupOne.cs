using UnityEngine;
using System.Collections;

public class GroupOne : MonoBehaviour {
	// Time since last gravity tick
	float lastFall = 0;
	public float step;

	void Start() {
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			GameObject ball = GameObject.Find("Ball");

			BallScript bs = ball.GetComponent<BallScript>();
			
			bs.PlayerWin(1);

			Destroy(ball);
			Destroy(gameObject);
		}
	}
	
	void Update() {
//		// Move Left
//		if (Input.GetKeyDown(KeyCode.DownArrow)) {
//			// Modify position
//			transform.position += new Vector3(0, -step, 0);
//			
//			// See if valid
//			if (isValidGridPos())
//				// It's valid. Update grid.
//				updateGrid();
//			else
//				// It's not valid. revert.
//				transform.position += new Vector3(0, step, 0);
//		}
		
//		// Move Right
//		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
//			// Modify position
//			transform.position += new Vector3(0, step, 0);
//			
//			// See if valid
//			if (isValidGridPos())
//				// It's valid. Update grid.
//				updateGrid();
//			else
//				// It's not valid. revert.
//				transform.position += new Vector3(0, -step, 0);
//		}
		
		// Rotate
		if (Input.GetKeyDown(KeyCode.E)) {
			transform.Rotate(0, 0, -90);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.Rotate(0, 0, 90);
		}
		
		// Move Downwards and Fall
//		else if (Input.GetKeyDown(KeyCode.LeftArrow) ||
		if(Time.time - lastFall >= 0.5) {
			// Modify position
			transform.position += new Vector3(-step, 0, 0);
			
			// See if valid
			if (isValidGridPos()) {
				// It's valid. Update grid.
				updateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(step, 0, 0);
				
				// Clear filled horizontal lines
				GridOne.deleteFullRows();
				
				// Spawn next Group
//				FindObjectOfType<Spawner>().spawnNext();
				
				// Disable script
				enabled = false;
			}
			
			lastFall = Time.time;
		}
	}

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = GridOne.roundVec2(child.position);
			          			
			// Not inside Border?
			if (!GridOne.insideBorder(v))
				return false;
			
			// Block in grid cell (and not part of same group)?
			if (GridOne.grid[(int)v.x, (int)v.y] != null &&
			    GridOne.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < GridOne.h; ++y)
			for (int x = 0; x < GridOne.w; ++x)
				if (GridOne.grid[x, y] != null)
					if (GridOne.grid[x, y].parent == transform)
						GridOne.grid[x, y] = null;
		
		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = GridOne.roundVec2(child.position);
			GridOne.grid[(int)v.x, (int)v.y] = child;
		}        
	}
}