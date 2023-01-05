using Graph.NET.Core.Models.Graphs.Vertices;

namespace Graph.NET.Core.Models.Graphs.Unweighted.Edges
{
    public class Edge<TValue> : IEdge<TValue>
    {
        public Edge()
        { }

        public Edge(IVertex<TValue> source, IVertex<TValue> destination)
        {
            Source = source;
            Destination = destination;
        }

        public IVertex<TValue>? Source { get; set; }

        public IVertex<TValue>? Destination { get; set; }
    }
}
