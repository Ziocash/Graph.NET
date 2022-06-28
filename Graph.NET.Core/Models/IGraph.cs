namespace Graph.NET.Core.Models
{
    public interface IGraph
    {
        IVertex? Root { get; }

        IEnumerable<IVertex> Vertices { get; }

        public int MaxEdges { get; }
    }
}