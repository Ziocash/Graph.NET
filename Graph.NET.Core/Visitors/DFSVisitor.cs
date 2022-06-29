using Graph.NET.Core.Models;
using Graph.NET.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public class DFSVisitor : IVisitor
    {
        public string? Visited { get; private set; }

        private StringBuilder _stringBuilder = new();

        public void Visit<TValue>(IUndirectedGraph<TValue> graph)
        {
            DFSVisit(graph, graph.Root);
        }

        private void DFSVisit<TValue>(IUndirectedGraph<TValue> graph, IVertex<TValue> vertex)
        {
            List<IVertex<TValue>> parents = new();
            vertex.Color = VertexColor.Gray;
            _stringBuilder.AppendLine($"Visiting node {vertex.Name}");
            foreach (var adj in graph.AdjacentsTo(vertex))
                if(adj.Color == VertexColor.White)
                {
                    parents.Add(vertex);
                    DFSVisit(graph, adj);
                }
            vertex.Color = VertexColor.Black;
            Visited = _stringBuilder.ToString();
        }
    }
}
