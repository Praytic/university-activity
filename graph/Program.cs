using System;
using graph.DataStructure;

namespace graph {
    class Program {
        static void Main(string[] args)
        {
            Example1();
        }

        public static void Example1() {
            var graph = new GraphSimplified<string>();
            graph.Add("Березовка");
            graph.Add("Сосновка");
            graph.Add("Еремеевка");
            graph.Add("Октябрьское");
            graph.Add("Рузаевка");
            graph.AddUndirectedEdge("Березовка", "Еремеевка");
            graph.Add("Сосновка");
            graph.Add("Еремеевка");
            graph.Add("Октябрьское");
            graph.Add("Рузаевка");

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            Console.WriteLine("Count of paths from {0} to {1} equals {2}", first, second, graph.GetAllPaths(first, second).Count);
        }
    }
}
