namespace SaveSystem.Data
{
	[System.Serializable]
	public class GameSaveData
	{
		public MazeSaveData labyrinth { get; set; }

		public GameSaveData() { }

		public GameSaveData(GameData gameData)
		{
			labyrinth = new MazeSaveData(gameData.maze);
		}
	}
}