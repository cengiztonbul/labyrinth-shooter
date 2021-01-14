using LabyrinthSystem;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
	[SerializeField] EnemyState idle;
	[SerializeField] EnemyState chase;
	Transform player;

	private void Start()
	{
		stateName = "Patrol State";
		player = FindObjectOfType<PlayerShooting>().transform;
	}

	public override void OnStart()
	{
		target = RandomTarget();
		hasTarget = true;
		pathResult = new List<Cell>();
		visited = new bool[AI.maze.CellCount];
		List<Cell> path = new List<Cell>();
		FindPath(CurrentCell(), target, path);
		SetNextCell();
	}

	public override void Tick()
	{
		if (!hasTarget)
		{
			AI.ChangeState(idle);
		}
		if (CanSeePlayer())
		{
			AI.ChangeState(chase);
		}
		FollowPath();
	}

	public bool CanSeePlayer()
	{
		Ray ray = new Ray(transform.position, (player.position - transform.position).normalized);
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			if (hit.collider.transform == player)
			{
				return true;
			}
		}
		return false;
	}

	public Vector2Int RandomTarget()
	{
		Vector2Int target = new Vector2Int();
		target.x = Random.Range(0, AI.maze.Width);
		target.y = Random.Range(0, AI.maze.Height);

		return target;
	}

	#region PathFinding
	
	bool[] visited;
	List<Cell> pathResult;
	
	public void FindPath(Cell currentCell, Vector2Int target, List<Cell> path)
	{
		visited[AI.maze.GetSingleDimensionIndex(currentCell.position)] = true;
		if (currentCell.position == target)
		{
			pathResult = new List<Cell>(path);
			pathResult.Add(currentCell);
			return;
		}

		foreach (Cell cell in currentCell.GetLinks())
		{
			if (!visited[AI.maze.GetSingleDimensionIndex(cell.position)])
			{
				path.Add(currentCell);
				FindPath(cell, target, path);
			}
		}

		path.RemoveAt(path.Count - 1);
	}
	#endregion

	#region PathFollowing

	Vector3 moveDirection;
	float speed = 1.3f;

	bool hasTarget;
	Cell nextCell;
	Vector2Int target;

	public void FollowPath()
	{
		if (!hasTarget)
		{
			return;
		}
		if (pathResult.Count > 0 && nextCell == null)
		{
			SetNextCell();
		}
		if (nextCell != null)
		{
			MoveToNextCell();
		}
		if (nextCell != null && ReachedNextCell())
		{
			nextCell = null;
		}
		if (hasTarget && ReachedTarget())
		{
			nextCell = null;
			hasTarget = false;
		}
	} 

	private void SetNextCell()
	{
		nextCell = pathResult[0];
		pathResult.RemoveAt(0);
		moveDirection = (GetCellPosition(nextCell) - transform.position).normalized;
	}

	private void MoveToNextCell()
	{
		transform.position += moveDirection * speed * Time.deltaTime;
	}

	private bool ReachedNextCell()
	{
		return (GetCellPosition(nextCell) - transform.position).sqrMagnitude < 0.2f;
	}

	private bool ReachedTarget()
	{
		Vector3 targetPos = new Vector3();
		targetPos.x = target.x;
		targetPos.z = target.y;
		targetPos.y = 0.5f;
		return (targetPos - transform.position).sqrMagnitude <= 0.2f;
	}
	#endregion

	#region Utils
	public Cell CurrentCell()
	{
		return AI.maze.GetCell(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
	}

	public Vector3 GetCellPosition(Cell cell)
	{
		return new Vector3(Mathf.RoundToInt(cell.position.x), 0.5f, Mathf.RoundToInt(cell.position.y));
	}
	#endregion
}
