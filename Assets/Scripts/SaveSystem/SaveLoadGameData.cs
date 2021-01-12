using BayatGames.SaveGameFree;
using SaveSystem.Data;

namespace SaveSystem
{
	public class SaveLoadGameData
	{
		private readonly string _encodePassword = "labyrinth_shooter_password";
		private readonly string _saveFileName = "save.data";
		
		public SaveLoadGameData()
		{
			BayatGames.SaveGameFree.SaveGame.EncodePassword = _encodePassword;
			BayatGames.SaveGameFree.SaveGame.Encode = true;
			BayatGames.SaveGameFree.SaveGame.Serializer = new BayatGames.SaveGameFree.Serializers.SaveGameBinarySerializer();
		}

		public void Save(GameData gameData)
		{
			GameSaveData saveData = new GameSaveData(gameData);
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
