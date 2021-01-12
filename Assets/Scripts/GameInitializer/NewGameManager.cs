using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Text difficultyText;

	[Header("Difficulty Levels")]
	[SerializeField] Vector2Int labyrinthSizeEasy;
	[SerializeField] Vector2Int labyrinthSizeNormal;
	[SerializeField] Vector2Int labyrinthSizeHard;

	public Vector2Int PreferredLabyrinthSize { get; private set; }

	private void Start()
	{
		PreferredLabyrinthSize = labyrinthSizeEasy;
		difficultyText.text = "Easy";
	}

	public void OnSliderChange(System.Single value)
	{
		if (value == 1)
		{
			PreferredLabyrinthSize = labyrinthSizeEasy;
			difficultyText.text = "Easy";
		}
		else if (value == 2)
		{
			PreferredLabyrinthSize = labyrinthSizeNormal;
			difficultyText.text = "Normal";
		}
		else if (value == 3)
		{
			PreferredLabyrinthSize = labyrinthSizeHard;
			difficultyText.text = "Hard";
		}
	}
}
