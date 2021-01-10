namespace LabyrinthSystem
{
	public class LabyrinthGenerator : ILabyrinthGenerator
	{
		public Maze GenerateLabyrinth(int size_x, int size_y)
		{
			Maze maze = new Maze(size_y, size_x);
			AldousBroderMazeGenerator mazeGenerator = new AldousBroderMazeGenerator();
			mazeGenerator.CreateMaze(maze);
			return maze;
		}
	}
}
