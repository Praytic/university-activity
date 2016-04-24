using System;
using graph.DataStructure;

namespace graph {
    class Program {
        static void Main(string[] args)
        {
            Example2();
        }

        public static void Example1() {
            string path = "../../Resources/input3";
            var adjacencyMatrix = LazyReaderLibrary.ReadAdjacencyMatrix<string, int>(path);
            var graph = new GraphSimple<string>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            string first = "Рузаевка";
            string second = "Березовка";
            Console.WriteLine("Count of paths from {0} to {1} equals {2}", first, second, graph.GetAllPaths(first, second).Count);
        }

        public static void Example2() {
            char[] schema = { 'A', 'B', 'C', 'D', 'E' };
            int[,] matrix =
            {
                {0, 1, 0, 0, 1 },
                {1, 0, 1, 0, 0 },
                {0, 1, 0, 1, 0 },
                {0, 0, 1, 0, 1 },
                {1, 0, 0, 1, 0 }
            };

            var adjacencyMatrix = new AdjacencyMatrix<char, int>(schema, matrix);
            var graph = new GraphSimple<char>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            char first = 'A';
            char second = 'C';
            Console.WriteLine("Count of paths from {0} to {1} equals {2}", first, second, graph.GetAllPaths(first, second).Count);
        }
    }
}
