using System;
using graph.Algorithms.Implementation;
using graph.DataStructure;
using graph.DataStructure.Implementation;

namespace graph {
    class Program {
        static void Main(string[] args) {
            Example2();
        }

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
            var shortestPath = new DijkstraAdjacencyMatrixAlgorithm<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals {2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

        public static void Example2() {
            var graph = new GraphAdjacencyListSimplified<string>()
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
            var shortestPath = new DijkstraAdjacencyListAlgorithm<string>(graph, first, second);
            shortestPath.Run();
            Console.WriteLine("Count of paths from {0} to {1} equals {2}",
                first, second, string.Join(", ", shortestPath.Result));
        }

    }
}
