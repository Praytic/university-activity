using System;
using graph.DataStructure;

namespace graph {
    class Program {
        static void Main(string[] args)
        {
            Example4();
        }

        public static void Example1()
        {
            string path = "../../Resources/input";
            byte[,] matrix = LazyReaderLibrary.ReadOneSizeAndMatrix<byte>(path);

            var adjacencyMatrix = new AdjacencyMatrixSimpleUnweighted(matrix);
            var graph = new Graph<int, byte>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var resultPath = graph.GetHamiltonianCycle();
            if (resultPath.Count == 0) {
                Console.WriteLine("No hamiltonian cycle was found.");
            } else {
                Console.WriteLine("Hamiltionian cycle was found.");
            }
            foreach (var i in resultPath) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void Example2() {
            string path = "../../Resources/input2";
            byte[,] matrix = LazyReaderLibrary.ReadOneSizeAndMatrix<byte>(path);

            var adjacencyMatrix = new AdjacencyMatrixSimpleUnweighted(matrix);
            var graph = new Graph<int, byte>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var resultPath = graph.GetHamiltonianCycle();
            if (resultPath.Count == 0) {
                Console.WriteLine("No hamiltonian cycle was found.");
            } else {
                Console.WriteLine("Hamiltionian cycle was found.");
            }
            foreach (var i in resultPath) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void Example3() {
            char[] schema = { 'A', 'B', 'C', 'D', 'E' };
            char[,] matrix =
            {
                {'a', 'b', '\0', '\0', 'a' },
                {'\0', 'b', 'c', '\0', 'b' },
                {'a', '\0', 'c', '\0', '\0' },
                {'\0', 'b', '\0', 'b', '\0' },
                {'b', 'c', 'c', 'd', 'a' },
            };

            var adjacencyMatrix = new AdjacencyMatrix<char, char>(schema, matrix);
            var graph = new Graph<char, char>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var resultPath = graph.GetHamiltonianCycle('D');
            if (resultPath.Count == 0) {
                Console.WriteLine("No hamiltonian cycle was found.");
            } else {
                Console.WriteLine("Hamiltionian cycle was found.");
            }
            foreach (var i in resultPath) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


        public static void Example4() {
            int[] schema = { 0, 1, 2, 3, 4 };
            int[,] matrix =
            {
                {1, 2, 0, 0, 1 },
                {0, 1, 3, 0, 2 },
                {1, 0, 3, 0, 0 },
                {0, 2, 0, 2, 0 },
                {2, 3, 3, 4, 1 },
            };

            var adjacencyMatrix = new AdjacencyMatrix<int, int>(schema, matrix);
            var graph = new Graph<int, int>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            var resultPath = graph.GetHamiltonianCycle();
            if (resultPath.Count == 0) {
                Console.WriteLine("No hamiltonian cycle was found.");
            } else {
                Console.WriteLine("Hamiltionian cycle was found.");
            }
            foreach (var i in resultPath) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
