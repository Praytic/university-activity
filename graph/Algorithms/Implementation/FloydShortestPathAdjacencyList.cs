using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyList<TVertex> :
        FloydShortestPath<GraphAdjacencyList<TVertex>, TVertex>
    {
        public FloydShortestPathAdjacencyList(GraphAdjacencyList<TVertex> graph, TVertex start, TVertex finish)
            : base(graph, start, finish)
        {
        }

        public override void Run()
        {
        }
    }
}