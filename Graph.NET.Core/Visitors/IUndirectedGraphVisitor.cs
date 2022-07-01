using Graph.NET.Core.Models.Undirected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public interface IUndirectedGraphVisitor
    {

        public void Visit<TValue>(IUndirectedGraph<TValue> graph);

    }
}
