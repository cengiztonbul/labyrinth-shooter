namespace SaveSystem.Data
{
	[System.Serializable]
	public class GameSaveData
	{
		public MazeSaveData Labyrinth { get; set; }

		public PlayerData PlayerData { get; set; }

		public Position[] enemyPositions { get; set; }

		public float[] enemyHealth { get; set; }
		
		public float playerHealth { get; set; }

		public GameSaveData() { }

		public GameSaveData(GameData gameData)
		{
			Labyrinth = new MazeSaveData(gameData.maze);
			PlayerData = new PlayerData(gameData.playerPosition, gameData.bulletCount);

			enemyPositions = new Position[gameData.enemyPositions.Count];
			enemyHealth = new float[gameData.enemyHealth.Count];
			playerHealth = gameData.playerHealth;
			
			for (int i = 0; i < gameData.enemyPositions.Count; i++)
			{
				enemyPositions[i] = new Position(gameData.enemyPositions[i]);
				enemyHealth[i] = gameData.enemyHealth[i];
			}
		}
	}
}