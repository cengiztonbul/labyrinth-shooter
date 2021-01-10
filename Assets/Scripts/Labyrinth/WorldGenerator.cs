using UnityEngine;

namespace LabyrinthSystem
{
	public class WorldGenerator : MonoBehaviour
	{
		public GameObject wall;
		public GameObject ground;

		LabyrinthGenerator labyrinthGenerator;


		private void Awake()
		{
			labyrinthGenerator = new LabyrinthGenerator();	
		}


		public void GenerateWorld(int size_x, int size_y)
		{
			Maze m = labyrinthGenerator.GenerateLabyrinth(size_x, size_y);
			InstantiateLabyrinth(m);
		}


		void InstantiateLabyrinth(Maze labyrinth)
		{
			for (int i = 0; i < labyrinth.Cells.GetLength(0); i++)
			{
				for (int j = 0; j < labyrinth.Cells.GetLength(1); j++)
				{
					InstantiateCell(labyrinth.Cells[i, j], i, j);
				}
			}
		}


		void InstantiateCell(Cell cell, int i, int j)
		{
			Transform groundObj = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity).transform;

			if (cell.linkNeigbours.East == null)
			{
				Vector3 spawnPosition = new Vector3(+0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
			}
			if (cell.linkNeigbours.West == null)
			{
				Vector3 spawnPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
			}
			if (cell.linkNeigbours.North == null)
			{
				Vector3 spawnPosition = new Vector3(0f, 0.5f, 0.5f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 0, 0), groundObj).transform.localPosition = spawnPosition;
			}
			if (cell.linkNeigbours.South == null)
			{
				Vector3 spawnPosition = new Vector3(0f, 0.5f, -0.5f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 0, 0), groundObj).transform.localPosition = spawnPosition;
			}
		}
	}
}
