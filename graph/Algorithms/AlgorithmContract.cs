using System;
using graph.DataStructure;
using graph.Storages;

namespace graph.Algorithms
{
    public abstract class AlgorithmContract<TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public TGraph Graph;

        public abstract void Run();
    }
}