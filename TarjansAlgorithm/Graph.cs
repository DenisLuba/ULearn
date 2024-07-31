using System.Text.RegularExpressions;

namespace Graphs;

public class Graph
{
    Node[] nodes;
    public int Length { get => nodes.Length; }
    public Node this[int index] { get => nodes[index]; }
    public Edge? this[int from, int to] 
    { 
        get => nodes
            .Where(node => node.NodeNumber == from || node.NodeNumber == to)
            .SelectMany(node => node.IncidentEdges)
            .Where(edge => edge.From.NodeNumber == from && edge.To.NodeNumber == to)
            .FirstOrDefault(); 
    }
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

    public Edge Connect(Node from, Node to) 
        => Nodes.Contains(from) && Nodes.Contains(to) 
        ? Node.Connect(from, to)
        : throw new ArgumentException(); 

    public bool Remove(Edge edge) => Node.Disconnect(edge);

    // ***********************************************************

    static List<int> StringToInts(string fromTo)
    {
        var pattern = @"\D*(\d*)\D*((<-)|(->))\D*(\d*)\D*(?=(D*\d+))";
        var patternWithoutWeight = @"\D*(\d+)\D*((<-)|(->))\D*(\d+)[^,\d]*";
        var patternWithWeight = @"\D*(\d+)\D*((<-)|(->))\D*(\d+)\D*,\D*(\d+)\D*";
        var exceptionMessage = "Write an edge \"from->to\" or \"to<-from\", for example \"1->2\"";
        if (!Regex.IsMatch(fromTo, pattern)) throw new ArgumentException(exceptionMessage);

        // превращаем строку в строку вида, например, 11->22->33,
        // где 11 - номер узла, из которого выходит ребро, 22 - куда приходит, 33 - вес ребра;
        // возвращаем лист: 0 элемент будет 11, 1 - 22, 2 - 33
        return Regex.Replace(Regex.IsMatch(fromTo, patternWithWeight)
                ? Regex.Replace(fromTo, patternWithWeight, "$1$4$5->$6")
                : Regex.Replace(fromTo, patternWithoutWeight, "$1$4$5->0"),
                @"(\d+)<-(\d+)->\d+",
                "$2->$1->$3")
              .Split("->")
              .Select(int.Parse)
              .ToList();
    }


    static List<Node> AddNode(List<Node> nodes, List<int> list)
    {
        var node1 = nodes.Where(node => node.NodeNumber == list[0]).FirstOrDefault() ?? new Node(list[0]);
        var node2 = nodes.Where(node => node.NodeNumber == list[1]).FirstOrDefault() ?? new Node(list[1]);
        var edge = new Edge(node1, node2, list[2]);
        node1.AddEdge(edge);
        node2.AddEdge(edge);
        if (!nodes.Contains(node1)) nodes.Add(node1);
        if (!nodes.Contains(node2)) nodes.Add(node2);
        return nodes;
    }
}
