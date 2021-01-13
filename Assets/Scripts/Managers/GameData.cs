using SaveSystem.Data;
using UnityEngine;

public class GameData
{
	public LabyrinthSystem.Maze maze;

	public Vector3 playerPosition;
	
	public int bulletCount;

	public GameData() { }
	
	public GameData(GameSaveData saveData)
	{
		maze = new LabyrinthSystem.Maze(saveData.Labyrinth);
		playerPosition = saveData.PlayerData.PlayerPosition.ToVector3();
		bulletCount = saveData.PlayerData.BulletCount;
	}
}
