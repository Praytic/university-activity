using System;
using graph.DataStructure;

namespace graph.Algorithms
{
    public abstract class AlgorithmContract<TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public StorageFactory.Matrix Data { get; } = new StorageFactory.Matrix();
        
        public TGraph Graph;

        public abstract void Run();
    }
}