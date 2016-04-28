using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using graph.DataStructure.Implementation;

namespace graph
{
    public static class LazyReaderLibrary
    {
        public static T ReadValue<T>(string path) {
            T value;
            using (var sr = new StreamReader(path))
            {
                value = ReadValue<T>(sr);
            }
            return value;
        }

        public static T ReadValue<T>(StreamReader reader) {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            var value = (T)converter.ConvertFrom(reader.ReadLine());
            return value;
        }

        public static T[] ReadArray<T>(string path)
        {
            T[] array = new T[0];
            using (var sr = new StreamReader(path)) {
                var readLine = sr.ReadLine();
                if (readLine != null) {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    var inputList = readLine
                        .Split(" \t".ToCharArray())
                        .Select(s => (T)converter.ConvertFrom(s))
                        .ToArray();
                    array = inputList;
                }
            }
            return array;
        }

        public static T[] ReadSizeAndArray<T>(string path) {
            T[] array;
            using (var sr = new StreamReader(path))
            {
                var size = ReadValue<int>(sr);
                array = ReadArray<T>(sr, size);
            }
            return array;
        }

        public static T[] ReadArray<T>(string path, int n) {
            T[] array;
            using (var sr = new StreamReader(path))
            {
                array = ReadArray<T>(sr, n);
            }
            return array;
        }

        public static T[] ReadArray<T>(StreamReader reader, int n)
        {
            T[] array = new T[n];
            var readLine = reader.ReadLine();
            if (readLine != null) {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                var inputList = readLine
                    .Split(" \t".ToCharArray())
                    .Select(s => (T)converter.ConvertFrom(s))
                    .Take(n)
                    .ToArray();
                array = inputList;
            }
            return array;
        }

        public static T[,] ReadOneSizeAndMatrix<T>(string path) {
            T[,] matrix;
            using (var sr = new StreamReader(path)) {
                var size = ReadValue<int>(sr);
                matrix = ReadMatrix<T>(sr, size, size);
            }
            return matrix;
        }

        public static T[,] ReadTwoSizeAndMatrix<T>(string path)
        {
            T[,] matrix;
            using (var sr = new StreamReader(path)) {
                var size = ReadArray<int>(sr, 2);
                matrix = ReadMatrix<T>(sr, size[0], size[1]);
            }
            return matrix;
        }

        public static T[,] ReadMatrix<T>(string path, int n)
        {
            return ReadMatrix<T>(path, n, n);
        }

        public static T[,] ReadMatrix<T>(string path, int n, int m) {
            T[,] matrix;
            using (var sr = new StreamReader(path))
            {
                matrix = ReadMatrix<T>(sr, n, m);
            }
            return matrix;
        }

        public static T[,] ReadMatrix<T>(StreamReader reader, int n, int m)
        {
            T[,] matrix = new T[n, m];
            for (int i = 0; i < n; i++) {
                var readLine = reader.ReadLine();
                if (readLine != null) {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    var inputList = readLine
                        .Split(" \t".ToCharArray())
                        .Select(s => (T)converter.ConvertFrom(s))
                        .ToArray();
                    for (int j = 0; j < m; j++) {
                        matrix[i, j] = inputList[j];
                    }
                }
            }
            return matrix;
        }

        public static AdjacencyMatrix<T, T1> ReadAdjacencyMatrix<T, T1>(string path) where T1 : IComparable {
            AdjacencyMatrix<T, T1> adjacencyMatrix;
            using (var sr = new StreamReader(path)) {
                var size = ReadValue<int>(sr);
                var schema = ReadArray<T>(sr, size);
                var matrix = ReadMatrix<T1>(sr, size, size);
                adjacencyMatrix = new AdjacencyMatrix<T, T1>(schema, matrix);
            }
            return adjacencyMatrix;
        }
    }
}