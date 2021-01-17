using UnityEngine;

namespace LabyrinthSystem
{
	public class WorldGenerator : MonoBehaviour
	{
		[SerializeField] GameObject wall;
		[SerializeField] GameObject ground;
		[SerializeField] GameObject exitPoint;

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
						InstantiateExit(labyrinth.Width, labyrinth.Height, i, j);
						continue;
					}
					InstantiateCell(labyrinth.GetCell(i, j), i, j);
				}
			}
		}

		void InstantiateExit(int width, int height, int i, int j)
		{
			Transform groundObj = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity).transform;

			if (i == 0 && j == 0)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i , 0, j - 1), Quaternion.identity).transform;
				Instantiate(exitPoint, new Vector3(i, 0, j - 1), Quaternion.identity);

				Vector3 spawnPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;
				
				spawnPosition = new Vector3(+0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;
			}
			else if (i == 0 && (j == height - 1))
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i, 0, j +1), Quaternion.identity).transform;
				Instantiate(exitPoint, new Vector3(i, 0, j + 1), Quaternion.identity);

				Vector3 spawnPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;

				spawnPosition = new Vector3(+0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;
			}
			else if (i == width - 1 && (j == height - 1))
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i, 0, j + 1), Quaternion.identity).transform;
				Instantiate(exitPoint, new Vector3(i, 0, j + 1), Quaternion.identity);

				Vector3 spawnPosition = new Vector3(+0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;

				spawnPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;
			}
			else if (i == width - 1 && j == 0)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i, 0, j - 1), Quaternion.identity).transform;
				Instantiate(exitPoint, new Vector3(i, 0, j - 1), Quaternion.identity);

				Vector3 spawnPosition = new Vector3(+0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), groundObj).transform.localPosition = spawnPosition;
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;

				spawnPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(wall, spawnPosition, Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = spawnPosition;
			}
			else if (i == 0)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i - 1, 0, j), Quaternion.identity).transform;
				Instantiate(wall, new Vector3(0f, 0.5f, 0.5f), Quaternion.identity, outsideGround).transform.localPosition = new Vector3(0f, 0.5f, 0.5f);
				Instantiate(wall, new Vector3(0f, 0.5f, -0.5f), Quaternion.identity, outsideGround).transform.localPosition = new Vector3(0f, 0.5f, -0.5f);
				Instantiate(exitPoint, new Vector3(i - 1, 0, j), Quaternion.identity);
			}
			else if (i == width - 1)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i + 1, 0, j), Quaternion.identity).transform;
				Instantiate(wall, new Vector3(0f, 0.5f, 0.5f), Quaternion.identity, outsideGround).transform.localPosition = new Vector3(0f, 0.5f, 0.5f);
				Instantiate(wall, new Vector3(0f, 0.5f, -0.5f), Quaternion.identity, outsideGround).transform.localPosition = new Vector3(0f, 0.5f, -0.5f);
				Instantiate(exitPoint, new Vector3(i + 1, 0, j), Quaternion.identity);
			}
			else if (j == 0)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i, 0, j - 1), Quaternion.identity).transform;
				Instantiate(wall, new Vector3(0.5f, 0.5f, 0f), Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = new Vector3(0.5f, 0.5f, 0f);
				Instantiate(wall, new Vector3(-0.5f, 0.5f, 0f), Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(exitPoint, new Vector3(i, 0, j - 1), Quaternion.identity);
			}
			else if (j == height - 1)
			{
				Transform outsideGround = Instantiate(ground, new Vector3(i, 0, j + 1), Quaternion.identity).transform;
				Instantiate(wall, new Vector3(0.5f, 0.5f, 0f), Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = new Vector3(0.5f, 0.5f, 0f);
				Instantiate(wall, new Vector3(-0.5f, 0.5f, 0f), Quaternion.Euler(0, 90, 0), outsideGround).transform.localPosition = new Vector3(-0.5f, 0.5f, 0f);
				Instantiate(exitPoint, new Vector3(i, 0, j + 1), Quaternion.identity);
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
