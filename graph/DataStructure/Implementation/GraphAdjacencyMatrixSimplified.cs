using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyMatrixSimplified<TVertex> :
        GraphAdjacencyMatrix<TVertex, int>,
        ISimplified
    {
        public GraphAdjacencyMatrixSimplified()
        {
        }

        public GraphAdjacencyMatrixSimplified(TVertex[] schema) : base(schema)
        {
        }

        public GraphAdjacencyMatrixSimplified(Dictionary<TVertex, int> schema) : base(schema)
        {
        }

        public GraphAdjacencyMatrixSimplified(TVertex[] schema, int[,] matrix) : base(schema, matrix)
        {
        }

        public GraphAdjacencyMatrixSimplified(IAdjacencyMatrix<TVertex, int> storage) : base(storage)
        {
        }
    }
}