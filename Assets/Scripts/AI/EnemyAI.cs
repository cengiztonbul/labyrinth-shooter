using LabyrinthSystem;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Maze maze;
	EnemyState currentState;

	private void Start()
	{
		currentState = GetComponent<PatrolState>();
		currentState.OnStart();
	}

	public void Update()
	{
		currentState.Tick();
	}

	public void ChangeState(EnemyState nextState)
	{
		currentState?.OnExit();
		nextState.OnStart();

		this.currentState = nextState;
	}

	public void SetMaze(Maze maze)
	{
		this.maze = maze;
	}
}
