using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models.Visits.Enums
{
    /// <summary>
    /// Vertex color class, used in node visit
    /// </summary>
    public enum VertexColor
    {
        /// <summary>
        /// Undiscovered node
        /// </summary>
        White,
        /// <summary>
        /// Discovered node without all adjacents nodes discovered
        /// </summary>
        Gray,
        /// <summary>
        /// Discovered node with all adjacents nodes discovered
        /// </summary>
        Black
    }
}
