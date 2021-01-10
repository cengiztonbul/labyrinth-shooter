using UnityEngine;

namespace LabyrinthSystem
{
	public class Maze
	{
		public int Height { get; private set; }
		public int Width { get; private set; }
		public int CellCount { get; private set; }

		public Cell[,] Cells { get; protected set; }

		public Maze(int height, int width)
		{
			
			Height = height;
			Width = width;
			CellCount = height * width;
	
			InitGrid();
			LinkNeighbours();
		}

		private void InitGrid()
		{
			Cells = new Cell[Height, Width];
			
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					Cells[i, j] = new Cell(i, j);
				}
			}
		}

		private void LinkNeighbours()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					if (y > 0)
					{
						Cells[y, x].Neighbours.North = Cells[y - 1, x];
					}
					if (y < (Height - 1))
					{
						Cells[y, x].Neighbours.South = Cells[y + 1, x];
					}
					if (x < (Width - 1))
					{
						Cells[y, x].Neighbours.East = Cells[y, x + 1];
					}
					if (x > 0)
					{
						Cells[y, x].Neighbours.West = Cells[y, x - 1];
					}
				}
			}
		}

		public Cell GetRandomCell()
		{

			int row = Random.Range(0, Height);
			int column = Random.Range(0, Width);
			return Cells[row, column];
		}

		public Cell GetCell(int x, int y)
		{
			return Cells[x, y];
		}
	}
}
