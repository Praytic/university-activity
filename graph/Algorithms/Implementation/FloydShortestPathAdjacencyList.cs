using System;
using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyList<TVertex> :
        FloydShortestPath<GraphAdjacencyList<TVertex>, TVertex>
    {
        public FloydShortestPathAdjacencyList(GraphAdjacencyList<TVertex> graph, TVertex start, TVertex finish)
            : base(graph, start, finish) {
            Result = new List<TVertex>();
            Distances = new Matrix<TVertex, long>(Graph.Vertices);
        }

        public override void Run()
        {
            //TODO Add implementation
            throw new NotImplementedException();
        }
    }
}