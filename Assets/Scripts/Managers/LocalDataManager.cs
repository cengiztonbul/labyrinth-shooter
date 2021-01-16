using BayatGames.SaveGameFree;
using SaveSystem.Data;

namespace SaveSystem
{
	public class LocalDataManager
	{
		private readonly string _encodePassword = "labyrinth_shooter_password";
		private readonly string _saveFileName = "save.data";
		
		public LocalDataManager()
		{
			BayatGames.SaveGameFree.SaveGame.EncodePassword = _encodePassword;
			BayatGames.SaveGameFree.SaveGame.Encode = true;
			BayatGames.SaveGameFree.SaveGame.Serializer = new BayatGames.SaveGameFree.Serializers.SaveGameBinarySerializer();
		}

		public void Save(GameData gameData)
		{
			GameSaveData saveData = new GameSaveData(gameData);
			saveData.PlayerData = new PlayerData(gameData.playerPosition, gameData.bulletCount, gameData.playerHealth);
			BayatGames.SaveGameFree.SaveGame.Save<GameSaveData>(_saveFileName, saveData);
		}
		
		public GameData Load()
		{
			GameSaveData loadedData = BayatGames.SaveGameFree.SaveGame.Load<GameSaveData>(_saveFileName);
			GameData gameData = new GameData(loadedData);
			return gameData;
		}

		public bool SaveFileExist()
		{
			return SaveGame.Exists(_saveFileName);
		}
	}
}
