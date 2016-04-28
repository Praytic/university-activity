using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyList<TVertex, TWeight> :
        AdjacencyList<TVertex, TWeight>,
        IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(AdjacencyList<TVertex, TWeight> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IDataStructure<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) : base(storage)
        {
        }
    }
}