using UnityEngine;
using LabyrinthSystem;

public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] Vector2Int labyrinthSize;

	Maze maze;
	
	public void OnNewGameStart()
	{
		maze = worldGenerator.GenerateWorld(labyrinthSize.x, labyrinthSize.y);
	}

	public void SaveGame()
	{
		GameData saveData = new GameData();
		saveData.labyrinth = maze;
		BayatGames.SaveGameFree.SaveGame.Save<GameData>("game_data", saveData);
	}

	public void Init(GameData gd)
	{
		worldGenerator.InstantiateLabyrinth(gd.labyrinth);
	}

	public void LoadGameData()
	{
		GameData gd = BayatGames.SaveGameFree.SaveGame.Load<GameData>("game_data");
		worldGenerator.InstantiateLabyrinth(gd.labyrinth);
	}
}
