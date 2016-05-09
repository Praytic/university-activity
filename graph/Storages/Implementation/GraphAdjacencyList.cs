using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation
{
    public class GraphAdjacencyList<TVertex, TWeight> :
        AdjacencyList<TVertex, TWeight>,
        IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public ICollection<TVertex> Vertices
        {
            get { return Storage.Keys; }
        }

        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IAdjacencyList<TVertex, TWeight> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) : base(storage)
        {
        }
    }
}