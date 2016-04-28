using System;
using graph.Algorithms;
using graph.Algorithms.Implementation;
using graph.DataStructure;
using graph.DataStructure.Implementation;

namespace graph {
    class Program
    {
        public static DataStructureFactory Data { get; } = new DataStructureFactory();
        public static AlgorithmsFactory Algorithms { get; } = new AlgorithmsFactory();

        static void Main(string[] args) {
            Example3();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency Matrix Graph
        public static void Example1() {
            var graph = new GraphAdjacencyMatrixSimplified<string>
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            };
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
            var shortestPath = new DijkstraShortestPathAdjacencyMatrix<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals {2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency List Graph
        public static void Example2() {
            var graph = new GraphAdjacencyListSimplified<string>
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            };
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
            var shortestPath = new DijkstraShortestPathAdjacencyList<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals {2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Finding Hamiltonian Cycle in the Specified Vertex with Adjacency Matrix
        public static void Example3()
        {
            var path = "../../Resources/adjacencyMatrixStringInt";
            var storage = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var matrix = Data.CreateAdjacencyMatrix(storage);
            var graph = new GraphAdjacencyMatrixSimplified<string>(storage);

            Console.WriteLine(matrix);
            Console.WriteLine();
            Console.WriteLine(graph);
            Console.WriteLine();

            var first = "Рузаевка";
            var second = "Березовка";
            var shortestPath = new FloydShortestPathAdjacencyMatrix<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals\n{2}",
                first, second, shortestPath.Result);

        }
    }
}
