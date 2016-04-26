using System;
using graph.DataStructure;

namespace graph.Algorithms
{
    public interface IAlgorithm<out TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight>
        where TWeight : IComparable
    {
        TGraph Graph { get; }

        void Run();
    }
}