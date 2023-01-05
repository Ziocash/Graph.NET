using Graph.NET.Core.Models.Graphs.Unweighted.Edges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Graphs.Weighted.Edges
{
    public interface IWeightedEdge<TValue> : IEdge<TValue>
    {
        public double Weight { get; set; }
    }
}
