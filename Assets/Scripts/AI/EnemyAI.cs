using LabyrinthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	Maze maze;
	bool hasTarget;
	bool[] visited;
	Vector2Int target;
	List<Cell> pathResult;

	float moveTime = 0.5f;
	float time = 0;

	private void Start()
	{
		pathResult = new List<Cell>();
	}
	
	public void Update()
	{
		time += Time.deltaTime;

		if (pathResult.Count > 0 && time > moveTime)
		{
			time = 0;
			Cell nextCell = pathResult[0];
			pathResult.RemoveAt(0);
			transform.position = new Vector3(nextCell.position.x, transform.position.y, nextCell.position.y);
		}
		if (!hasTarget)
		{
			hasTarget = true;
			pathResult = new List<Cell>();
			target = RandomTarget();
			visited = new bool[maze.CellCount];
			List<Cell> path = new List<Cell>();
			FindPath(CurrentCell(), target, path);
			pathResult = result;
		}
		if(ReachedTarget())
		{
			hasTarget = false;
		}
	}

	public List<Cell> Path()
	{
		return null;
	}

	//public List<Cell> FindPath(Cell currentCell, Vector2Int target, List<Cell> path)
	//{
	//	visited[maze.GetSingleDimensionIndex(currentCell.position)] = true;
	//	List<Cell> localPath = new List<Cell>(path);
	//	localPath.Add(currentCell);
	//	if (currentCell.position == target)
	//	{
	//		localPath.Add(currentCell);
	//		return localPath;
	//	}
	//	foreach (Cell nextCell in currentCell.Links)
	//	{
	//		if (!visited[maze.GetSingleDimensionIndex(nextCell.position)])
	//		{
	//			localPath.Add(nextCell);
	//			var lastPath = FindPath(nextCell, target, localPath);
	//			if (lastPath != null)
	//			{
	//				return lastPath;
	//			}
	//		}
	//	}

	//	return null;
	//}

	public List<Cell> result;

	public void FindPath(Cell currentCell, Vector2Int target, List<Cell> path)
	{
		visited[maze.GetSingleDimensionIndex(currentCell.position)] = true;
		if (currentCell.position == target)
		{
			result = new List<Cell>(path);
			result.Add(currentCell);
			return;
		}

		foreach (Cell cell in currentCell.GetLinks())
		{
			if (!visited[maze.GetSingleDimensionIndex(cell.position)])
			{
				path.Add(currentCell);
				FindPath(cell, target, path);
			}
		}
		
		path.RemoveAt(path.Count - 1);
	}

	bool found = false;
	List<Cell> path = new List<Cell>();
	public void FindPath(Cell currentCell, Vector2Int target)
	{
		path.Add(currentCell);
		found = currentCell.position == target;

		if (!found)
		{
			foreach(Cell link in currentCell.GetLinks())
			{
				if (found)
				{
					break;
				}
				FindPath(currentCell, target);
			}
		}

		if (!found)
		{
			path.Remove(currentCell);
		}
	}
	public void SetMaze(Maze maze)
	{
		this.maze = maze;
		visited = new bool[maze.CellCount];
	}

	public Vector2Int RandomTarget()
	{
		Vector2Int target = new Vector2Int();
		target.x = Random.Range(0, maze.Width);
		target.y = Random.Range(0, maze.Height);

		return target;
	}

	public bool ReachedTarget()
	{
		Vector3 targetPos = new Vector3();
		targetPos.x = target.x;
		targetPos.z = target.y;

		return (targetPos - transform.position).sqrMagnitude < 0.3f;
	}

	public Cell CurrentCell()
	{
		return maze.GetCell(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
	}
}
