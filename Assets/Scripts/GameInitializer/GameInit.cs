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
	[SerializeField] GameObject playerPref;
	[SerializeField] Camera startCamera;
	[SerializeField] GameObject playerObj;

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
		Vector3 startPos;
		startPos.x = (int)(newGameManager.PreferredLabyrinthSize.x / 2);
		startPos.z = (int)(newGameManager.PreferredLabyrinthSize.y / 2);
		startPos.y = 1;
		playerObj = Instantiate(playerPref, startPos, Quaternion.identity);
		startCamera.gameObject.SetActive(false);
		FindObjectOfType<EnemyAI>().SetMaze(maze);
	}

	public void SaveGame()
	{
		gameData.playerPosition = playerObj.transform.position;
		gameData.bulletCount = playerObj.GetComponent<PlayerShooting>().BulletCount;
		gameSaver.Save(gameData);
	}

	public void LoadGameData()
	{
		try
		{
			GameData gd = gameSaver.Load();
			this.gameData = gd;
			worldGenerator.InstantiateLabyrinth(gd.maze);
			playerObj = Instantiate(playerPref, gd.playerPosition, Quaternion.identity);
			PlayerShooting playerShooting = playerObj.GetComponent<PlayerShooting>();
			playerShooting.SetPlayer(gameData.playerPosition, gameData.bulletCount);
			startCamera.gameObject.SetActive(false);
		}
		catch (Exception exception)
		{
			Debug.LogError(exception);
		}
	}
}
