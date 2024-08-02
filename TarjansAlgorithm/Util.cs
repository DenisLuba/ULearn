namespace Graphs;

public static class Util
{
    public static bool HasCycle(List<Node> graph)
    {
        var visited = new HashSet<Node>();
        var finished = new HashSet<Node>();
        var stack = new Stack<Node>();

        visited.Add(graph.First());
        stack.Push(graph.First());

        while (stack.Count != 0)
        {
            var node = stack.Pop();
            foreach (var nextNode in node.IncidentNodesTo)
            {
                if (finished.Contains(nextNode)) continue;
                if (visited.Contains(nextNode)) return true;
                visited.Add(nextNode);
                stack.Push(nextNode);
            }
            finished.Add(node);
        }
        return false;
    }

    public static bool HasCycle(Graph graph) => HasCycle(graph.Nodes.ToList());

    public static bool HasCycle(List<Edge> edges) => HasCycle(edges.SelectMany(edge => new[] { edge.From, edge.To }).Distinct().ToList());

    public static void Print(this object? obj) => Console.WriteLine(obj);
}
