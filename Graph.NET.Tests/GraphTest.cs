using Graph.NET.Core.Models;
using Graph.NET.Core.Models.Enums;
using Graph.NET.Core.Visitors;
using System.Diagnostics;

namespace Graph.NET.Tests
{
    public class Tests
    {
        private UndirectedGraph<DateTime> graph;
        [SetUp]
        public void Setup()
        {
           graph = new();
        }

        [Test]
        public void TestInit()
        {
            Assert.That(graph, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(graph.Vertices.Count(), Is.EqualTo(0));
                Assert.That(graph.Root, Is.Null);
            });
        }

        DateTime date1;
        DateTime date2;
        DateTime date3;

        [Test]
        public void TestAddOperation()
        {
            Vertex<DateTime> vertex = new("First vertex", DateTime.Now);
            Assert.Multiple(() =>
            {
                Assert.That(graph.AddVertex(vertex), Is.True);
                Assert.That(graph.Vertices.Count(), Is.EqualTo(1));
            });
            Assert.That(graph.Root.Name, Is.EqualTo("First vertex"));
            AddVertices();
            Assert.That(graph.Vertices.Count(), Is.EqualTo(4));
        }

        private void AddVertices()
        {
            Vertex<DateTime> vertex = new("Second vertex", date1 = DateTime.Now);
            graph.AddVertex(vertex);
            vertex = new("Third vertex", date2 = DateTime.Now);
            graph.AddVertex(vertex);
            vertex = new("Fourth vertex", date3 = DateTime.Now);
            graph.AddVertex(vertex);
        }

        [Test]
        public void TestRemoveByNameOperations()
        {
            AddVertices();
            Assert.That(graph.Vertices.Count, Is.EqualTo(3));
            Assert.IsTrue(graph.RemoveVertex("Second vertex"));
            Assert.IsTrue(graph.RemoveVertex("Third vertex"));
            Assert.IsTrue(graph.RemoveVertex("Fourth vertex"));
            Assert.That(graph.Vertices, Is.Empty);
        }

        [Test]
        public void TestRemoveByDateOperations()
        {
            AddVertices();
            Assert.That(graph.Vertices.Count, Is.EqualTo(3));
            Assert.IsTrue(graph.RemoveVertex(date1));
            Assert.IsTrue(graph.RemoveVertex(date2));
            Assert.IsTrue(graph.RemoveVertex(date3));
            Assert.That(graph.Vertices, Is.Empty);
        }

        [Test]
        public void TestRemoveByVertex()
        {
            AddVertices();
            IVertex<DateTime> removeMe = new Vertex<DateTime>("Third vertex", date2);
            Assert.IsTrue(graph.RemoveVertex(removeMe));
            Assert.IsFalse(graph.Vertices.Contains(removeMe));            
        }

        [Test]
        public void TestAddEdge()
        {
            Vertex<DateTime> vertex = new("First vertex", DateTime.Now);
            graph.AddVertex(vertex);
            AddVertices();
            Assert.IsTrue(graph.AddEdge(vertex.Name, "Third vertex"));
            Assert.That(graph.Edges.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestPrint()
        {
            Vertex<DateTime> vertex = new("First vertex", DateTime.Now);
            graph.AddVertex(vertex);
            AddVertices();
            Assert.IsTrue(graph.AddEdge("First vertex", "Third vertex"));
            Assert.That(graph.Edges.Count(), Is.EqualTo(1));
            Assert.That(graph.PrintGraph(), Is.Not.Null);
            Debug.WriteLine(graph.PrintGraph());
        }

        [Test]
        public void TestBFSVisitor()
        {
            for (int i = 0; i < 8; i++)
                graph.AddVertex(new Vertex<DateTime>() { Name = $"{(char)('A' + i)}", Content = DateTime.Now });
            Assert.That(graph.Vertices.Count(), Is.EqualTo(8));
            BFSVisitor visitor = new();
            Assert.IsTrue(graph.AddEdge("A", "B"));
            Assert.IsTrue(graph.AddEdge("A", "D"));
            Assert.IsTrue(graph.AddEdge("B", "C"));
            Assert.IsTrue(graph.AddEdge("B", "F"));
            Assert.IsTrue(graph.AddEdge("C", "E"));
            Assert.IsTrue(graph.AddEdge("D", "C"));
            Assert.IsTrue(graph.AddEdge("D", "H"));
            Assert.IsTrue(graph.AddEdge("E", "F"));
            Assert.IsTrue(graph.AddEdge("E", "H"));
            Assert.IsTrue(graph.AddEdge("F", "G"));
            Assert.IsTrue(graph.AddEdge("H", "G"));
            Assert.That(graph.Edges.Count(), Is.EqualTo(11));
            graph.AcceptVisitor(visitor);
            Assert.That(visitor.Visited, Is.Not.Null);
            Debug.WriteLine(graph.PrintGraph());
            Debug.WriteLine(visitor.Visited);
        }

        [Test]
        public void TestDFSVisitor()
        {
            for (int i = 0; i < 8; i++)
                graph.AddVertex(new Vertex<DateTime>() { Name = $"{(char)('A' + i)}", Content = DateTime.Now });
            Assert.That(graph.Vertices.Count(), Is.EqualTo(8));
            DFSVisitor visitor = new();
            Assert.IsTrue(graph.AddEdge("A", "B"));
            Assert.IsTrue(graph.AddEdge("B", "C"));
            Assert.IsTrue(graph.AddEdge("C", "D"));
            Assert.IsTrue(graph.AddEdge("D", "F"));      
            Assert.IsTrue(graph.AddEdge("F", "E"));            
            Assert.IsTrue(graph.AddEdge("H", "E"));
            Assert.IsTrue(graph.AddEdge("A", "G"));
            Assert.IsTrue(graph.AddEdge("G", "C"));
            Assert.IsTrue(graph.AddEdge("D", "H"));
            Assert.IsTrue(graph.AddEdge("B", "H"));
            Assert.IsTrue(graph.AddEdge("G", "F"));
            Assert.That(graph.Edges.Count(), Is.EqualTo(11));
            graph.AcceptVisitor(visitor);
            Assert.That(visitor.Visited, Is.Not.Null);
            foreach (var vertex in graph.Vertices)
                Assert.That(vertex.Color, Is.EqualTo(VertexColor.Black));
            Debug.WriteLine(graph.PrintGraph());
            Debug.WriteLine(visitor.Visited);
        }
    }
}