using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Text difficultyText;

	[Header("Difficulty Level Sizes")]
	[SerializeField] Vector2Int labyrinthSizeEasy;
	[SerializeField] Vector2Int labyrinthSizeNormal;
	[SerializeField] Vector2Int labyrinthSizeHard;

	[Header("Difficulty Level Enemy Counts")]
	[SerializeField] int enemyCountEasy;
	[SerializeField] int enemyCountNormal;
	[SerializeField] int enemyCountHard;

	public Vector2Int PreferredLabyrinthSize { get; private set; }
	public int PreferredEnemyCount { get; private set; }

	private void Start()
	{
		PreferredEnemyCount = enemyCountEasy;
		PreferredLabyrinthSize = labyrinthSizeEasy;
		difficultyText.text = "Easy";
	}

	public void OnSliderChange(System.Single value)
	{
		if (value == 1)
		{
			PreferredEnemyCount = enemyCountEasy;
			PreferredLabyrinthSize = labyrinthSizeEasy;
			difficultyText.text = "Easy";
		}
		else if (value == 2)
		{
			PreferredEnemyCount = enemyCountNormal;
			PreferredLabyrinthSize = labyrinthSizeNormal;
			difficultyText.text = "Normal";
		}
		else if (value == 3)
		{
			PreferredEnemyCount = enemyCountHard;
			PreferredLabyrinthSize = labyrinthSizeHard;
			difficultyText.text = "Hard";
		}
	}
}
