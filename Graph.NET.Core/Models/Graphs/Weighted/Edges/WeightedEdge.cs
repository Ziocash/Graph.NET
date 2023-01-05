using Graph.NET.Core.Models.Graphs.Unweighted.Edges;
using Graph.NET.Core.Models.Graphs.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Graphs.Weighted.Edges
{
    public class WeightedEdge<TValue> : Edge<TValue>
    {
        public double Weight { get; private set; } = 1.0;

        public WeightedEdge(IVertex<TValue> source, IVertex<TValue> destination) : base(source, destination)
        { }

        public WeightedEdge(IVertex<TValue> source, IVertex<TValue> destination, double weight) : base(source, destination)
        {
            Weight = weight;
        }
    }
}
