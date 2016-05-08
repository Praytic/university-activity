using System;
using graph.Algorithms;
using graph.Algorithms.Implementation;
using graph.DataStructure;
using graph.DataStructure.Implementation;

namespace graph {
    public static class Factory
    {
        public static readonly DataStructureFactory Data = new DataStructureFactory();
        public static readonly AlgorithmsFactory Algorithms = new AlgorithmsFactory();
    }

    class Program
    {
        static void Main(string[] args) {
            Example2();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency Matrix Graph
        public static void Example1() {
            var graph = Factory.Data.CreateGraph(new []
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            });
            graph.AddUndirectedEdge("Березовка", "Еремеевка", 70);
            graph.AddUndirectedEdge("Березовка", "Сосновка", 20);
            graph.AddUndirectedEdge("Сосновка", "Октябрьское", 60);
            graph.AddUndirectedEdge("Сосновка", "Еремеевка", 15);
            graph.AddUndirectedEdge("Октябрьское", "Еремеевка", 75);
            graph.AddUndirectedEdge("Рузаевка", "Еремеевка", 25);
            graph.AddUndirectedEdge("Рузаевка", "Октябрьское", 40);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = Factory.Algorithms.CreateDijkstraShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency Matrix Graph
        public static void Example2() {
            var graph = Factory.Data.CreateGraph(new []
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            });
            graph.AddUndirectedEdge("Березовка", "Еремеевка", 70);
            graph.AddUndirectedEdge("Березовка", "Сосновка", 20);
            graph.AddUndirectedEdge("Сосновка", "Октябрьское", 60);
            graph.AddUndirectedEdge("Сосновка", "Еремеевка", 15);
            graph.AddUndirectedEdge("Октябрьское", "Еремеевка", 75);
            graph.AddUndirectedEdge("Рузаевка", "Еремеевка", 25);
            graph.AddUndirectedEdge("Рузаевка", "Октябрьское", 40);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = Factory.Algorithms.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Finding Hamiltonian Cycle in the Specified Vertex with Adjacency Matrix
        public static void Example3()
        {
            var path = "../../Resources/adjacencyMatrixStringInt";
            var storage = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var graph = Factory.Data.CreateGraph(storage);
            
            Console.WriteLine(graph);
            Console.WriteLine();

            var first = "Рузаевка";
            var second = "Березовка";
            var shortestPath = Factory.Algorithms.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals\n{2}",
                first, second, shortestPath.Result);
        }

        //Example of Removing & Adding New Vertex with Adjacency Matrix
        public static void Example4() {
            var path = "../../Resources/adjacencyMatrixStringInt";
            var storage = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var graph = Factory.Data.CreateGraph(storage);

            Console.WriteLine(graph);
            Console.WriteLine();

            graph.Add("Буряковка");
            graph.Remove("Еремеевка");

            Console.WriteLine(graph);
            Console.WriteLine();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency List Graph
        public static void Example5() {
            var graph = Factory.Data.CreateGraphAdjacencyList(new[]
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            });
            graph.AddUndirectedEdge("Березовка", "Еремеевка", 70);
            graph.AddUndirectedEdge("Березовка", "Сосновка", 20);
            graph.AddUndirectedEdge("Сосновка", "Октябрьское", 60);
            graph.AddUndirectedEdge("Сосновка", "Еремеевка", 15);
            graph.AddUndirectedEdge("Октябрьское", "Еремеевка", 75);
            graph.AddUndirectedEdge("Рузаевка", "Еремеевка", 25);
            graph.AddUndirectedEdge("Рузаевка", "Октябрьское", 40);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = Factory.Algorithms.CreateDijkstraShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency List Graph
        public static void Example6()
        {
            var adjacencyList = Factory.Data.CreateAdjacencyList(new[]
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            });
            adjacencyList.AddUndirectedEdge("Березовка", "Еремеевка", 70);
            adjacencyList.AddUndirectedEdge("Березовка", "Сосновка", 20);
            adjacencyList.AddUndirectedEdge("Сосновка", "Октябрьское", 60);
            adjacencyList.AddUndirectedEdge("Сосновка", "Еремеевка", 15);
            adjacencyList.AddUndirectedEdge("Октябрьское", "Еремеевка", 75);
            adjacencyList.AddUndirectedEdge("Рузаевка", "Еремеевка", 25);
            adjacencyList.AddUndirectedEdge("Рузаевка", "Октябрьское", 40);
            var graph = Factory.Data.CreateGraph(adjacencyList);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = Factory.Algorithms.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

    }
}
