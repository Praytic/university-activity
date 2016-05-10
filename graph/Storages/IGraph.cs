using System;
using System.Collections.Generic;

namespace graph.Storages
{
    public interface IGraph<TVertex, in TWeight> :
        ICollection<TVertex>,
        IAdjacency<TVertex, TWeight>
        where TWeight : IComparable
    {
        ICollection<TVertex> Vertices { get; }
    }
}