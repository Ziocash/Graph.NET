using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Graphs.Vertices
{
    public interface IVertex<TValue>
    {
        string? Name { get; set; }

        TValue? Content { get; set; }

    }
}
