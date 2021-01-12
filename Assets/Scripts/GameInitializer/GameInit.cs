using UnityEngine;
using UnityEngine.UI;
using LabyrinthSystem;
using SaveSystem.Data;
using System;

public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] Vector2Int labyrinthSize;
	[SerializeField] Button loadButton;

	Maze maze;
	GameData gameData;
	SaveSystem.SaveLoadGameData gameSaver;

	private void Awake()
	{
		gameData = new GameData();
		gameSaver = new SaveSystem.SaveLoadGameData();
	}

	private void Start()
	{
		loadButton.interactable = gameSaver.SaveFileExist();	
	}

	public void OnNewGameStart()
	{
		maze = worldGenerator.GenerateWorld(labyrinthSize.x, labyrinthSize.y);
		gameData.maze = maze;
	}

	public void SaveGame()
	{
		gameSaver.Save(gameData);
	}

	public void Init(GameSaveData gd)
	{
		Maze m = new Maze(gd.labyrinth);
		worldGenerator.InstantiateLabyrinth(m);
	}

	public void LoadGameData()
	{
		try
		{
			GameData gd = gameSaver.Load();
			this.gameData = gd;
			worldGenerator.InstantiateLabyrinth(gd.maze);
		}
		catch (Exception exception)
		{
			Debug.LogError(exception);
		}
	}
}
