using Graph.NET.Core.Models.Graphs;
using Graph.NET.Core.Models.Graphs.Vertices;
using Graph.NET.Core.Models.Visits.Enums;

namespace Graph.NET.Core.Models.Visits
{
    /// <summary>
    /// Class representing a visit result, contains all info about performed visit
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class VisitResult<TValue>
    {

        private readonly Dictionary<IVertex<TValue>, VertexColor> _colors;
        private readonly Dictionary<IVertex<TValue>, int> _startTimes;
        private readonly Dictionary<IVertex<TValue>, int> _endTimes;
        public VisitType Visit { get; private set; }

        public VisitResult(IGraph<TValue> graph, VisitType visit)
        {
            _colors = new();
            _startTimes = new();
            _endTimes = new();
            Visit = visit;
            foreach (var vertex in graph.Vertices)
            {
                _colors.Add(vertex, VertexColor.White);
                _startTimes.Add(vertex, 0);
                _endTimes.Add(vertex, 0);
            }
        }

        public VertexColor Color(IVertex<TValue> vertex)  => _colors[vertex];

        public void Color(IVertex<TValue> vertex, VertexColor color) => _colors[vertex] = color;

        public int StartTime(IVertex<TValue> vertex) => _endTimes[vertex];

        public void StartTime(IVertex<TValue> vertex, int time) => _startTimes[vertex] = time;

        public int EndTime(IVertex<TValue> vertex) => _startTimes[vertex];

        public void EndTime(IVertex<TValue> vertex, int time) => _endTimes[vertex] = time;

        public (VertexColor Color, int StartTime, int EndTime) this[IVertex<TValue> vertex] => (_colors[vertex], _startTimes[vertex], _endTimes[vertex]);
    }
}
