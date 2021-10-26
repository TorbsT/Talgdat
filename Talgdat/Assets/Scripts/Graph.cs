using System.Collections.Generic;
public class Graph
{
    // 3D not supported
    
    public Node[] Nodes { get => _nodes; }
    public int[,] NeighbourMatrix { get => _neighbourMatrix; }

    private readonly int _size;
    private readonly bool _directed;
    private readonly bool _weighted;
    private readonly int[,] _neighbourMatrix;
    private readonly Node[] _nodes;
    private List<ICommand> _commands = new List<ICommand>();

    public Graph(int size, bool directed, bool weighted)
    {
        _size = size;
        _directed = directed;
        _weighted = weighted;
        _nodes = new Node[size];
        _neighbourMatrix = new int[size,size];
        // add ability to set weights
    }
    public float GetCircumference(params int[] indexes)
    {
        if (indexes.Length < 2) throw new System.ArgumentException("tried getting circumference of " + indexes.Length + " nodes");
        float result = 0f;
        int from, to;
        for (int i = 0; i < indexes.Length - 1; i++)
        {
            from = indexes[i];
            to = indexes[i+1];
            if (EdgeExists(from, to)) result += GetEdgeWeight(from, to);
        }
        from = indexes[indexes.Length - 1];
        to = indexes[0];
        if (EdgeExists(from, to)) result += GetEdgeWeight(from, to);
        return result;
    }
    public bool EdgeExists(int a, int b) => GetEdgeWeight(a, b) > 0;
    public float GetEdgeWeight(int a, int b) => _neighbourMatrix[a, b];
    public bool OutOfRange(int index) => index < 0 || index >= _size;
}
