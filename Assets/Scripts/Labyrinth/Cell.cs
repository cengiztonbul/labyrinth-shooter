using System.Collections.Generic;
using UnityEngine;

namespace LabyrinthSystem
{
	public class Cell
	{
		Vector2Int position;
		
		public CellNeighbours Neighbours { get; set; }
		public CellNeighbours linkNeigbours;
		public List<Cell> Links = new List<Cell>();

		public Cell(int row, int column)
		{
			position.x = row;
			position.y = column;

			Neighbours = new CellNeighbours();
			linkNeigbours = new CellNeighbours();
		}


		public Cell AddLink(Cell cell, bool bidirectional)
		{
			Vector2Int relativePosition = cell.position - position;
			Links.Add(cell);

			if (relativePosition == Vector2Int.left)
			{
				linkNeigbours.West = cell;
			}
			if (relativePosition == Vector2Int.right)
			{
				linkNeigbours.East = cell;
			}
			if (relativePosition == Vector2Int.up)
			{
				linkNeigbours.North = cell;
			}
			if (relativePosition == Vector2Int.down)
			{
				linkNeigbours.South = cell;
			}

			if (bidirectional)
				cell.AddLink(this, false);

			return this;
		}


		public List<Cell> GetNeighbours()
		{
			List<Cell> neighbours = new List<Cell>();

			if (Neighbours.North != null) neighbours.Add(Neighbours.North);
			if (Neighbours.South != null) neighbours.Add(Neighbours.South);
			if (Neighbours.East != null) neighbours.Add(Neighbours.East);
			if (Neighbours.West != null) neighbours.Add(Neighbours.West);

			return neighbours;
		}
	}
}
