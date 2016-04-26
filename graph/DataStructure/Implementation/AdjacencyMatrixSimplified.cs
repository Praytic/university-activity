using System.Collections.Generic;

namespace graph.DataStructure.Implementation {
    public class AdjacencyMatrixSimplified<TVertex> :
        AdjacencyMatrix<TVertex, int>,
        ISimplified
    {
        public AdjacencyMatrixSimplified()
        {
        }

        public AdjacencyMatrixSimplified(TVertex[] schema) : base(schema)
        {
        }

        public AdjacencyMatrixSimplified(Dictionary<TVertex, int> schema) : base(schema)
        {
        }

        public AdjacencyMatrixSimplified(TVertex[] schema, int[,] matrix) : base(schema, matrix)
        {
        }
    }
}