using Graph.NET.Core.Exceptions;

namespace Graph.NET.Core.Models
{
    public class Graph : IGraph
    {
        //public IVertex? Root => _vertices.FirstOrDefault();

        //public IEnumerable<IVertex> Vertices => _vertices;

        IVertex? IGraph.Root { get => _vertices.FirstOrDefault(); }
        IEnumerable<IVertex> IGraph.Vertices { get => _vertices; }
        int IGraph.MaxEdges { get => (_vertices.Count * (_vertices.Count - 1)) / 2; }

        private List<IVertex> _vertices;

        public Graph()
        {
            _vertices = new();
        }

        public int MaxEdges()
        {
            return (_vertices.Count * (_vertices.Count - 1)) / 2;
        }
    }
}
