using UnityEngine;

namespace LabyrinthSystem
{
	public class WorldGenerator : MonoBehaviour
	{
		[SerializeField] GameObject wall;
		[SerializeField] GameObject ground;

		public ILabyrinthGenerator labyrinthGenerator;

		private void Awake()
		{
			labyrinthGenerator = new AldousBroderAlgorithm();
		}

		public Labyrinth GenerateWorld(int size_x, int size_y)
		{
			Labyrinth labyrinth = labyrinthGenerator.GenerateLabyrinth(size_x, size_y);
			InstantiateLabyrinth(labyrinth);
			return labyrinth;
		}

		public void InstantiateLabyrinth(Labyrinth labyrinth)
		{
			
			for (int i = 0; i < labyrinth.Width; i++)
			{
				for (int j = 0; j < labyrinth.Height; j++)
				{
					if (labyrinth.ExitIndex.x==i && labyrinth.ExitIndex.y == j)
                    {
						Transform groundObj = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity).transform;
						continue;
					}
					InstantiateCell(labyrinth.GetCell(i, j), i, j);
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
