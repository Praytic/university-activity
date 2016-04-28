using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraShortestPathAdjacencyList<TVertex> :
        DijkstraShortestPath<GraphAdjacencyList<TVertex, int>, TVertex>
    {
        public DijkstraShortestPathAdjacencyList(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            
        }
    }
}