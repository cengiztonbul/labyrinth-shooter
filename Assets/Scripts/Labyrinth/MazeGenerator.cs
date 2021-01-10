using System;
using System.Collections.Generic;
using System.Linq;

namespace LabyrinthSystem
{
	public class AldousBroderMazeGenerator
	{

		public void CreateMaze(Maze grid)
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
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
		}
	}
}