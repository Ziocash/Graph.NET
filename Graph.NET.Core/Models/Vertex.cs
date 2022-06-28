﻿using System;
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

    }
}
