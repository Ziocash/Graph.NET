using Graph.NET.Core.Exceptions;
using Graph.NET.Core.Models.Graphs.Unweighted.Edges;
using Graph.NET.Core.Models.Graphs.Vertices;
using Graph.NET.Core.Models.Visits;
using Graph.NET.Core.Models.Visits.Enums;
using Graph.NET.Core.Visitors;
using System.Text;

namespace Graph.NET.Core.Models.Graphs.Unweighted.Undirected
{
    public class UndirectedGraph<TValue> : IUndirectedGraph<TValue>
    {
        public IVertex<TValue>? Root { get => _vertices.FirstOrDefault(); }
        public IEnumerable<IVertex<TValue>> Vertices { get => _vertices; }
        public int MaxEdges => _vertices.Count * (_vertices.Count - 1) / 2;

        public IEnumerable<IEdge<TValue>> Edges { get => _edges; }

        public bool IsCyclic => CheckCycles();

        private List<IVertex<TValue>> _vertices;

        private List<IEdge<TValue>> _edges;

        public UndirectedGraph()
        {
            _vertices = new();
            _edges = new();
        }

        public bool AddVertex(IVertex<TValue> vertex)
        {
            _vertices.Add(vertex);
            return _vertices.Contains(vertex);
        }

        public bool RemoveVertex(IVertex<TValue> vertex)
        {
            CutEdges(vertex);
            return _vertices.Remove(_vertices.Find(v => v.Name == vertex.Name && v.Content.Equals(vertex.Content)));
        }

        public bool RemoveVertex(string name)
        {
            CutEdges(_vertices.Find(v => v.Name == name));
            return _vertices.Remove(_vertices.Find(v => v.Name == name));
        }

        public bool RemoveVertex(TValue content)
        {
            CutEdges(_vertices.Find(v => v.Content.Equals(content)));
            return _vertices.Remove(_vertices.Find(v => v.Content.Equals(content)));
        }

        public bool AddEdge(IVertex<TValue> source, IVertex<TValue> destination)
        {
            var edge = new Edge<TValue>(source, destination);
            _edges.Add(edge);
            return _edges.Contains(edge);
        }

        public bool AddEdge(string sourceName, string destinationName)
        {
            var source = _vertices.Find(v => v.Name == sourceName);
            var destination = _vertices.Find(v => v.Name == destinationName);

            if (source == null)
                throw new ArgumentNullException($"{nameof(source)}");

            if (destination == null)
                throw new ArgumentNullException($"{nameof(destination)}");

            var edge = new Edge<TValue>(source, destination);
            _edges.Add(edge);
            return _edges.Contains(edge);
        }

        public bool RemoveEdge(IVertex<TValue> source, IVertex<TValue> destination) => _edges.Remove(_edges.Find(e => e.Source.Name == source.Name && e.Source.Content.Equals(source.Content) && e.Destination.Name == destination.Name && e.Destination.Content.Equals(destination.Content)));

        public bool RemoveEdge(TValue sourceContent, TValue destinationContent) => _edges.Remove(_edges.Find(e => e.Source.Content.Equals(sourceContent) && e.Destination.Content.Equals(destinationContent)));

        public bool RemoveEdge(string sourceName, string destinationName) => _edges.Remove(_edges.Find(e => e.Source.Name == sourceName && e.Destination.Name == destinationName));

        public bool CutEdges(IVertex<TValue> source)
        {
            foreach (IEdge<TValue> edge in _edges)
                if (edge.Source.Name == source.Name || edge.Destination.Name == source.Name)
                    return _edges.Remove(edge);
            return false;
        }

        public string PrintGraph()
        {
            StringBuilder builder = new();

            builder.AppendLine("Edges are double due to undirected graph\n");

            builder.AppendLine("Edges:");
            foreach (IEdge<TValue> edge in _edges)
            {
                builder.AppendLine($"{edge.Source.Name}--{edge.Destination.Name}");
                builder.AppendLine($"{edge.Destination.Name}--{edge.Source.Name}");
            }

            builder.AppendLine("Vertices:");
            foreach (IVertex<TValue> vertex in _vertices)
                builder.AppendLine($"{vertex.Name} - {vertex.Content.ToString()}");

            return builder.ToString();

        }

        public void AcceptVisitor(IUndirectedGraphVisitor visitor) => visitor.Visit(this);

        public bool CheckCycles()
        {
            VisitResult<TValue> result = new(this, VisitType.DepthFirstSearch);
            foreach (IVertex<TValue> vertex in _vertices)
                if (result.Color(vertex) == VertexColor.White && CheckCyclesRic(vertex, result))
                    return true;
            return false;

        }

        private bool CheckCyclesRic(IVertex<TValue> vertex, VisitResult<TValue> visit)
        {
            if (vertex == null)
                return false;

            List<IVertex<TValue>> parents = new();

            visit.Color(vertex, VertexColor.Gray);
            

            foreach (var adjacent in AdjacentsTo(vertex))
            {
                if (visit[adjacent].Color == VertexColor.White)
                {
                    parents.Add(adjacent);
                    if (CheckCyclesRic(adjacent, visit))
                        return true;
                }
                else if (vertex.Name != (parents.Count > 0 ? parents.Last().Name : vertex.Name))
                    return true;
                visit.Color(adjacent, VertexColor.Black);
            }
            return false;
        }

        public IEnumerable<IVertex<TValue>> AdjacentsTo(IVertex<TValue> vertex)
        {
            if (vertex is null)
                throw new ArgumentNullException(nameof(vertex), $"Cannot run method {nameof(AdjacentsTo)} with argument null.");

            List<IVertex<TValue>> vertices = new();
            foreach (IEdge<TValue> edge in _edges)
            {
                if (edge.Source!.Name == vertex.Name)
                    vertices.Add(edge.Destination!);
                if (edge.Destination!.Name == vertex.Name)
                    vertices.Add(edge.Source);
            }
            return vertices;
        }
    }
}
