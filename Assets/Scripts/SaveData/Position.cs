using UnityEngine;

[System.Serializable]
public class Position
{
	public float x;
	public float y;
	public float z;

	public Position(Vector3 position)
	{
		this.x = position.x;
		this.y = position.y;
		this.z = position.z;
	}

	public Vector3 ToVector3()
	{
		return new Vector3(x, y, z);
	}
}
