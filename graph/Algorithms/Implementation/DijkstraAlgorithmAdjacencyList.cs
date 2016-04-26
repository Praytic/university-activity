using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraAdjacencyListAlgorithm<TVertex> :
        DijkstraAlgorithm<GraphAdjacencyListSimplified<TVertex>, TVertex>
    {
        public DijkstraAdjacencyListAlgorithm(GraphAdjacencyListSimplified<TVertex> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}