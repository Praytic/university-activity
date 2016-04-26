using System;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IGraph<TVertex, TWeight> :
        ICollection<TVertex>
        where TWeight : IComparable
    {
    }
}