using SaveSystem.Data;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
	public LabyrinthSystem.Labyrinth maze;

	public Vector3 playerPosition;

	public float playerHealth;

	public int bulletCount;

	public List<Vector3> enemyPositions;
	
	public List<float> enemyHealth;

	public GameData() { }
	
	public GameData(GameSaveData saveData)
	{
		maze = new LabyrinthSystem.Labyrinth(saveData.Labyrinth);
		playerPosition = saveData.PlayerData.PlayerPosition.ToVector3();
		bulletCount = saveData.PlayerData.BulletCount;
		enemyPositions = new List<Vector3>();
		enemyHealth = new List<float>();
		playerHealth = saveData.PlayerData.Health;
		for (int i = 0; i < saveData.enemyPositions.Length; i++)
		{
			enemyPositions.Add(saveData.enemyPositions[i].ToVector3());
			enemyHealth.Add(saveData.enemyHealth[i]);
		}
	}
}
