using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs;

public static class FordBellmanAlgorithm
{


    public static int GetMinPathCost(List<Edge> edges,  int startNode, int finalNode)
    {
        var maxNodeIndex = edges
            .SelectMany(edge => new[] { edge.From.NodeNumber, edge.To.NodeNumber })
            .Concat([startNode, finalNode])
            .Max();

        var opt = Enumerable.Repeat(int.MaxValue, maxNodeIndex + 1).ToArray();
        opt[startNode] = 0;

        var optCopy = new int[opt.Length];

        for (var pathSize = 1; pathSize <= maxNodeIndex; pathSize++)
        {
            Array.Copy(opt, optCopy, opt.Length);

            opt.Print();

            foreach (var edge in edges)
            {
                if (optCopy[edge.From.NodeNumber] != int.MaxValue)
                {
                    opt[edge.To.NodeNumber] = opt[edge.From.NodeNumber] != int.MaxValue 
                        ? Math.Min(edge.Weight + opt[edge.From.NodeNumber], opt[edge.To.NodeNumber])
                        : edge.Weight;
                }
            }
        }

        return opt[finalNode];
    }

    public static int GetMinPathCost(Graph graph, Node startNode, Node finalNode)
    {
        return GetMinPathCost(graph.Edges.ToList(), startNode.NodeNumber, finalNode.NodeNumber);
    }

    public static int GetMinPathCost(Graph graph, int startNode, int finalNode)
    {
        return GetMinPathCost(graph.Edges.ToList(), startNode, finalNode);
    }

    static void Print(this int[] array) => Console.WriteLine(string.Join(" ", array) + "\n");
    
}
