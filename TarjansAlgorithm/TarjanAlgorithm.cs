
namespace Graphs;

public static class TarjanAlgorithm
{
    public static List<Node>? GetPath(this Graph graph)
    {
        var path = new List<Node>();
        var states = graph.Nodes.ToDictionary(node => node, node => State.NotVisited);

        while (true)
        {
            var nodeToSearch = states
                .Where(n => n.Value == State.NotVisited)
                .Select(n => n.Key)
                .FirstOrDefault();

            if (nodeToSearch is null) break;

            if (!TarjanDepthSearch(nodeToSearch, states, path))
                return null;
        }
        path.Reverse();
        return path;
    }

    private static bool TarjanDepthSearch(
        Node node, 
        Dictionary<Node, State> states, 
        List<Node> path)
    {
        if (states[node] == State.Visited) return false;
        if (states[node] == State.Finished) return true;
        states[node] = State.Visited;

        foreach (var nextNode in node.IncidentNodesTo)
            if (!TarjanDepthSearch(nextNode, states, path)) return false;

        states[node] = State.Finished;
        path.Add(node);
        return true;
    }
}

enum State
{
    NotVisited,
    Visited,
    Finished
}
