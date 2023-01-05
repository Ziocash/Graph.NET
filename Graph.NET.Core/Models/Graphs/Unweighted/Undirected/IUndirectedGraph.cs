using Graph.NET.Core.Visitors;

namespace Graph.NET.Core.Models.Graphs.Unweighted.Undirected
{
    public interface IUndirectedGraph<TValue> : IGraph<TValue>
    {
        void AcceptVisitor(IUndirectedGraphVisitor visitor);
    }
}