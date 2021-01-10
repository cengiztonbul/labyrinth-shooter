using UnityEngine;
using LabyrinthSystem;

public class CellSave
{
	public Vector2Int Position { get; set; }

	public CellNeighbourIndicies Neigbours { get; set; }
	
	public CellNeighbourIndicies Links { get; set; }
}
