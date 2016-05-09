using System;
using System.Collections.Generic;
using graph.DataStructure;

namespace graph.Storages.Implementation
{
    public class GraphAdjacencyMatrix :
        GraphAdjacencyMatrix<int, int>
    {
        public GraphAdjacencyMatrix()
        {
        }

        public GraphAdjacencyMatrix(int[] scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(Dictionary<int, int> scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(int[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public GraphAdjacencyMatrix(AdjacencyMatrix<int, int> storage) : base(storage)
        {
        }

        public GraphAdjacencyMatrix(Matrix<int, int> matrix) : base(matrix) {
        }
    }

    public class GraphAdjacencyMatrix<TVertex> :
        GraphAdjacencyMatrix<TVertex, int>
    {
        public GraphAdjacencyMatrix()
        {
        }

        public GraphAdjacencyMatrix(TVertex[] scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(Dictionary<TVertex, int> scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(TVertex[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public GraphAdjacencyMatrix(AdjacencyMatrix<TVertex, int> storage) : base(storage)
        {
        }

        public GraphAdjacencyMatrix(Matrix<TVertex, int> matrix) : base(matrix) {
        }
    }

    public class GraphAdjacencyMatrix<TVertex, TWeight> :
        AdjacencyMatrix<TVertex, TWeight>, 
        IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {

        public ICollection<TVertex> Vertices
        {
            get { return Scheme.Keys; }
        }

        public ICollection<int> VerticesIds {
            get { return Scheme.Values; }
        }

        public GraphAdjacencyMatrix()
        {
        }

        public GraphAdjacencyMatrix(TVertex[] scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(Dictionary<TVertex, int> scheme) : base(scheme)
        {
        }

        public GraphAdjacencyMatrix(TVertex[] scheme, TWeight[,] matrix) : base(scheme, matrix)
        {
        }

        public GraphAdjacencyMatrix(AdjacencyMatrix<TVertex, TWeight> storage) : base(storage)
        {
        }

        public GraphAdjacencyMatrix(Matrix<TVertex, TWeight> matrix) : base(matrix) {
        }
    }
}