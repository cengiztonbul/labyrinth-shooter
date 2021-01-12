using UnityEngine;
using UnityEngine.UI;
using LabyrinthSystem;
using SaveSystem.Data;
using SaveSystem;
using System;

public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] NewGameManager newGameManager;

	[SerializeField] Button loadButton;
	
	Maze maze;
	GameData gameData;
	LocalDataManager gameSaver;

	private void Awake()
	{
		gameData = new GameData();
		gameSaver = new LocalDataManager();
	}

	private void Start()
	{
		loadButton.interactable = gameSaver.SaveFileExist();
	}

	public void OnNewGameStart()
	{
		maze = worldGenerator.GenerateWorld(newGameManager.PreferredLabyrinthSize.x, newGameManager.PreferredLabyrinthSize.y);
		gameData.maze = maze;
	}

	public void SaveGame()
	{
		gameSaver.Save(gameData);
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
