using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models
{
    public class Edge<TValue> : IEdge<TValue>
    {
        public Edge()
        { }

        public Edge(IVertex<TValue> source, IVertex<TValue> destination)
        {
            Source = source;
            Destination = destination;
        }

        public IVertex<TValue>? Source { get; set; }

        public IVertex<TValue>? Destination { get; set; }
    }
}
