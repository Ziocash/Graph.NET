using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.NET.Core.Models.Graphs.Vertices;

namespace Graph.NET.Core.Models.Graphs.Unweighted.Edges
{
    public interface IEdge<TValue>
    {
        IVertex<TValue>? Source { get; set; }

        IVertex<TValue>? Destination { get; set; }

    }
}
