using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
    public class AdjacencyListSimplified<TVertex> :
        AdjacencyList<TVertex, int>,
        ISimplified 
    {
        public AdjacencyListSimplified()
        {
        }

        public AdjacencyListSimplified(Dictionary<TVertex, Dictionary<TVertex, int>> storage) : base(storage)
        {
        }

        public AdjacencyListSimplified(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, int>>> storage) : base(storage)
        {
        }
    }
}