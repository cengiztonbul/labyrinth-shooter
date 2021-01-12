using SaveSystem.Data;

namespace SaveSystem.Data
{
	[System.Serializable]
	public class CellNeighbourIndicies
	{
		public PositionIndex North { get; set; }

		public PositionIndex South { get; set; }

		public PositionIndex East { get; set; }

		public PositionIndex West { get; set; }
	}
}
