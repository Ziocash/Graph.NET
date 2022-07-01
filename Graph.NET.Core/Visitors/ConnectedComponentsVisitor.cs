using Graph.NET.Core.Models;
using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Models.Undirected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public class ConnectedComponentsVisitor : IUndirectedGraphVisitor
    {
        public string? Visited { get; private set; }

        private StringBuilder _stringBuilder = new();

        public dynamic? ConnectedComponents { get; private set; }

        public void Visit<TValue>(IUndirectedGraph<TValue> graph)
        {
            List<IVertex<TValue>[]> result = new();
            foreach (var vertex in graph.Vertices)
                if (vertex.Color == VertexColor.White)
                    result.Add(BuildDFSTree(graph, vertex));
            ConnectedComponents = result.AsEnumerable();
        }

        private IVertex<TValue>[] BuildDFSTree<TValue>(IUndirectedGraph<TValue> graph, IVertex<TValue> vertex)
        {
            List<IVertex<TValue>> connectedComponents = new();
            DFSVisit(graph, graph.Root, connectedComponents);
            return connectedComponents.ToArray();
        }


        private void DFSVisit<TValue>(IUndirectedGraph<TValue> graph, IVertex<TValue> vertex, List<IVertex<TValue>> components)
        {
            vertex.Color = VertexColor.Gray;
            components.Add(vertex);
            _stringBuilder.AppendLine($"Visiting node {vertex.Name}");
            foreach (var adj in graph.AdjacentsTo(vertex))
                if (adj.Color == VertexColor.White)
                    DFSVisit(graph, adj, components);
            vertex.Color = VertexColor.Black;
            Visited = _stringBuilder.ToString();
        }
    }
}
