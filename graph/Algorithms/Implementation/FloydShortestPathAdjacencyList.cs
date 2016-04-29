using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyList<TVertex> :
        FloydShortestPath<GraphAdjacencyList<TVertex, int>, TVertex>
    {
        public FloydShortestPathAdjacencyList(GraphAdjacencyList<TVertex, int> graph, TVertex start, TVertex finish)
            : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            
        }
    }
}