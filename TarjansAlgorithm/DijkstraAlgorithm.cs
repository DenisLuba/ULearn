using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Graphs;

public class DijkstraAlgorithm
{
    class DijkstraData(Node? previous, double price)
    {
        public Node? Previous { get; init; } = previous;
        public double Price { get; init; } = price;
    }

    public static List<Node>? Dijkstra(Graph graph, Dictionary<Edge, double> weights, Node start, Node? end)
    {
        var notVisited = graph.Nodes.ToList();
        var track = new Dictionary<Node, DijkstraData>();

        track[start] = new DijkstraData(null, 0);

        while (true)
        {
            Node? toOpen = null;
            var bestPrice = double.PositiveInfinity;
            foreach (var node in notVisited)
            {
                if (track.ContainsKey(node) && track[node].Price < bestPrice)
                {
                    bestPrice = track[node].Price;
                    toOpen = node;
                }
            }

            if (toOpen is null) return null;
            if (toOpen == end) break;

            foreach (var edge in toOpen.IncidentEdges.Where(e => e.From == toOpen))
            {
                var currentPrice = track[toOpen].Price + weights[edge];
                var nextNode = edge.To;

                if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                {
                    track[nextNode] = new DijkstraData(previous: toOpen, price: currentPrice);
                }
            }

            notVisited.Remove(toOpen);
        }

        var result = new List<Node>();
        while (end is not null)
        {
            result.Add(end);
            end = track[end].Previous;
        }
        result.Reverse();
        return result;
    }
}
