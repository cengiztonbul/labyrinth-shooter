using LabyrinthSystem;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{

	public Labyrinth maze;
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

	public void SetMaze(Labyrinth maze)
	{
		this.maze = maze;
	}
}
