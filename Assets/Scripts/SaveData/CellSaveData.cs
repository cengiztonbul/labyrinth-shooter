using LabyrinthSystem;

namespace SaveSystem.Data
{
	[System.Serializable]
	public class CellSaveData
	{
		public PositionIndex Position { get; set; }

		public CellNeighbourIndicies Neigbours { get; set; }
	
		public CellNeighbourIndicies Links { get; set; }

		public CellSaveData() { }

		public CellSaveData(Cell cell)
		{
			Position = new PositionIndex(cell.position);

			CellNeighbourIndicies neighborIndicies = new CellNeighbourIndicies();
			CellNeighbourIndicies linkIndicies = new CellNeighbourIndicies();

			if (cell.Neighbours.East != null)
				neighborIndicies.East = new PositionIndex(cell.Neighbours.East.position);
			if (cell.Neighbours.West != null)
				neighborIndicies.West = new PositionIndex(cell.Neighbours.West.position);
			if (cell.Neighbours.North != null)
				neighborIndicies.North = new PositionIndex(cell.Neighbours.North.position);
			if (cell.Neighbours.South != null)
				neighborIndicies.South = new PositionIndex(cell.Neighbours.South.position);

			if (cell.linkNeigbours.East != null)
				linkIndicies.East = new PositionIndex(cell.linkNeigbours.East.position);
			if (cell.linkNeigbours.West != null)
				linkIndicies.West = new PositionIndex(cell.linkNeigbours.West.position);
			if (cell.linkNeigbours.North != null)
				linkIndicies.North = new PositionIndex(cell.linkNeigbours.North.position);
			if (cell.linkNeigbours.South != null)
				linkIndicies.South = new PositionIndex(cell.linkNeigbours.South.position);

			Neigbours = neighborIndicies;
			Links = linkIndicies;

		}
	}
}
