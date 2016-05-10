using System;
using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraAllPathsAdjacencyMatrix<TVertex> :
        DijkstraAllPaths<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public DijkstraAllPathsAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish) {

            Result = new List<List<TVertex>>();
            Done = new Dictionary<TVertex, bool>();
            foreach (var i in graph) {
                Done.Add(i, false);
            }
            ParentIds = new Dictionary<int, int>();
            foreach (var i in graph) {
                ParentIds[graph.Scheme[i]] = -1;
            }
            Distances = new Dictionary<TVertex, int>();
            foreach (var i in Graph) {
                Distances[i] = int.MaxValue;
            }
            Distances[start] = 0;
        }

        public override void Run() {
            var copyGraph = Graph;
            while (true)
            {
                var shortestPath = new DijkstraShortestPathAdjacencyMatrix<TVertex>(copyGraph, Start, Finish);
                shortestPath.Run();
                if (shortestPath.Result.Count == 0) break;

                Result.Add(shortestPath.Result);
                var previousVertex = Start;
                var path = shortestPath.Result;
                for (int i = 1; i < path.Count; i++)
                {
                    copyGraph.RemoveEdge(previousVertex, path[i]);
                    previousVertex = path[i];
                }

                Console.WriteLine(copyGraph);
                Console.WriteLine();
            }
        }
    }
}