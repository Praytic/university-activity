﻿using System.Collections;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IStorage<T, out TStorage> : 
        ICollection<T>
        where TStorage : ICollection
    {
        TStorage Storage { get; }
    }
}