using System.Collections.Generic;

namespace graph.DataStructure {
    public interface IMatrix<TVertex, TWeight> :
        IStorage<TVertex, List<List<TWeight>>>,
        ISchemable<TVertex> 
    {
        TWeight this[TVertex i, TVertex j] { get; set; }

        TWeight this[int i, int j] { get; set; }
    }
}
