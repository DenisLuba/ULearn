namespace Graphs;

class Program
{
    public static void Main()
    {
        var graph = new Graph(
                        "0->1",
                        "0->2",
                        "1->2",
                        "1->3",
                        "2->3",
                        "2->4",
                        "3->4");

        var graph2 = new Graph(
            "0->1",
            "1->2",
            "2->0");

        foreach (var node in graph.GetPath()!)
        {
            Console.WriteLine(node.NodeNumber);
        }

        Console.WriteLine(Util.HasCycle(graph2));
    }

}