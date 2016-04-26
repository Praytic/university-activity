using System;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyMatrixSimplified<TVertex> :
        Graph<TVertex, int, AdjacencyMatrix<TVertex, int>>
    {
        public GraphAdjacencyMatrixSimplified()
        {
        }

        public GraphAdjacencyMatrixSimplified(AdjacencyMatrix<TVertex, int> adjacencyMatrix) : base(adjacencyMatrix)
        {
        }

        public GraphAdjacencyMatrixSimplified(Graph<TVertex, int, AdjacencyMatrix<TVertex, int>> graph) : base(graph)
        {
        }
    }
}