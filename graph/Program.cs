using System;
using System.IO;
using System.Linq;
using graph.DataStructure;

namespace graph {
    class Program {
        static void Main(string[] args) {
            string path = "../../Resources/input";
            byte[,] matrix = ReadValueAndMatrixByte(path);

            var adjacencyMatrix = new AdjacencyMatrixSimpleUnweighted(matrix);
            var graph = new GraphUnweighted<int>(adjacencyMatrix);

            Console.WriteLine(graph);
            Console.WriteLine();

            graph.RemoveNode(1);

            Console.WriteLine(graph);
            Console.WriteLine();

            graph.HamiltonCycle();
        }

        private static int ReadValueInt(string path) {
            int value;
            using (var sr = new StreamReader(path)) {
                value = int.Parse(sr.ReadLine());
            }
            return value;
        }

        private static int[,] ReadValueAndMatrixInt(string path) {
            int[,] matrix;
            using (var sr = new StreamReader(path)) {
                var value = int.Parse(sr.ReadLine());
                matrix = new int[value, value];
                int i = 0;
                while (!sr.EndOfStream) {
                    var readLine = sr.ReadLine();
                    if (readLine != null) {
                        var inputList = readLine
                            .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                        for (int j = 0; j < inputList.Length; j++)
                        {
                            matrix[i, j] = inputList[j];
                        }
                    }
                    i++;
                }
            }
            return matrix;
        }

        private static byte[,] ReadValueAndMatrixByte(string path) {
            byte[,] matrix;
            using (var sr = new StreamReader(path)) {
                var value = int.Parse(sr.ReadLine());
                matrix = new byte[value, value];
                int i = 0;
                while (!sr.EndOfStream) {
                    var readLine = sr.ReadLine();
                    if (readLine != null) {
                        var inputList = readLine
                            .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(byte.Parse)
                            .ToArray();
                        for (int j = 0; j < inputList.Length; j++) {
                            matrix[i, j] = inputList[j];
                        }
                    }
                    i++;
                }
            }
            return matrix;
        }

        private static int[][] ReadMatrixInt(string path, int n) {
            return ReadMatrixInt(new StreamReader(path), n);
        }

        private static int[][] ReadMatrixInt(StreamReader stream, int n) {
            int[][] matrix = new int[n][];
            using (var sr = stream) {
                int i = 0;
                while (!sr.EndOfStream) {
                    var readLine = sr.ReadLine();
                    if (readLine != null) {
                        var inputList = readLine
                            .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => int.Parse(s))
                            .ToArray();
                        matrix[i] = inputList;
                    }
                    i++;
                }
            }
            return matrix;
        }
    }
}
