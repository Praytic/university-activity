using System;
using System.Collections.Generic;

namespace graph.DataStructure {
    public interface IMatrix<TVertex, TWeight> :
        IDataStructure<TVertex, List<List<TWeight>>>
    {
        Dictionary<TVertex, int> Schema { get; }

        TWeight this[TVertex i, TVertex j] { get; set; }
    }
}
