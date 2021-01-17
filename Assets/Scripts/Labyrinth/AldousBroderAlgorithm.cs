using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LabyrinthSystem
{
	public class AldousBroderAlgorithm : ILabyrinthGenerator
	{
		public Labyrinth GenerateLabyrinth(int x, int y)
		{
			Labyrinth grid = new Labyrinth(x, y);
            System.Random rand = new System.Random((int)DateTime.Now.Ticks);
			Cell currentCell = grid.GetRandomCell();
			int unvisited = grid.CellCount - 1;

			while (unvisited > 0)
			{
				List<Cell> neighbours = currentCell.GetNeighbours();
				Cell nextNeighbour = neighbours[rand.Next(neighbours.Count)];

				if (!nextNeighbour.Links.Any())
				{
					currentCell.AddLink(nextNeighbour, true);
					unvisited--;
				}

				currentCell = nextNeighbour;
			}

			grid.ExitIndex = GetRandomEdge(x, y);
			return grid;
		}
		public Vector2Int GetRandomEdge(int size_x, int size_y)
		{
			Vector2Int result = new Vector2Int();
			int number = UnityEngine.Random.Range(0, 2);
			if (number == 0)
			{
				int[] exitIndex_x = { 0, size_x - 1 };
				result.x = exitIndex_x[UnityEngine.Random.Range(0, 2)];
				result.y = UnityEngine.Random.Range(0, size_y);
			}
			else
			{
				int[] exitIndex_y = { 0, size_y - 1 };
				result.y = exitIndex_y[UnityEngine.Random.Range(0, 2)];
				result.x = UnityEngine.Random.Range(0, size_x);
			}

			return result;
		}
	}
}