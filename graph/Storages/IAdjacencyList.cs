using System;
using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Storages {
    public interface IAdjacencyList<TVertex, TWeight> : 
        IAdjacency<TVertex, TWeight>,
        IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> 
        where TWeight : IComparable 
    {
        Scheme<TVertex> Scheme { get; }

        Dictionary<TVertex, TWeight> this[TVertex key] { get; set; }
    }
}
