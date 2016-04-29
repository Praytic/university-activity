﻿using System;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IGraph<TVertex, in TWeight> :
        ICollection<TVertex>,
        IAdjacency<TVertex, TWeight> 
        where TWeight : IComparable
    {
    }
}