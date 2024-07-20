using System.Text.RegularExpressions;

namespace Graphs;

public class Graph
{
    Node[] nodes;
    public int Length { get => nodes.Length; }
    public Node this[int index] { get => nodes[index]; }
    public IEnumerable<Node> Nodes
    {
        get
        {
            foreach (var node in nodes) yield return node;
        }
    }

    public IEnumerable<Edge> Edges
    {
        get => nodes.SelectMany(n => n.IncidentEdges).Distinct();
    }

    public Graph(params string[] incidentNodes)
    {
        var nodesList = new List<Node>();
        nodes = incidentNodes
            .Select(StringToInts)
            .Aggregate(nodesList, (a, b) => AddNode(nodesList, b))
            .OrderBy(n => n.NodeNumber)
            .ToArray();
    }

    public Node[] Connect(Node from, Node to) 
        => Nodes.Contains(from) && Nodes.Contains(to) 
        ? Node.Connect(from, to)
        : throw new ArgumentException(); 

    public bool Remove(Edge edge) => Node.Disconnect(edge);

    // ***********************************************************

    static IEnumerable<int> StringToInts(string fromTo)
    {
        var pattern = @"\D*(\d*)\D*((<-)|(->))\D*(\d*)\D*";
        var exceptionMessage = "Write an edge \"from->to\" or \"to<-from\", for example \"1->2\"";
        if (!Regex.IsMatch(fromTo, pattern)) throw new ArgumentException(exceptionMessage);

        fromTo = Regex.Replace(fromTo, pattern, "$1$2$5");
        return Regex.Replace(fromTo, @"(\d+)<-(\d+)", "$2->$1")
              .Split("->")
              .Select(int.Parse);
    }

    static List<Node> AddNode(List<Node> nodes, IEnumerable<int> twoInts)
    {
        var node1 = nodes.Where(node => node.NodeNumber == twoInts.ElementAt(0)).FirstOrDefault() ?? new Node(twoInts.ElementAt(0));
        var node2 = nodes.Where(node => node.NodeNumber == twoInts.ElementAt(1)).FirstOrDefault() ?? new Node(twoInts.ElementAt(1));
        var edge = new Edge(node1, node2);
        node1.AddEdge(edge);
        node2.AddEdge(edge);
        if (!nodes.Contains(node1)) nodes.Add(node1);
        if (!nodes.Contains(node2)) nodes.Add(node2);
        return nodes;
    }
}
