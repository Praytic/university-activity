using System;
using System.Collections.Generic;

namespace graph.DataStructure {
    public interface IAdjacencyList<TVertex, TWeight> : 
        IAdjacency<TVertex, TWeight>,
        IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> 
        where TWeight : IComparable 
    {
        Dictionary<TVertex, TWeight> this[TVertex key] { get; set; }
    }
}
