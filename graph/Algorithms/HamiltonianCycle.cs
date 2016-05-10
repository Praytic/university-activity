using System;
using System.Collections.Generic;
using graph.Storages;

namespace graph.Algorithms
{
    public abstract class HamiltonianCycle<TGraph, TVertex, TWeight> :
        AlgorithmContract<TGraph, TVertex, TWeight>
        where TGraph : IGraph<TVertex, TWeight> 
        where TWeight : IComparable
    {
        public LinkedList<TVertex> Result { get; protected set; }
        public TVertex Start { get; }
        public HashSet<TVertex> Used { get; protected set; }
        public LinkedList<TVertex> Parents { get; protected set; } 

        protected HamiltonianCycle(TGraph graph, TVertex start) {
            Start = start;
            Graph = graph;
        }
    }
}