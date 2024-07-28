namespace Graphs;
internal class KruskalsAlgorithm
{
    public static IEnumerable<Edge> FindMinimumSpanningTree(IEnumerable<Edge> edges)
    {
        var tree = new List<Edge>();

        foreach (var edge in edges.OrderBy(x => x.Weight))
        {
            tree.Add(edge);
            if (Util.HasCycle(tree))
                tree.Remove(edge);
        }
        return tree;
    }
}