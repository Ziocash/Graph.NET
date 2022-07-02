using Graph.NET.Core.Exceptions;
using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Directed
{
    public class DirectedGraph<TValue> : IDirectedGraph<TValue>
    {
        public IVertex<TValue>? Root => _vertices.FirstOrDefault();

        public IEnumerable<IVertex<TValue>> Vertices => _vertices;

        public IEnumerable<IEdge<TValue>> Edges => _edges;

        public bool IsCyclic => CheckCycles();

        public bool IsDAG => !IsCyclic;

        public int MaxEdges => _vertices.Count * (_vertices.Count - 1);

        private List<IVertex<TValue>> _vertices;

        private List<IEdge<TValue>> _edges;

        public DirectedGraph()
        {
            _vertices = new();
            _edges = new();
        }

        public void AcceptVisitor(IUndirectedGraphVisitor visitor)
        {
            throw new IllegalGraphOperationException("Currently in a directed graph. Cannot visit a directed graph with an undirected visitor.");
        }

        public void AcceptVisitor(IDirectedGraphVisitor visitor) => visitor.Visit(this);

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

        public bool AddVertex(IVertex<TValue> vertex)
        {
            if (!_vertices.Contains(vertex))
            {
                _vertices.Add(vertex);
                return _vertices.Contains(vertex);
            }
            return false;
        }

        public IEnumerable<IVertex<TValue>> AdjacentsTo(IVertex<TValue> vertex)
        {
            List<IVertex<TValue>> vertices = new();
            foreach (IEdge<TValue> edge in _edges)            
                if (edge.Source.Name == vertex.Name)
                    vertices.Add(edge.Destination);
            return vertices;
        }

        public bool CheckCycles()
        {
            ResetColors();
            foreach (IVertex<TValue> vertex in _vertices)
                if (vertex.Color == VertexColor.White && CheckCyclesRic(vertex))
                    return true;
            return false;

        }

        private bool CheckCyclesRic(IVertex<TValue> vertex)
        {
            List<IVertex<TValue>> parents = new();
            vertex.Color = VertexColor.Gray;

            foreach (var adjacent in AdjacentsTo(vertex))
            {
                if (adjacent.Color == VertexColor.White)
                {
                    parents.Add(adjacent);
                    if (CheckCyclesRic(adjacent))
                        return true;
                }
                else if (adjacent.Color == VertexColor.Gray)
                    return true;
            }
            vertex.Color = VertexColor.Black;
            return false;
        }

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

            builder.AppendLine("Edges are single due to directed graph\n");

            builder.AppendLine("Edges:");
            foreach (IEdge<TValue> edge in _edges)
                builder.AppendLine($"{edge.Source.Name} --> {edge.Destination.Name}");
            
            builder.AppendLine("Vertices:");
            foreach (IVertex<TValue> vertex in _vertices)
                builder.AppendLine($"{vertex.Name} - {vertex.Content.ToString()}");

            return builder.ToString();
        }

        public bool RemoveEdge(IVertex<TValue> source, IVertex<TValue> destination) => _edges.Remove(_edges.Find(e => e.Source.Name == source.Name && e.Source.Content.Equals(source.Content) && e.Destination.Name == destination.Name && e.Destination.Content.Equals(destination.Content)));

        public bool RemoveEdge(TValue sourceContent, TValue destinationContent) => _edges.Remove(_edges.Find(e => e.Source.Content.Equals(sourceContent) && e.Destination.Content.Equals(destinationContent)));

        public bool RemoveEdge(string sourceName, string destinationName) => _edges.Remove(_edges.Find(e => e.Source.Name == sourceName && e.Destination.Name == destinationName));

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

        public void ResetColors()
        {
            foreach (var vertex in _vertices)
                vertex.Color = VertexColor.White;
        }
    }
}
