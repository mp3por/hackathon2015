﻿using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	// The Grid itself
	public static int w = 14;
	public static int h = 14;
	public static float cellSize = 5;
	private static Vector2 displacement = new Vector2(0,-65);
	public static Transform[,] grid = new Transform[w, h];

	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round((v.y-displacement.x+w*cellSize/2)/cellSize),
		                   Mathf.Round((-(displacement.y-v.x)+h*cellSize)/cellSize));
	}

	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
		        (int)pos.x < w &&
		        (int)pos.y >= 0 &&
		        (int)pos.y <= h);
	}

	public static void deleteRow(int y) {
		for (int x = 0; x < w; ++x) {
			Destroy(grid[x, y].gameObject);
			grid[x, y] = null;
		}
	}

	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid[x, y] != null) {
				// Move one towards bottom
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;
				
				// Update Block position
				grid[x, y-1].position += new Vector3(-cellSize, 0, 0);
			}
		}
	}

	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i)
			decreaseRow(i);
	}

	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x)
			if (grid[x, y] == null)
				return false;
		return true;
	}

	public static void deleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
	}
}