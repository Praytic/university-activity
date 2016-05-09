using System;
using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.DataStructure
{
    public abstract class StorageFactory
    {
        public class Graph {

            public GraphAdjacencyList<TVertex, int>
               CreateGraphAdjacencyList<TVertex>() {
                return new GraphAdjacencyList<TVertex, int>();
            }

            public GraphAdjacencyList<TVertex, TWeight>
                CreateGraphAdjacencyList<TVertex, TWeight>()
                where TWeight : IComparable {
                return new GraphAdjacencyList<TVertex, TWeight>();
            }

            public GraphAdjacencyMatrix<TVertex, int>
                CreateGraph<TVertex>(TVertex[] scheme) {
                return new GraphAdjacencyMatrix<TVertex, int>(scheme);
            }

            public GraphAdjacencyMatrix<TVertex, TWeight>
                CreateGraphAdjacencyMatrix<TVertex, TWeight>(TVertex[] scheme)
                where TWeight : IComparable {
                return new GraphAdjacencyMatrix<TVertex, TWeight>(scheme);
            }

            public GraphAdjacencyMatrix<TVertex, int>
                CreateGraph<TVertex>(Dictionary<TVertex, int> scheme) {
                return new GraphAdjacencyMatrix<TVertex, int>(scheme);
            }

            public GraphAdjacencyMatrix<TVertex, TWeight>
                CreateGraph<TVertex, TWeight>(Dictionary<TVertex, int> scheme)
                where TWeight : IComparable {
                return new GraphAdjacencyMatrix<TVertex, TWeight>(scheme);
            }

            public GraphAdjacencyMatrix<TVertex, int>
                CreateGraph<TVertex>(TVertex[] scheme, int[,] matrix) {
                return new GraphAdjacencyMatrix<TVertex, int>(scheme, matrix);
            }

            public GraphAdjacencyMatrix<TVertex, TWeight>
                CreateGraph<TVertex, TWeight>(TVertex[] scheme, TWeight[,] matrix)
                where TWeight : IComparable {
                return new GraphAdjacencyMatrix<TVertex, TWeight>(scheme, matrix);
            }

            public GraphAdjacencyMatrix<TVertex, int>
                CreateGraph<TVertex>(AdjacencyMatrix<TVertex, int> storage) {
                return new GraphAdjacencyMatrix<TVertex, int>(storage);
            }

            public GraphAdjacencyMatrix<TVertex, TWeight>
                CreateGraph<TVertex, TWeight>(AdjacencyMatrix<TVertex, TWeight> storage)
                where TWeight : IComparable {
                return new GraphAdjacencyMatrix<TVertex, TWeight>(storage);
            }

            public GraphAdjacencyMatrix<TVertex, int>
                CreateGraphAdjacencyMatrix<TVertex>() {
                return new GraphAdjacencyMatrix<TVertex, int>();
            }

            public GraphAdjacencyMatrix<TVertex, TWeight>
                CreateGraphAdjacencyMatrix<TVertex, TWeight>()
                where TWeight : IComparable {
                return new GraphAdjacencyMatrix<TVertex, TWeight>();
            }

            public GraphAdjacencyList<TVertex, int>
                CreateGraphAdjacencyList<TVertex>(TVertex[] vertices) {
                var storage = new Dictionary<TVertex, Dictionary<TVertex, int>>();
                foreach (var vertex in vertices) {
                    storage.Add(vertex, new Dictionary<TVertex, int>());
                }
                return new GraphAdjacencyList<TVertex, int>(storage);
            }

            public GraphAdjacencyList<TVertex, int>
                CreateGraph<TVertex>(Dictionary<TVertex, Dictionary<TVertex, int>> storage) {
                return new GraphAdjacencyList<TVertex, int>(storage);
            }

            public GraphAdjacencyList<TVertex, TWeight>
                CreateGraph<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
                where TWeight : IComparable {
                return new GraphAdjacencyList<TVertex, TWeight>(storage);
            }

            public GraphAdjacencyList<TVertex, int>
                CreateGraph<TVertex>(IAdjacencyList<TVertex, int> storage) {
                return new GraphAdjacencyList<TVertex, int>(storage);
            }

            public GraphAdjacencyList<TVertex, TWeight>
                CreateGraph<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
                where TWeight : IComparable {
                return new GraphAdjacencyList<TVertex, TWeight>(storage);
            }
        }

        public class AdjacencyMatrix {
            public AdjacencyMatrix<int, int>
               CreateAdjacencyMatrix(int count) {
                int[] scheme = new int[count];
                for (int i = 0; i < count; i++) {
                    scheme[i] = i;
                }
                return new AdjacencyMatrix<int, int>();
            }

            public AdjacencyMatrix<TVertex, int>
                CreateAdjacencyMatrix<TVertex>() {
                return new AdjacencyMatrix<TVertex, int>();
            }

            public AdjacencyMatrix<TVertex, int>
                CreateAdjacencyMatrix<TVertex>(TVertex[] scheme) {
                return new AdjacencyMatrix<TVertex, int>(scheme);
            }

            public AdjacencyMatrix<TVertex, int>
                CreateAdjacencyMatrix<TVertex>(Dictionary<TVertex, int> scheme) {
                return new AdjacencyMatrix<TVertex, int>(scheme);
            }

            public AdjacencyMatrix<TVertex, int>
                CreateAdjacencyMatrix<TVertex>(TVertex[] scheme, int[,] matrix) {
                return new AdjacencyMatrix<TVertex, int>(scheme, matrix);
            }

            public AdjacencyMatrix<TVertex, int>
                CreateAdjacencyMatrix<TVertex>(AdjacencyMatrix<TVertex, int> storage) {
                return new AdjacencyMatrix<TVertex, int>(storage);
            }

            public AdjacencyMatrix<TVertex, TWeight>
                CreateAdjacencyMatrix<TVertex, TWeight>()
                where TWeight : IComparable {
                return new AdjacencyMatrix<TVertex, TWeight>();
            }

            public AdjacencyMatrix<TVertex, TWeight>
                CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] scheme)
                where TWeight : IComparable {
                return new AdjacencyMatrix<TVertex, TWeight>(scheme);
            }

            public AdjacencyMatrix<TVertex, TWeight>
                CreateAdjacencyMatrix<TVertex, TWeight>(Dictionary<TVertex, int> scheme)
                where TWeight : IComparable {
                return new AdjacencyMatrix<TVertex, TWeight>(scheme);
            }

            public AdjacencyMatrix<TVertex, TWeight>
                CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] scheme, TWeight[,] matrix)
                where TWeight : IComparable {
                return new AdjacencyMatrix<TVertex, TWeight>(scheme, matrix);
            }

            public AdjacencyMatrix<TVertex, TWeight>
                CreateAdjacencyMatrix<TVertex, TWeight>(AdjacencyMatrix<TVertex, TWeight> storage)
                where TWeight : IComparable {
                return new AdjacencyMatrix<TVertex, TWeight>(storage);
            }
        }

        public class AdjacencyList {
            public AdjacencyList<TVertex, int>
               CreateAdjacencyList<TVertex>() {
                return new AdjacencyList<TVertex, int>();
            }

            public AdjacencyList<TVertex, int>
                CreateAdjacencyList<TVertex>(TVertex[] vertices) {
                var storage = new Dictionary<TVertex, Dictionary<TVertex, int>>();
                foreach (var vertex in vertices) {
                    storage.Add(vertex, new Dictionary<TVertex, int>());
                }
                return new AdjacencyList<TVertex, int>(storage);
            }

            public AdjacencyList<TVertex, int>
                CreateAdjacencyList<TVertex>(Dictionary<TVertex, Dictionary<TVertex, int>> storage) {
                return new AdjacencyList<TVertex, int>(storage);
            }

            public AdjacencyList<TVertex, int>
                CreateAdjacencyList<TVertex>(IAdjacencyList<TVertex, int> storage) {
                return new AdjacencyList<TVertex, int>(storage);
            }

            public AdjacencyList<TVertex, TWeight>
                CreateAdjacencyList<TVertex, TWeight>()
                where TWeight : IComparable {
                return new AdjacencyList<TVertex, TWeight>();
            }

            public AdjacencyList<TVertex, TWeight>
                CreateAdjacencyList<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
                where TWeight : IComparable {
                return new AdjacencyList<TVertex, TWeight>(storage);
            }

            public AdjacencyList<TVertex, TWeight>
                CreateAdjacencyList<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
                where TWeight : IComparable {
                return new AdjacencyList<TVertex, TWeight>(storage);
            }
        }

        public class Matrix {
            public Matrix<int, int> CreateMatrix() {
                return new Matrix<int, int>();
            }

            public Matrix<T, int> CreateMatrix<T>() {
                return new Matrix<T, int>();
            }

            public Matrix<T, TW> CreateMatrix<T, TW>() {
                return new Matrix<T, TW>();
            }

            public Matrix<int, int> CreateMatrix(int count) {
                int[] scheme = new int[count];
                for (int i = 0; i < count; i++) {
                    scheme[i] = i;
                }
                return new Matrix<int, int>(scheme);
            }

            public Matrix<T, int> CreateMatrix<T>(Scheme<T> scheme) {
                return new Matrix<T, int>(scheme);
            }
            
            public Matrix<T, int> CreateMatrix<T>(ICollection<T> scheme) {
                return new Matrix<T, int>(scheme);
            }

            public Matrix<T, TW> CreateMatrix<T, TW>(ICollection<T> scheme) {
                return new Matrix<T, TW>(scheme);
            }
        }
    }
}