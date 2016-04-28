using System.Collections.Generic;

namespace graph.DataStructure.Implementation {

    public class GraphAdjacencyListSimplified<TVertex> :
        GraphAdjacencyList<TVertex, int>,
        ISimplified
    {
        public GraphAdjacencyListSimplified()
        {
        }

        public GraphAdjacencyListSimplified(Dictionary<TVertex, Dictionary<TVertex, int>> storage) : base(storage)
        {
        }

        public GraphAdjacencyListSimplified(IAdjacencyList<TVertex, int> storage) : base(storage)
        {
        }

        public GraphAdjacencyListSimplified(IDataStructure<TVertex, Dictionary<TVertex, Dictionary<TVertex, int>>> storage) : base(storage)
        {
        }
    }
}