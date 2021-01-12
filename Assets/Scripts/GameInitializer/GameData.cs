using SaveSystem.Data;

public class GameData
{
	public LabyrinthSystem.Maze maze;

	public GameData() { }
	
	public GameData(GameSaveData saveData)
	{
		maze = new LabyrinthSystem.Maze(saveData.labyrinth);
	}
}
