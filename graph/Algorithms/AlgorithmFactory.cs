using graph.Algorithms.Implementation;
using graph.DataStructure.Implementation;

namespace graph.Algorithms
{
    public class AlgorithmsFactory
    {
        public FloydShortestPathAdjacencyMatrix<TVertex>
            CreateFloydShortestPath<TVertex>(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) {
            return new FloydShortestPathAdjacencyMatrix<TVertex>(graph, start, finish);
        }

        public DijkstraShortestPathAdjacencyMatrix<TVertex>
            CreateDijkstraShortestPath<TVertex>(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) {
            return new DijkstraShortestPathAdjacencyMatrix<TVertex>(graph, start, finish);
        }

        public FloydShortestPathAdjacencyList<TVertex>
            CreateFloydShortestPath<TVertex>(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish) {
            return new FloydShortestPathAdjacencyList<TVertex>(graph, start, finish);
        }

        public DijkstraShortestPathAdjacencyList<TVertex>
            CreateDijkstraShortestPath<TVertex>(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish) {
            return new DijkstraShortestPathAdjacencyList<TVertex>(graph, start, finish);
        }
    }
}