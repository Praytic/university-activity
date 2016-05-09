using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraAllPathsAdjacencyMatrix<TVertex> :
        DijkstraAllPaths<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public DijkstraAllPathsAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
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
            }
        }
    }
}