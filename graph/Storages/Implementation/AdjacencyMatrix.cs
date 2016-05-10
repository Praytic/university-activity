using System;
using System.Collections.Generic;

namespace graph.Storages.Implementation {
    public class AdjacencyMatrix :
        AdjacencyMatrix<int, int>
    {
        public AdjacencyMatrix()
        {
        }

        public AdjacencyMatrix(int[] scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(Dictionary<int, int> scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(int[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public AdjacencyMatrix(IMatrix<int, int> storage) : base(storage)
        {
        }

        public AdjacencyMatrix(Matrix<int, int> matrix) : base(matrix) {
        }
    }

    public class AdjacencyMatrix<TVertex> :
        AdjacencyMatrix<TVertex, int>
    {
        public AdjacencyMatrix()
        {
        }

        public AdjacencyMatrix(TVertex[] scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(Dictionary<TVertex, int> scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(TVertex[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public AdjacencyMatrix(IMatrix<TVertex, int> storage) : base(storage)
        {
        }

        public AdjacencyMatrix(Matrix<TVertex, int> matrix) : base(matrix)
        {
        }
    }

    public class AdjacencyMatrix<TVertex, TWeight> :
        Matrix<TVertex, TWeight>,
        IAdjacency<TVertex, TWeight> 
        where TWeight : IComparable 
    {
        public AdjacencyMatrix() : base()
        {
        }

        public AdjacencyMatrix(TVertex[] scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(Dictionary<TVertex, int> scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(TVertex[] scheme, TWeight[,] matrix) : base(scheme, matrix)
        {
        }

        public AdjacencyMatrix(IMatrix<TVertex, TWeight> matrix) : base(matrix)
        {
        }

        public AdjacencyMatrix(Matrix<TVertex, TWeight> matrix) : base(matrix) {
        }

        public void AddDirectedEdge(TVertex @from, TVertex to, TWeight weight)
        {
            this[@from, to] = weight;
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to, TWeight weight) {
            this[@from, to] = weight;
            this[to, @from] = weight;
        }

        public void RemoveEdge(TVertex @from, TVertex to)
        {
            this[@from, to] = default(TWeight);
        }

        public TVertex GetFirstVertex()
        {
            return Scheme.GetFirst().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex)
        {
            var keysCollection = Scheme;
            bool isNextVertex = false;
            foreach (var key in keysCollection) {
                if (isNextVertex) {
                    return key;
                }
                if (key.Equals(currentVertex)) {
                    isNextVertex = true;
                }
            }
            return default(TVertex);
        }
    }
}