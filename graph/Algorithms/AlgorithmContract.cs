using System;
using graph.DataStructure;

namespace graph.Algorithms
{
    public abstract class AlgorithmContract<TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public TGraph Graph { get; protected set; }

        public dynamic Result { get; protected set; }

        public abstract void Run();
    }
}