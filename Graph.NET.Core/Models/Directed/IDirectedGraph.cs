using Graph.NET.Core.Models.Undirected;
using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Directed
{
    public interface IDirectedGraph<TValue> : IUndirectedGraph<TValue>
    {
        bool IsDAG { get; }

        public void AcceptVisitor(IDirectedGraphVisitor graph);
    }
}
