using System;
using System.Collections.Generic;
using graph.DataStructure;

namespace graph.Algorithms
{
    public abstract class HamiltonianCycle<TGraph, TVertex, TWeight> :
        AlgorithmContract<TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight> 
        where TWeight : IComparable
    {
        public LinkedList<TVertex> Result { get; }
        public TVertex Start { get; }
        public HashSet<TVertex> Used { get; }
        public LinkedList<TVertex> Parents { get; } 

        protected HamiltonianCycle(TGraph graph, TVertex start) {
            Start = start;
            Graph = graph;

            Result = new LinkedList<TVertex>();
            Used = new HashSet<TVertex>();
            Parents = new LinkedList<TVertex>();
        }
    }
}