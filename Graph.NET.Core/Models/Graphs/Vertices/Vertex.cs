using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Graphs.Vertices
{
    public class Vertex<TValue> : IVertex<TValue>
    {
        public Vertex()
        { }

        public Vertex(string name, TValue content)
        {
            Name = name;
            Content = content;
        }

        public string? Name { get; set; }
        public TValue? Content { get; set; }
        public int VisitStartTime { get; set; }
        public int VisitEndTime { get; set; }
    }
}
