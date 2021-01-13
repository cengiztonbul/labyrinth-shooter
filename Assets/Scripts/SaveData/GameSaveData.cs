namespace SaveSystem.Data
{
	[System.Serializable]
	public class GameSaveData
	{
		public MazeSaveData Labyrinth { get; set; }

		public PlayerData PlayerData { get; set; }

		public Position[] enemyPositions { get; set; }

		public GameSaveData() { }

		public GameSaveData(GameData gameData)
		{
			Labyrinth = new MazeSaveData(gameData.maze);
			PlayerData = new PlayerData(gameData.playerPosition, gameData.bulletCount);

			enemyPositions = new Position[gameData.enemyPositions.Count];
			for (int i = 0; i < gameData.enemyPositions.Count; i++)
			{
				enemyPositions[i] = new Position(gameData.enemyPositions[i]);
			}
		}
	}
}