using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraAllPathsAdjacencyMatrix<TVertex> :
        DijkstraAllPaths<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public DijkstraAllPathsAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run() {
            var algorithmsFactory = new AlgorithmsFactory();
            var copyGraph = Graph;
            while (true)
            {
                var shortestPath = algorithmsFactory.CreateDijkstraShortestPath(copyGraph, Start, Finish);
                shortestPath.Run();
                if (shortestPath.Result.Count == 0) break;

                Result.Add(shortestPath.Result);
                foreach (var vertex in shortestPath.Result)
                {
                    if (!Equals(vertex, Start) || !Equals(vertex, Finish))
                    {
                        copyGraph.Remove(vertex);
                    }
                }
            }
        }
    }
}