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
		saveData.labyrinth = maze.GetSaveData();
		BayatGames.SaveGameFree.SaveGame.Save<GameData>("game_data", saveData);
		Vector2Int pos = new Vector2Int(1, 4);
		BayatGames.SaveGameFree.SaveGame.Save<Vector2Int>("pos", pos);

	}

	public void Init(GameData gd)
	{
		Maze m = new Maze(gd.labyrinth);
		worldGenerator.InstantiateLabyrinth(m);
	}

	public void LoadGameData()
	{

		GameData gd = BayatGames.SaveGameFree.SaveGame.Load<GameData>("game_data");
		Vector2Int pos = BayatGames.SaveGameFree.SaveGame.Load<Vector2Int>("pos");
		Debug.Log("loaded_pos: " + pos);
		Maze m = new Maze(gd.labyrinth);
		worldGenerator.InstantiateLabyrinth(m);
	}
}
