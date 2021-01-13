using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Text difficultyText;

	[Header("Difficulty Levels")]
	[SerializeField] GameDifficultySettings easy;
	[SerializeField] GameDifficultySettings normal;
	[SerializeField] GameDifficultySettings hard;

	public GameDifficultySettings PrefferedDifficulty { get; set; }

	private void Start()
	{
		PrefferedDifficulty = easy;
		difficultyText.text = "Easy";
	}

	public void OnSliderChange(System.Single value)
	{
		if (value == 1)
		{
			PrefferedDifficulty = easy;
			difficultyText.text = "Easy";
		}
		else if (value == 2)
		{
			PrefferedDifficulty = normal;
			difficultyText.text = "Normal";
		}
		else if (value == 3)
		{
			PrefferedDifficulty = hard;
			difficultyText.text = "Hard";
		}
	}
}
