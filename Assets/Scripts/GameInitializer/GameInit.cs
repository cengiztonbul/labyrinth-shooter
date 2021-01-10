using UnityEngine;
using LabyrinthSystem;

public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] Vector2Int labyrinthSize;
	
	private void Start()
	{
	}

	public void OnGameStart()
	{
		worldGenerator.GenerateWorld(labyrinthSize.x, labyrinthSize.y);
	}
}

