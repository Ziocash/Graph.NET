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

        public void Visit<TValue>(IUndirectedGraph<TValue> graph)
        {
            Stack<IVertex<TValue>> stack = new();
            List<IVertex<TValue>> parents = new();
            StringBuilder stringBuilder = new();
            graph.Root.Color = VertexColor.Gray;
            stack.Push(graph.Root);
            while (stack.Count > 0)
            {
                stringBuilder.AppendLine($"Visiting node {stack.Peek().Name}");
                foreach (var edge in graph.Edges)
                {
                    if ((edge.Source.Name == stack.Peek().Name || edge.Destination.Name == stack.Peek().Name) && edge.Destination.Color == VertexColor.White)
                    {
                        edge.Destination.Color = VertexColor.Gray;
                        if (!parents.Contains(stack.Peek()))
                            parents.Add(stack.Peek());
                        stack.Push(edge.Destination);
                        stringBuilder.AppendLine($"Has adjacent vertex {edge.Destination.Name}.");
                    }
                }
                var vertex = stack.Pop();
                vertex.Color = VertexColor.Black;
                stringBuilder.AppendLine($"No unvisited vertices near.");
            }
            Visited = stringBuilder.ToString();
        }
    }
}
