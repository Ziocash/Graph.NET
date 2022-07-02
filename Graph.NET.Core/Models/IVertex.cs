using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models
{
    public interface IVertex<TValue>
    {
        string? Name { get; set; }

        TValue? Content { get; set; }

        VertexColor Color { get; set; }

        int VisitStartTime { get; set; }
        int VisitEndTime { get; set; }

    }
}
