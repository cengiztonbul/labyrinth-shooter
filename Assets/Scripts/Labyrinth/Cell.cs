using SaveSystem.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LabyrinthSystem
{
	public class Cell
	{
		public Vector2Int position;
		
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

		public Cell(CellSaveData cellSaveData)
		{
			position = cellSaveData.Position.ToVector2Int();
		}

		public void SetCellNeigbours(CellNeighbours neighbours)
		{
			this.Neighbours = neighbours;
		}

		public void SetCellLinks(CellNeighbours links)
		{
			this.linkNeigbours = links;
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
		
		public List<Cell> GetLinks()
		{
			List<Cell> neighbours = new List<Cell>();

			if (linkNeigbours.North != null) neighbours.Add(linkNeigbours.North);
			if (linkNeigbours.South != null) neighbours.Add(linkNeigbours.South);
			if (linkNeigbours.East != null) neighbours.Add(linkNeigbours.East);
			if (linkNeigbours.West != null) neighbours.Add(linkNeigbours.West);

			return neighbours;
		}

		public CellSaveData GetSaveData()
		{
			CellSaveData save = new CellSaveData();
			save.Position = new PositionIndex(this.position);

			CellNeighbourIndicies neighborIndicies = new CellNeighbourIndicies();
			CellNeighbourIndicies linkIndicies = new CellNeighbourIndicies();

			if (Neighbours.East != null)
				neighborIndicies.East = new PositionIndex(Neighbours.East.position);
			if (Neighbours.West != null)
				neighborIndicies.West = new PositionIndex(Neighbours.West.position);
			if (Neighbours.North != null)
				neighborIndicies.North = new PositionIndex(Neighbours.North.position);
			if (Neighbours.South != null)
				neighborIndicies.South = new PositionIndex(Neighbours.South.position);

			if (linkNeigbours.East != null)
				linkIndicies.East = new PositionIndex(linkNeigbours.East.position);
			if (linkNeigbours.West != null)
				linkIndicies.West = new PositionIndex(linkNeigbours.West.position);
			if (linkNeigbours.North != null)
				linkIndicies.North = new PositionIndex(linkNeigbours.North.position);
			if (linkNeigbours.South != null)
				linkIndicies.South = new PositionIndex(linkNeigbours.South.position);

			save.Neigbours = neighborIndicies;
			save.Links = linkIndicies;

			return save;
		}
	}
}
