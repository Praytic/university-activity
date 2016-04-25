using System;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IGraph<T>
    {
        T AdjacencyList { get; }
    }
}