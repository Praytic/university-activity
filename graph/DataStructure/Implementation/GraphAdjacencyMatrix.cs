using System;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyMatrix<TVertex, TWeight> :
        Graph<TVertex, TWeight, AdjacencyMatrix<TVertex, TWeight>>
        where TWeight : IComparable 
    {
        public GraphAdjacencyMatrix()
        {
        }

        public GraphAdjacencyMatrix(AdjacencyMatrix<TVertex, TWeight> adjacencyMatrix) : base(adjacencyMatrix)
        {
        }

        public GraphAdjacencyMatrix(Graph<TVertex, TWeight, AdjacencyMatrix<TVertex, TWeight>> graph) : base(graph)
        {
        }
    }
}