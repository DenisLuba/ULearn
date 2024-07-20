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

        foreach (var node in graph.GetPath()!)
        {
            Console.WriteLine(node.NodeNumber);
        }
    }

}