using graph.DataStructure.Implementation;

namespace graph.DataStructure
{
    public class AdjacencyListSimplified<TVertex> :
        AdjacencyList<TVertex, int>,
        ISimplified 
    {
        public AdjacencyListSimplified()
        {
        }

        public AdjacencyListSimplified(IAdjacencyList<TVertex, int> adjacencyList) : base(adjacencyList)
        {
        }
    }
}