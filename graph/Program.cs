using System;
using graph.Algorithms;
using graph.DataStructure;

namespace graph {

    class Program
    {
        static void Main(string[] args) {
            Program program = new Program();
            program.Example7();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency Matrix Graph
        public void Example1() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var graph = storageFactory.CreateGraph(new []
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
            var shortestPath = algorithmsFactory.CreateDijkstraShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency Matrix Graph
        public void Example2() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var graph = storageFactory.CreateGraph(new []
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
            var shortestPath = algorithmsFactory.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Dijkstra Find All Paths Algorithm with Adjacency Matrix Graph
        public void Example7() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var path = "../../Resources/adjacencyMatrixIntInt";
            var adjacencyMatrix = LazyReaderLibrary.ReadAdjacencyMatrix<int, int>(path);
            var graph = storageFactory.CreateGraph(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var first = 4;
            var second = 3;
            var shortestPath = algorithmsFactory.CreateDijkstraAllPaths(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result.Count));
        }

        //Example of Finding Hamiltonian Cycle in the Specified Vertex with Adjacency Matrix
        public void Example3() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var path = "../../Resources/adjacencyMatrixStringInt";
            var storage = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var graph = storageFactory.CreateGraph(storage);
            
            Console.WriteLine(graph);
            Console.WriteLine();

            var first = "Рузаевка";
            var second = "Березовка";
            var shortestPath = algorithmsFactory.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals\n{2}",
                first, second, shortestPath.Result);
        }

        //Example of Removing & Adding New Vertex with Adjacency Matrix
        public void Example4() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var path = "../../Resources/adjacencyMatrixStringInt";
            var storage = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var graph = storageFactory.CreateGraph(storage);

            Console.WriteLine(graph);
            Console.WriteLine();

            graph.Add("Буряковка");
            graph.Remove("Еремеевка");

            Console.WriteLine(graph);
            Console.WriteLine();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency List Graph
        public void Example5() {
            StorageFactory.Graph storageFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var graph = storageFactory.CreateGraphAdjacencyList(new[]
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
            var shortestPath = algorithmsFactory.CreateDijkstraShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency List Graph
        public void Example6() {
            StorageFactory.AdjacencyList adjacencyListFactory = new StorageFactory.AdjacencyList();
            StorageFactory.Graph graphFactory = new StorageFactory.Graph();
            AlgorithmsFactory algorithmsFactory = new AlgorithmsFactory();
            var adjacencyList = adjacencyListFactory.CreateAdjacencyList(new[]
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
            var graph = graphFactory.CreateGraph(adjacencyList);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = algorithmsFactory.CreateFloydShortestPath(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

    }
}
