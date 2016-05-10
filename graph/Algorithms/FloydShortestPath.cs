using System.Collections.Generic;
using graph.Storages;

namespace graph.Algorithms {
    public abstract class FloydShortestPath<TGraph, TVertex> :
        AlgorithmContract<TGraph, TVertex, int>
        where TGraph : IGraph<TVertex, int> 
    {
        public List<TVertex> Result { get; protected set; } 
        public TVertex Start { get; set; }
        public TVertex Finish { get; set; }
        public IMatrix<TVertex, long> Distances { get; protected set; }

        protected FloydShortestPath(TGraph graph, TVertex start, TVertex finish) {
            Start = start;
            Finish = finish;
            Graph = graph;
        }
    }
}