using UnityEngine;
using System.Collections;

public class GroupOne : MonoBehaviour {
	float lastFall = 0;
	public float step = 5;

	void Awake() {
		if (!isValidGridPos()) {
			GameObject ball = GameObject.FindGameObjectWithTag("ball");
			BallScript bs = ball.GetComponent<BallScript>();
			bs.PlayerWin(2);
			Destroy(ball);
			Destroy(gameObject);
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			transform.Rotate(0, 0, -90);
			if (isValidGridPos())
				updateGrid();
			else
				transform.Rotate(0, 0, 90);
		}
		
		if(Time.time - lastFall >= 0.5) {
			transform.position += new Vector3(-step, 0, 0);
			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(step, 0, 0);
				GridOne.deleteFullRows();
				enabled = false;
			}
			lastFall = Time.time;
		}
	}

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = GridOne.roundVec2(child.position);
			if (!GridOne.insideBorder(v))
				return false;
			if (GridOne.grid[(int)v.x, (int)v.y] != null &&
			    GridOne.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		for (int y = 0; y < GridOne.h; ++y)
			for (int x = 0; x < GridOne.w; ++x)
				if (GridOne.grid[x, y] != null)
					if (GridOne.grid[x, y].parent == transform)
						GridOne.grid[x, y] = null;
		
		foreach (Transform child in transform) {
			Vector2 v = GridOne.roundVec2(child.position);
			GridOne.grid[(int)v.x, (int)v.y] = child;
		}        
	}
}