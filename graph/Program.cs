using System;
using graph.DataStructure;
using graph.DataStructure.Implementation;

namespace graph {
    class Program {
        static void Main(string[] args)
        {
            Example1();
        }

        public static void Example1() {
            var graph = new GraphAdjacencyList<string, int>
            {
                "Березовка",
                "Сосновка",
                "Еремеевка",
                "Октябрьское",
                "Рузаевка"
            };
            new AdjacencyList<string, int>()
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
            Console.WriteLine("Count of paths from {0} to {1} equals {2}", first, second, graph.GetShortestPathDijkstra(first, second).Count);
        }
    }
}
