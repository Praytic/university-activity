using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using graph.Storages.Implementation;

namespace graph
{
    public static class LazyReaderLibrary {

        public static int ReadValue(string path)
        {
            return ReadValue<int>(path);
        }

        public static int ReadValue(StreamReader reader) {
            return ReadValue<int>(reader);
        }

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

        public static int[] ReadArray(string path)
        {
            return ReadArray<int>(path);
        }

        public static int[] ReadArray(string path, int n) {
            return ReadArray<int>(path, n);
        }

        public static int[] ReadArray(StreamReader reader) {
            return ReadArray<int>(reader);
        }

        public static int[] ReadArray(StreamReader reader, int n) {
            return ReadArray<int>(reader, n);
        }

        public static T[] ReadArray<T>(string path) {
            using (var sr = new StreamReader(path))
            {
                return ReadArray<T>(sr);
            }
        }

        public static T[] ReadArray<T>(string path, int n) {
            using (var sr = new StreamReader(path)) {
                return ReadArray<T>(sr, n);
            }
        }

        public static T[] ReadArray<T>(StreamReader reader) {
            var size = ReadValue(reader);
            return ReadArray<T>(reader, size);
        }

        public static T[] ReadArray<T>(StreamReader reader, int n)
        {
            var readLine = reader.ReadLine();
            if (readLine == null) return null;
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return readLine
                .Split(" \t".ToCharArray())
                .Select(s => (T)converter.ConvertFrom(s))
                .Take(n)
                .ToArray();
        }

        public static Matrix<int, int> ReadMatrix(string path) {
            return ReadMatrix<int>(path);
        }

        public static Matrix<int, int> ReadMatrix(string path, int n)
        {
            return ReadMatrix<int>(path, n);
        }

        public static Matrix<int, int> ReadMatrix(string path, int[] scheme, int n) {
            return ReadMatrix<int>(path, scheme, n);
        }

        public static Matrix<int, int> ReadMatrix(StreamReader reader)
        {
            var size = ReadValue(reader);
            return ReadMatrix<int>(reader, size);
        }

        public static Matrix<int, int> ReadMatrix(StreamReader reader, int n)
        {
            return ReadMatrix<int>(reader, n);
        }

        public static Matrix<int, int> ReadMatrix(StreamReader reader, int[] scheme, int n) {
            return ReadMatrix<int>(reader, scheme, n);
        }

        public static Matrix<T, int> ReadMatrix<T>(string path)
        {
            return ReadMatrix<T, int>(path);
        }

        public static Matrix<T, int> ReadMatrix<T>(string path, int n)
        {
            return ReadMatrix<T, int>(path, n);
        }

        public static Matrix<T, int> ReadMatrix<T>(string path, T[] scheme, int n) {
            return ReadMatrix<T, int>(path, scheme, n);
        }

        public static Matrix<T, int> ReadMatrix<T>(StreamReader reader)
        {
            return ReadMatrix<T, int>(reader);
        }

        public static Matrix<T, int> ReadMatrix<T>(StreamReader reader, int n)
        {
            return ReadMatrix<T, int>(reader, n);
        }

        public static Matrix<T, int> ReadMatrix<T>(StreamReader reader, T[] scheme, int n) {
            return ReadMatrix<T, int>(reader, scheme, n);
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(string path) where TW : IComparable
        {
            using (var sr = new StreamReader(path)) {
                return ReadMatrix<T, TW>(sr);
            }
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(string path, int n) where TW : IComparable
        {
            using (var sr = new StreamReader(path)) {
                return ReadMatrix<T, TW>(sr, n);
            }
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(string path, T[] scheme, int n) where TW : IComparable {
            using (var sr = new StreamReader(path)) {
                return ReadMatrix<T, TW>(sr, scheme, n);
            }
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(StreamReader reader) where TW : IComparable
        {
            var size = ReadValue(reader);
            return ReadMatrix<T, TW>(reader, size);
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(StreamReader reader, int n) where TW : IComparable
        {
            var scheme = ReadArray<T>(reader, n);
            return ReadMatrix<T, TW>(reader, scheme, n);
        }

        public static Matrix<T, TW> ReadMatrix<T, TW>(StreamReader reader, T[] scheme, int n) where TW : IComparable
        {
            var matrix = new TW[n, n];
            for (int i = 0; i < n; i++) {
                var readLine = reader.ReadLine();
                if (readLine != null) {
                    var converter = TypeDescriptor.GetConverter(typeof(TW));
                    var inputList = readLine
                        .Split(" \t".ToCharArray())
                        .Select(s => (TW)converter.ConvertFrom(s))
                        .ToArray();
                    for (int j = 0; j < n; j++) {
                        matrix[i, j] = inputList[j];
                    }
                }
            }
            return new Matrix<T, TW>(scheme, matrix);
        }
    }
}