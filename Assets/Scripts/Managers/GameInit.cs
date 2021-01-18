using UnityEngine;
using UnityEngine.UI;
using LabyrinthSystem;
using SaveSystem.Data;
using SaveSystem;
using System;
using System.Collections.Generic;

public class GameInit : MonoBehaviour
{
	[SerializeField] WorldGenerator worldGenerator;
	[SerializeField] NewGameManager newGameManager;

	[SerializeField] Button loadButton;
	[SerializeField] GameObject playerPref;
	[SerializeField] GameObject enemyPref;
	[SerializeField] Camera startCamera;
	[SerializeField] GameObject playerObj;

	Labyrinth maze;
	GameData gameData;
	LocalDataManager gameSaver;
	List<EnemyAI> enemies;

	private void Awake()
	{
		gameData = new GameData();
		gameSaver = new LocalDataManager();
		enemies = new List<EnemyAI>();
	}

	private void Start()
	{
		loadButton.interactable = gameSaver.SaveFileExist();
	}

	public void OnNewGameStart()
	{
		maze = worldGenerator.GenerateWorld(newGameManager.PrefferedDifficulty.labyrinthSize.x, newGameManager.PrefferedDifficulty.labyrinthSize.y);
		gameData.maze = maze;
		Vector3 startPos;
		startPos.x = (int)(newGameManager.PrefferedDifficulty.labyrinthSize.x / 2);
		startPos.z = (int)(newGameManager.PrefferedDifficulty.labyrinthSize.y / 2);
		startPos.y = .3f;
		playerObj = Instantiate(playerPref, startPos, Quaternion.identity);
		startCamera.gameObject.SetActive(false);
		playerObj.GetComponent<PlayerShooting>().SetPlayer(startPos, newGameManager.PrefferedDifficulty.bulletCount);
		for (int i = 0; i < newGameManager.PrefferedDifficulty.enemyCount; i++)
		{
			CreateEnemy();
		}
	}

	public void SaveGame()
	{
		gameData.playerPosition = playerObj.transform.position;
		gameData.bulletCount = playerObj.GetComponent<PlayerShooting>().BulletCount;
		gameData.playerHealth = playerObj.GetComponent<Health>().health;
		gameData.enemyPositions = new List<Vector3>();
		gameData.enemyHealth = new List<float>();
		for (int i = 0; i < enemies.Count; i++)
		{
			if (enemies[i].gameObject.activeSelf)
			{
				gameData.enemyPositions.Add(enemies[i].transform.position);
				gameData.enemyHealth.Add(enemies[i].GetComponent<Health>().health);
			}
		}
		
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
			playerShooting.GetComponent<Health>().SetHealth(gameData.playerHealth);
			for (int i = 0; i < gd.enemyPositions.Count; i++)
			{
				CreateEnemy(gd.enemyPositions[i], gd.enemyHealth[i]);
			}
		}
		catch (Exception exception)
		{
			Debug.LogError(exception);
		}
	}

	public void ClearScene()
	{
		GameObject exitPoint = GameObject.FindGameObjectWithTag("ExitPoint");
		if (exitPoint != null) Destroy(exitPoint);
		for (int i = 0; i < enemies.Count; i++)
		{
			if (enemies[i] != null)
			{
				Destroy(enemies[i].GetComponent<Health>().healthBar.gameObject);
				Destroy(enemies[i].gameObject);
			}
		}
		HealthBar hb = playerObj.GetComponent<Health>().healthBar;
		if(hb != null)
        {
			Destroy(hb.gameObject);
		}
		Destroy(playerObj);

		GameObject[] mapObjects = GameObject.FindGameObjectsWithTag("MapObject");
		for (int i = 0; i < mapObjects.Length; i++)
		{
			Destroy(mapObjects[i]);
		}

		gameData = new GameData();
		gameSaver = new LocalDataManager();
		enemies = new List<EnemyAI>();

		startCamera.gameObject.SetActive(true);
		Destroy(GameObject.Find("PlayerCamera"));
	}

	public void CreateEnemy()
	{
		Vector3 position = new Vector3();
		position.x = UnityEngine.Random.Range(0, newGameManager.PrefferedDifficulty.labyrinthSize.x);
		position.z = UnityEngine.Random.Range(0, newGameManager.PrefferedDifficulty.labyrinthSize.y);
		position.y = 0.5f;
		EnemyAI enemy = Instantiate(enemyPref, position, Quaternion.identity).GetComponent<EnemyAI>();
		enemy.SetMaze(gameData.maze);
		enemies.Add(enemy);
	}

	public void CreateEnemy(Vector3 position, float health)
	{
		EnemyAI enemy = Instantiate(enemyPref, position, Quaternion.identity).GetComponent<EnemyAI>();
		enemy.SetMaze(gameData.maze);
		enemy.GetComponent<Health>().SetHealth(health);
		enemies.Add(enemy);
	}

	public void FreezeTime()
	{
		Time.timeScale = 0;
	}

	public void ResumeTime()
	{
		Time.timeScale = 1;
	}
}
