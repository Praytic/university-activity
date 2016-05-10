﻿using System;
using graph.Storages;

namespace graph.Algorithms
{
    public interface IAlgorithm<out TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight>
        where TWeight : IComparable
    {
        TGraph Graph { get; }

        dynamic Result { get; }

        void Run();
    }
}