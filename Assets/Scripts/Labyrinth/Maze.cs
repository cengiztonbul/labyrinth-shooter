using SaveSystem.Data;
using UnityEngine;

namespace LabyrinthSystem
{
	public class Maze
	{
		public int Height { get; private set; }
		public int Width { get; private set; }
		public int CellCount { get; private set; }

		public Cell[] _cells;

		public Maze(int height, int width)
		{
			Height = height;
			Width = width;
			CellCount = height * width;
	
			InitGrid();
			LinkNeighbours();
		}

		public Maze(MazeSaveData mazeSave)
		{
			InitGrid(mazeSave);
		}

		private void InitGrid(MazeSaveData mazeSave)
		{
			this.Height = mazeSave.Height;
			this.Width = mazeSave.Height;
			this.CellCount = mazeSave.CellCount;

			_cells = new Cell[Height * Width];

			for (int i = 0; i < _cells.Length; i++)
			{
				_cells[i] = new Cell(mazeSave.Cells[i]);
			}
			for (int i = 0; i < _cells.Length; i++)
			{
				_cells[i].SetCellLinks(Index2Neighbor(mazeSave.Cells[i].Links));
				_cells[i].SetCellNeigbours(Index2Neighbor(mazeSave.Cells[i].Neigbours));
			}
		}

		public CellNeighbours Index2Neighbor(CellNeighbourIndicies indicies)
		{
			CellNeighbours neighbours = new CellNeighbours();
			
			if (indicies.East != null)
				neighbours.East = _cells[indicies.East.y * Width + indicies.East.x];
			if (indicies.West != null)
				neighbours.West = _cells[indicies.West.y * Width + indicies.West.x];
			if (indicies.North != null)
				neighbours.North = _cells[indicies.North.y * Width + indicies.North.x];
			if (indicies.South != null)
				neighbours.South = _cells[indicies.South.y * Width + indicies.South.x];

			return neighbours;
		}

		private void InitGrid()
		{
			_cells = new Cell[Height * Width];
			
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					_cells[j * Width + i] = new Cell(i, j);
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
						GetCell(y, x).Neighbours.North = GetCell(y - 1, x);
					}
					if (y < (Height - 1))
					{
						GetCell(y, x).Neighbours.South = GetCell(y + 1, x);
					}
					if (x < (Width - 1))
					{
						GetCell(y, x).Neighbours.East = GetCell(y, x + 1);
					}
					if (x > 0)
					{
						GetCell(y, x).Neighbours.West = GetCell(y, x - 1);
					}
				}
			}
		}

		public Cell GetRandomCell()
		{

			int row = Random.Range(0, Height);
			int column = Random.Range(0, Width);
			return GetCell(row, column);
		}

		public Cell GetCell(int x, int y)
		{
			return _cells[y * Width + x];
		}
	}
	
}
