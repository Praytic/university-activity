using System;
using System.IO;
using System.Linq;
using graph.DataStructure;

namespace graph {
    class Program {
        static void Main(string[] args) {
            string path = "../../Resources/input2";
            byte[,] matrix = LazyReaderLibrary.ReadOneSizeAndMatrix<byte>(path);

            var adjacencyMatrix = new AdjacencyMatrixSimpleUnweighted(matrix);
            var graph = new Graph<int, byte>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();
            
            var resultPath = graph.GetHamiltonianCycle();
            if (resultPath.Count == 0)
            {
                Console.WriteLine("No hamiltonian cycle was found.");
            }
            else
            {
                Console.WriteLine("Hamiltionian cycle was found.");
            }
            foreach (var i in resultPath)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
