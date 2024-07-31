

namespace Graphs;

class Program
{
    public static void Main()
    {
        var graph = new Graph(
                        "0->1,543",
                        "0->2",
                        "1->2",
                        "1->3",
                        "2->3",
                        "2->4",
                        "3->4 , 99d");

        var weights = new Dictionary<Edge, double>();

        var list = graph.GetPath()!.ToList();

        foreach (var node in list)
        {
            Console.WriteLine(node.NodeNumber);
        }

        Console.WriteLine(graph[3, 4]);
        Console.WriteLine(graph[0, 1]);
        Console.WriteLine(graph[1, 3]);
        Console.WriteLine(graph[2, 0]);
    }

}