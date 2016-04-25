using System;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IAdjacencyList<TVertex, TWeight> :
        IAdjacency<TVertex, TWeight>,
        ICollection<TVertex> 
        where TWeight : IComparable
    {
        Dictionary<TVertex, Dictionary<TVertex, TWeight>> List { get; }

        Dictionary<TVertex, TWeight> this[TVertex i] { get; set; }
    }
}