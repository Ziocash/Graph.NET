using Graph.NET.Core.Models;
using Graph.NET.Core.Models.Directed;
using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Models.Undirected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public class DirectedDFSVisitor : IDirectedGraphVisitor
    {
        public string? Visited { get; private set; }

        private StringBuilder _stringBuilder = new();

        public void Visit<TValue>(IDirectedGraph<TValue> graph)
        {
            foreach(var vertex in graph.Vertices)
                DFSVisit(graph, vertex);
        }

        private void DFSVisit<TValue>(IDirectedGraph<TValue> graph, IVertex<TValue> vertex)
        {
            List<IVertex<TValue>> parents = new();
            vertex.Color = VertexColor.Gray;
            _stringBuilder.AppendLine($"Visiting node {vertex.Name}");
            foreach (var adj in graph.AdjacentsTo(vertex))
                if (adj.Color == VertexColor.White)
                {
                    parents.Add(vertex);
                    DFSVisit(graph, adj);
                }
            vertex.Color = VertexColor.Black;
            Visited = _stringBuilder.ToString();
        }

        public void Visit<TValue>(IUndirectedGraph<TValue> graph)
        {
            throw new NotImplementedException();
        }
    }
}
