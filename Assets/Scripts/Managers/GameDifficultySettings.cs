using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "DifficultySettings", order = 1)]
public class GameDifficultySettings : ScriptableObject
{
	public Vector2Int labyrinthSize;
	public int enemyCount;
	public int bulletCount;
}
