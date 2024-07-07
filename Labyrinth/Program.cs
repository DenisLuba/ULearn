namespace Labyrinth;

public class Program
{
    public static void Main()
    {
        var labyrinth = new Maze();

        //Run.TraversingInWidth(labyrinth);
        Run.TraversingInDepth(labyrinth);
    }
}