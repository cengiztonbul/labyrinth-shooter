namespace SaveSystem.Data
{
	[System.Serializable]
	public class GameSaveData
	{
		public MazeSaveData Labyrinth { get; set; }

		public PlayerData PlayerData { get; set; }

		public GameSaveData() { }

		public GameSaveData(GameData gameData)
		{
			Labyrinth = new MazeSaveData(gameData.maze);
			PlayerData = new PlayerData(gameData.playerPosition, gameData.bulletCount);
		}
	}
}