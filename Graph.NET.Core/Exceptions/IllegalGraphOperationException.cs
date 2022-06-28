using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.NET.Core.Exceptions
{
    public class IllegalGraphOperationException : Exception
    {
        public IllegalGraphOperationException(string message) : base(message)
        { }

        public IllegalGraphOperationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
