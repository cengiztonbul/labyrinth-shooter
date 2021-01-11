using UnityEngine;

public class PositionIndex
{
	public int x;
	public int y;

	public PositionIndex(Vector2Int position)
	{
		this.x = position.x;
		this.y = position.y;
	}

	public Vector2Int ToVector2Int()
	{
		return new Vector2Int(x, y);
	}
}

