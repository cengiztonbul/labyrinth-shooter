using LabyrinthSystem;

namespace SaveSystem.Data
{
	[System.Serializable]
	public class MazeSaveData
	{
		public int Height { get; set; }

		public int Width { get; set; }

		public int CellCount { get; set; }

		public CellSaveData[] Cells { get; set; }

		public MazeSaveData() { }
		
		public MazeSaveData(Labyrinth maze)
		{
			Height = maze.Height;
			Width = maze.Width;
			CellCount = maze.CellCount;
			Cells = new CellSaveData[CellCount];

			for (int i = 0; i < CellCount; i++)
			{
				Cells[i] = new CellSaveData(maze._cells[i]);
			}
		}
	}
}
