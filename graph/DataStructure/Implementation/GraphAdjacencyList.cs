using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyList<TVertex, TWeight> :
        AdjacencyList<TVertex, TWeight> 
        where TWeight : IComparable 
    {
        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) : base(storage)
        {
        }
    }
}