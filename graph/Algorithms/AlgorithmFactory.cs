using graph.Algorithms.Implementation;
using graph.DataStructure.Implementation;

namespace graph.Algorithms
{
    public class AlgorithmsFactory
    {
        public DijkstraShortestPath<GraphAdjacencyList<TVertex, int>, TVertex> 
            CreateDijkstraShortestPath<TVertex>(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish)
        {
            return new DijkstraShortestPathAdjacencyList<TVertex>(graph, start, finish);
        }

        public DijkstraShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex> 
            CreateDijkstraShortestPath<TVertex>(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) {
            return new DijkstraShortestPathAdjacencyMatrix<TVertex>(graph, start, finish);
        }

        public FloydShortestPath<GraphAdjacencyList<TVertex, int>, TVertex>
            CreateFloydShortestPath<TVertex>(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish) {
            return new FloydShortestPathAdjacencyList<TVertex>(graph, start, finish);
        }

        public FloydShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
            CreateFloydShortestPath<TVertex>(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) {
            return new FloydShortestPathAdjacencyMatrix<TVertex>(graph, start, finish);
        }
    }
}