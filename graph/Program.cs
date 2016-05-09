using System;
using graph.Algorithms;
using graph.Algorithms.Implementation;
using graph.Storages;
using graph.Storages.Implementation;

namespace graph {

    class Program
    {
        static void Main(string[] args) {
            Program program = new Program();
            program.Example4();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency Matrix Graph
        public void Example1() {
            var graph = new GraphAdjacencyMatrix<string>(new []
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
            var shortestPath = new DijkstraShortestPathAdjacencyMatrix<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency Matrix Graph
        public void Example2() {
            var graph = new GraphAdjacencyMatrix<string>(new []
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
            var shortestPath = new FloydShortestPathAdjacencyMatrix<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Dijkstra Find All Paths Algorithm with Adjacency Matrix Graph
        public void Example7() {
            var path = "../../Resources/adjacencyMatrixIntInt";
            var matrix = LazyReaderLibrary.ReadMatrix(path);
            var adjacencyMatrix = new AdjacencyMatrix(matrix);
            var graph = new GraphAdjacencyMatrix(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var first = 4;
            var second = 3;
            var shortestPath = new DijkstraAllPathsAdjacencyMatrix<int>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result.Count));
        }

        //Example of Finding Hamiltonian Cycle in the Specified Vertex with Adjacency Matrix
        public void Example3() {
            var path = "../../Resources/adjacencyMatrixStringInt";
            var matrix = LazyReaderLibrary.ReadMatrix<string>(path);
            var graph = new GraphAdjacencyMatrix<string>(matrix);
            
            Console.WriteLine(graph);
            Console.WriteLine();

            var first = "Рузаевка";
            var cycle = new HamiltonianCycleAdjacencyMatrix<string, int>(graph, first);
            cycle.Run();
            Console.WriteLine("Hamiltonian cycle is:\n" + string.Join(", ", cycle.Result));
        }

        //Example of Removing & Adding New Vertex with Adjacency Matrix
        public void Example4() {
            var path = "../../Resources/adjacencyMatrixStringInt";
            var matrix = LazyReaderLibrary.ReadMatrix<string>(path);
            var graph = new GraphAdjacencyMatrix<string>(matrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            graph.Add("Буряковка");
            graph.Remove("Еремеевка");

            Console.WriteLine(graph);
            Console.WriteLine();
        }

        //Example of Dijkstra Shortest Path Algorithm with Adjacency List Graph
        public void Example5() {
            var graph = new GraphAdjacencyList<string>(new[]
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
            var shortestPath = new DijkstraShortestPathAdjacencyList<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        //Example of Floyd Shortest Path Algorithm with Adjacency List Graph
        public void Example6() {
            var adjacencyList = new AdjacencyList<string>(new[]
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
            var graph = new GraphAdjacencyList<string>(adjacencyList);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            var shortestPath = new FloydShortestPathAdjacencyList<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Path from {0} to {1} equals\n{2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

    }
}
