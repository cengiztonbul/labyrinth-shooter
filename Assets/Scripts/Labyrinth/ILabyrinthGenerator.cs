namespace LabyrinthSystem
{
	interface ILabyrinthGenerator
	{
		Maze GenerateLabyrinth(int size_x, int size_y);
	}
}
