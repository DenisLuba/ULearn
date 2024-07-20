using System.Linq;
using System.Runtime.CompilerServices;

namespace Graphs;

public class Node(int number)
{
    readonly List<Edge> edges = new List<Edge>();
    public IEnumerable<Edge> IncidentEdges
    {
        get { foreach (var e in edges) yield return e; }
    }

    public IEnumerable<Node> IncidentNodes
    {
        get => edges.Select(e => e.OtherNode(this));
    }

    public IEnumerable<Node> IncidentNodesTo
    {
        get => edges.Where(e => e.From == this).Select(e => e.OtherNode(this));
    }

    public IEnumerable<Node> IncidentNodesFrom
    {
        get => edges.Where(e => e.To == this).Select(e => e.OtherNode(this));
    }

    public int NodeNumber { get; init; } = number;

    internal static Node[] Connect(Node from, Node to)
    {
        var edge = new Edge(from, to);
        from.edges.Add(edge);
        to.edges.Add(edge);
        return [from, to];
    }

    internal static bool Disconnect(Edge edge)
        => edge.From.edges.Remove(edge) 
        && edge.To.edges.Remove(edge);

    public void AddEdge(Edge edge) 
    {
        if (!edges.Contains(edge)) 
            edges.Add(edge);
    }

    public bool Equals(Node other) => other.NodeNumber == NodeNumber;
           
}
