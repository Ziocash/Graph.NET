using Graph.NET.Core.Models.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public interface IDirectedGraphVisitor : IUndirectedGraphVisitor
    {
        public void Visit<TValue>(IDirectedGraph<TValue> graph);
    }
}
