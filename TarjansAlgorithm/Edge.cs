namespace Graphs;

public class Edge(Node first, Node second)
{
    public Node From { get; init; } = first;
    public Node To { get; init; } = second;

    public bool IsIncident(Node node) => From == node || To == node;

    public Node OtherNode(Node node)
        => IsIncident(node) 
        ? (node == From ? To : From)
        : throw new ArgumentException();
}
