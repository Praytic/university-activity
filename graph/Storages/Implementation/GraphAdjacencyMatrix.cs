using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
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
    }
}