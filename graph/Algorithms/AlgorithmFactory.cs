using graph.Algorithms.Implementation;
using graph.DataStructure;
using graph.DataStructure.Implementation;

namespace graph.Algorithms
{
    public class AlgorithmsFactory
    {
        public IAlgorithm<IGraph<TVertex, int>, TVertex, int>
            CreateDijkstraShortestPath<TVertex>(IGraph<TVertex, int> graph, TVertex start, TVertex finish)
        {
            if (graph.GetType().IsSubclassOf(typeof (GraphAdjacencyMatrix<TVertex, int>)))
            {
                return
                    (IAlgorithm<IGraph<TVertex, int>, TVertex, int>)
                        new DijkstraShortestPathAdjacencyMatrix<TVertex>(graph as GraphAdjacencyMatrix<TVertex, int>,
                            start, finish);
            }
            return
                (IAlgorithm<IGraph<TVertex, int>, TVertex, int>)
                    new DijkstraShortestPathAdjacencyList<TVertex>(graph as GraphAdjacencyList<TVertex, int>, start,
                        finish);
        }

        public IAlgorithm<IGraph<TVertex, int>, TVertex, int>
            CreateFloydShortestPath<TVertex>(IGraph<TVertex, int> graph, TVertex start, TVertex finish)
        {
            if (graph.GetType().IsSubclassOf(typeof (GraphAdjacencyMatrix<TVertex, int>)))
            {
                return
                    (IAlgorithm<IGraph<TVertex, int>, TVertex, int>)
                        new FloydShortestPathAdjacencyMatrix<TVertex>(graph as GraphAdjacencyMatrix<TVertex, int>, start,
                            finish);
            }
            return
                (IAlgorithm<IGraph<TVertex, int>, TVertex, int>)
                    new FloydShortestPathAdjacencyList<TVertex>(graph as GraphAdjacencyList<TVertex, int>, start, finish);
        }
    }
}