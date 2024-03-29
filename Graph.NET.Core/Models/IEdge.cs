﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Models
{
    public interface IEdge<TValue>
    {
        IVertex<TValue>? Source { get; set; }

        IVertex<TValue>? Destination { get; set; }

    }
}
