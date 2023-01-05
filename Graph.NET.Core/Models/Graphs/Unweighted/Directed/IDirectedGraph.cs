using Graph.NET.Core.Models.Graphs.Unweighted.Undirected;
using Graph.NET.Core.Visitors;

namespace Graph.NET.Core.Models.Graphs.Unweighted.Directed
{
    public interface IDirectedGraph<TValue> : IUndirectedGraph<TValue>
    {
        bool IsDAG { get; }

        public void AcceptVisitor(IDirectedGraphVisitor graph);
    }
}
