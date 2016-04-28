using System;
using System.Collections.Generic;

namespace graph.DataStructure {
    public interface IAdjacencyMatrix<TVertex, TWeight> :
        IAdjacency<TVertex, TWeight>,
        IDataStructure<TVertex, List<List<TWeight>>>
        where TWeight : IComparable {
        Dictionary<TVertex, int> Schema { get; }

        TWeight this[TVertex i, TVertex j] { get; set; }
    }
}
