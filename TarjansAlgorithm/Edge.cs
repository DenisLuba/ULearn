namespace Graphs;

public class Edge
{
    public Node From { get; } 
    public Node To { get; } 

    public int Weight { get; } 

    public Edge(Node first, Node second, int weight = 0)
    {
        From = first;
        To = second;
        Weight = weight;

        From.AddEdge(this);
        To.AddEdge(this);
    }

    public Edge(int first, int second, int weight = 0) : this(new Node(first), new Node(second), weight) { }

    public bool IsIncident(Node node) => From == node || To == node;

    public Node OtherNode(Node node)
        => IsIncident(node) 
        ? (node == From ? To : From)
        : throw new ArgumentException();

    public override string ToString() => $"From = {From.NodeNumber}, To = {To.NodeNumber}, Weight = {Weight}";
}
