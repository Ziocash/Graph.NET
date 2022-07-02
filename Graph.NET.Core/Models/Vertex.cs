using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models
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
        public VertexColor Color { get; set; } = VertexColor.White;
        public int VisitStartTime { get; set; }
        public int VisitEndTime { get; set; }
    }
}
