using LabyrinthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	[SerializeField] Vector2Int target;
	Maze maze;
	bool[] visited;
	Stack<Cell> pathStack;

	bool found = false;
	float moveTime = 0.5f;
	float time = 0;

	private void Start()
	{
		pathStack = new Stack<Cell>();
	}
	
	public void Update()
	{
		time += moveTime;
		if (pathStack.Count > 0 && time > moveTime)
		{
			time = 0;
			Cell nextCell = pathStack.Pop();
			transform.position = new Vector3(nextCell.position.x, transform.position.y, nextCell.position.y);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			visited = new bool[maze.CellCount];
			FindPath(maze.GetCell((int)transform.position.x, (int)transform.position.y), target);
		}
	}

	public void FindPath(Cell currentCell, Vector2Int target)
	{
		visited[maze.Get1DDimension(currentCell.position)] = true;
		pathStack.Push(currentCell);
		if (currentCell.position == target)
		{
			Debug.Log("Found");
			found = true;
		}
		foreach (Cell nextCell in currentCell.Links)
		{
			if (!visited[maze.Get1DDimension(nextCell.position)])
			{
				pathStack.Push(nextCell);
				FindPath(nextCell, target);
			}
			if (!found)
			{
				pathStack.Pop();
			}
		}
	}

	public void SetMaze(Maze maze)
	{
		this.maze = maze;
		visited = new bool[maze.CellCount];
	}
}
