﻿using Graph.NET.Core.Models;
using Graph.NET.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Visitors
{
    public class BFSVisitor : IVisitor
    {
        public string? Visited { get; private set; }

        public void Visit<TValue>(IUndirectedGraph<TValue> graph)
        {
            graph.ResetColors();
            List<IVertex<TValue>> parents = new();
            Queue<IVertex<TValue>> queue = new();
            StringBuilder stringBuilder = new();
            graph.Root.Color = VertexColor.Gray;
            queue.Enqueue(graph.Root);
            while(queue.Count > 0)
            {
                var head = queue.ElementAt(0);
                stringBuilder.AppendLine($"Visiting node {head.Name}");
                foreach (var adj in graph.AdjacentsTo(head))
                {
                    if (adj.Color == VertexColor.White)
                    {   
                        adj.Color = VertexColor.Gray;
                        if(!parents.Contains(head))
                            parents.Add(head);
                        queue.Enqueue(adj);
                        stringBuilder.AppendLine($"Visited node {head.Name}, has adjacent vertex {adj.Name}.");
                    }
                }
                var vertex = queue.Dequeue();
                vertex.Color = VertexColor.Black;
                stringBuilder.AppendLine($"Visited node {vertex.Name}, no unvisited vertices near.");
            }

            Visited = stringBuilder.ToString();
        }
    }
}
