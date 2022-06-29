using Graph.NET.Core.Visitors;

namespace Graph.NET.Core.Models
{
    public interface IUndirectedGraph<TValue>
    {
        public void ResetColors();

        IVertex<TValue>? Root { get; }

        IEnumerable<IVertex<TValue>> Vertices { get; }

        IEnumerable<IEdge<TValue>> Edges { get; }

        bool AddVertex(IVertex<TValue> vertex);

        bool RemoveVertex(IVertex<TValue> vertex);

        bool RemoveVertex(string name);

        bool RemoveVertex(TValue content);

        bool AddEdge(IVertex<TValue> source, IVertex<TValue> destination);

        bool AddEdge(string sourceName, string destinationName);

        bool RemoveEdge(TValue sourceContent, TValue destinationContent);

        bool RemoveEdge(string sourceName, string destinationName);

        bool RemoveEdge(IVertex<TValue> source, IVertex<TValue> destination);

        bool CutEdges(IVertex<TValue> source);

        string PrintGraph();

        void AcceptVisitor(IVisitor visitor);

        bool CheckCycles();

        IEnumerable<IVertex<TValue>> AdjacentsTo(IVertex<TValue> vertex);

        bool IsCyclic { get; }

        int MaxEdges { get; }
    }
}