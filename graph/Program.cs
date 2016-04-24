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
            var graph = new Graph<string, int>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();
            
            Console.WriteLine("Count of connected components: " + graph.GetConnectedComponentsCount());
        }

        public static void Example2() {
            char[] schema = { 'A', 'B', 'C', 'D', 'E' };
            char[,] matrix =
            {
                {'\0', 'a', '\0', '\0', '\0' },
                {'a', '\0', 'a', '\0', '\0' },
                {'\0', 'a', '\0', 'a', '\0' },
                {'\0', '\0', 'a', '\0', 'a' },
                {'\0', '\0', '\0', 'a', '\0' }
            };

            var adjacencyMatrix = new AdjacencyMatrix<char, char>(schema, matrix);
            var graph = new Graph<char, char>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            Console.WriteLine("Count of connected components: " + graph.GetConnectedComponentsCount());
        }


        public static void Example3() {
            string path = "../../Resources/input";
            var adjacencyMatrix = LazyReaderLibrary.ReadAdjacencyMatrix<int, byte>(path);
            var graph = new Graph<int, byte>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            Console.WriteLine("Count of connected components: " + graph.GetConnectedComponentsCount());
        }
    }
}
