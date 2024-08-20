

namespace Graphs;

class Program
{
    public static void Main()
    {
        //var graph = new Graph(
        //                "0->1,543",
        //                "0->2",
        //                "1->2",
        //                "1->3",
        //                "2->3",
        //                "2->4",
        //                "3->4 ,99");

        //foreach (var node in graph.GetPath()!)
        //    node.NodeNumber.Print();


        //Console.WriteLine(graph[3, 4]);
        //Console.WriteLine(graph[0, 1]);
        //Console.WriteLine(graph[1, 3]);
        //Console.WriteLine(graph[2, 0]);

        //graph = new Graph(
        //    "0->1, 1",
        //    "0->2, 6",
        //    "0->3, 2",
        //    "1->2, 4",
        //    "3->2, 2");

        //foreach (var node in graph.GetPath()!)
        //    node.NodeNumber.Print();

        //graph[0, 1].Print();
        //graph[0, 2].Print();
        //graph[0, 3].Print();
        //graph[1, 2].Print(); 
        //graph[3, 2].Print();
        //graph[1, 3].Print();

        //var weights = graph
        //    .Nodes
        //    .SelectMany(node => node.IncidentEdges)
        //    .Distinct()
        //    .ToDictionary(edge => edge, edge => (double) edge.Weight) ?? new Dictionary<Edge, double>();

        //foreach (var pair in weights)
        //    Console.WriteLine($"{pair.Key} = {pair.Value}");

        //foreach (var node in DijkstraAlgorithm.Dijkstra(graph!, weights, graph!.Nodes.ElementAt(0), graph!.Nodes.ElementAt(2))!)
        //    node.NodeNumber.Print();

        var graph = new Graph(
            "0->1,2",
            "0->2,5",
            "2->1,-4",
            "1->3,3",
            "1->4,2",
            "3->4,1");

        Console.WriteLine(graph);
        Console.WriteLine(FordBellmanAlgorithm.GetMinPathCost(graph, 0, 4));
    }

}