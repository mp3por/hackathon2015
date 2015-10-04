using UnityEngine;
using System.Collections;

public class GroupTwo : MonoBehaviour {
	float lastFall = 0;
	public float step = 5;

	void Start() {
		if(!isValidGridPos()) {
			GameObject ball = GameObject.FindGameObjectWithTag("ball");
			BallScript bs = ball.GetComponent<BallScript>() as BallScript;
			bs.PlayerWin(1);
			Destroy(ball);
			Destroy(gameObject);
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Slash)) {
			transform.Rotate(0, 0, -90);
			if (isValidGridPos())
				updateGrid();
			else
				transform.Rotate(0, 0, 90);
		}
		if(Time.time - lastFall >= 0.5) {
			transform.position += new Vector3(step, 0, 0);
			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(-step, 0, 0);
				GridTwo.deleteFullRows();
				enabled = false;
			}
			
			lastFall = Time.time;
		}
	}

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = GridTwo.roundVec2(child.position);
			if (!GridTwo.insideBorder(v))
				return false;
			if (GridTwo.grid[(int)v.x, (int)v.y] != null &&
			    GridTwo.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		for (int y = 0; y < GridTwo.h; ++y)
			for (int x = 0; x < GridTwo.w; ++x)
				if (GridTwo.grid[x, y] != null)
					if (GridTwo.grid[x, y].parent == transform)
						GridTwo.grid[x, y] = null;
		foreach (Transform child in transform) {
			Vector2 v = GridTwo.roundVec2(child.position);
			GridTwo.grid[(int)v.x, (int)v.y] = child;
		}
	}
}