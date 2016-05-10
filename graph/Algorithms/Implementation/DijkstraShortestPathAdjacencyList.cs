using System;
using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraShortestPathAdjacencyList<TVertex> :
        DijkstraShortestPath<GraphAdjacencyList<TVertex, int>, TVertex>
    {
        public DijkstraShortestPathAdjacencyList(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish) {
            Result = new List<TVertex>();
            Done = new Dictionary<TVertex, bool>();
            foreach (var i in Graph) {
                Done.Add(i, false);
            }
            ParentIds = new Dictionary<int, int>();
            foreach (var i in Graph) {
                ParentIds[Graph.Scheme[i]] = -1;
            }
            Distances = new Dictionary<TVertex, int>();
            foreach (var i in Graph) {
                Distances[i] = int.MaxValue;
            }
            Distances[start] = 0;
        }

        public override void Run()
        {
            //TODO Add implementation
            throw new NotImplementedException();
        }
    }
}