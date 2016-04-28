using System.Collections;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IDataStructure<TVertex, out TStorage> : 
        ICollection<TVertex>
        where TStorage : ICollection
    {
        TStorage Storage { get; }
    }
}