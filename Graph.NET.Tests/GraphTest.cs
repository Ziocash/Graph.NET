using Graph.NET.Core.Models;

namespace Graph.NET.Tests
{
    public class Tests
    {
        private IGraph graph;
        [SetUp]
        public void Setup()
        {
           graph = new Core.Models.Graph();           
        }

        [Test]
        public void TestInit()
        {
            Assert.NotNull(graph);
            Assert.That(graph.Vertices.Count(), Is.EqualTo(0));
            Assert.That(graph.Root, Is.Null);
        }
    }
}