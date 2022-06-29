using Graph.NET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public interface IVisitor
    {

        public void Visit<TValue>(IUndirectedGraph<TValue> graph);

    }
}
