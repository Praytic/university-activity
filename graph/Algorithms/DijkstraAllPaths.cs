using System.Collections.Generic;
using graph.Storages;

namespace graph.Algorithms
{
    public abstract class DijkstraAllPaths<TGraph, TVertex> :
        AlgorithmContract<TGraph, TVertex, int>
        where TGraph : IGraph<TVertex, int>
    {
        public List<List<TVertex>> Result { get; protected set; }
        public TVertex Start { get; }
        public TVertex Finish { get; }
        public Dictionary<TVertex, bool> Done { get; protected set; }
        public Dictionary<int, int> ParentIds { get; protected set; }
        public Dictionary<TVertex, int> Distances { get; protected set; }

        protected DijkstraAllPaths(TGraph graph, TVertex start, TVertex finish) {
            Start = start;
            Finish = finish;
            Graph = graph;
        }
    }
}