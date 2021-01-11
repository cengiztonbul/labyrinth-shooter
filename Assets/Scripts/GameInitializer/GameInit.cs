using UnityEngine;
using LabyrinthSystem;


public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] Vector2Int labyrinthSize;
	string _encodePassword;
	Maze maze;

	private void Start()
	{
		string _encodePassword = "labyrinth_shooter_password";
		BayatGames.SaveGameFree.SaveGame.EncodePassword = _encodePassword;
		BayatGames.SaveGameFree.SaveGame.Encode = true;
		BayatGames.SaveGameFree.SaveGame.Serializer = new BayatGames.SaveGameFree.Serializers.SaveGameBinarySerializer();
	}

	public void OnNewGameStart()
	{
		maze = worldGenerator.GenerateWorld(labyrinthSize.x, labyrinthSize.y);
	}

	public void SaveGame()
	{
		GameData saveData = new GameData();
		saveData.labyrinth = maze.GetSaveData();
		BayatGames.SaveGameFree.SaveGame.Save<GameData>("game_data", saveData);

	}

	public void Init(GameData gd)
	{
		Maze m = new Maze(gd.labyrinth);
		worldGenerator.InstantiateLabyrinth(m);
	}

	public void LoadGameData()
	{

		GameData gd = BayatGames.SaveGameFree.SaveGame.Load<GameData>("game_data");
		Maze m = new Maze(gd.labyrinth);
		worldGenerator.InstantiateLabyrinth(m);
	}
}
