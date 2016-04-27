using System;
using System.Collections.Generic;
using System.Text;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyMatrix<TVertex, TWeight> :
        AdjacencyMatrix<TVertex, TWeight>, 
        IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public GraphAdjacencyMatrix()
        {
        }

        public GraphAdjacencyMatrix(TVertex[] schema) : base(schema)
        {
        }

        public GraphAdjacencyMatrix(Dictionary<TVertex, int> schema) : base(schema)
        {
        }

        public GraphAdjacencyMatrix(TVertex[] schema, TWeight[,] matrix) : base(schema, matrix)
        {
        }
    }
}