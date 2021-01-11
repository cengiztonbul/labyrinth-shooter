using UnityEngine;
using LabyrinthSystem;

[System.Serializable]
public class CellSave
{
	public PositionIndex Position { get; set; }

	public CellNeighbourIndicies Neigbours { get; set; }
	
	public CellNeighbourIndicies Links { get; set; }
}
