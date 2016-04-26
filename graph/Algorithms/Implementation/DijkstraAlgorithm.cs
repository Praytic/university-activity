using System.Collections.Generic;
using graph.DataStructure;

namespace graph.Algorithms.Implementation {
    public abstract class DijkstraAlgorithm<TGraph, TVertex> :
        AlgorithmContract<TGraph, TVertex, int>
        where TGraph : IGraph<TVertex, int> 
    {
        public TVertex Start { get; }
        public TVertex Finish { get; }
        public Dictionary<TVertex, bool> Done { get; }
        public Dictionary<TVertex, TVertex> Parent { get; }
        public Dictionary<TVertex, int> Distances { get; }
        public List<TVertex> Result { get; protected set; }

        public DijkstraAlgorithm(TGraph graph, TVertex start, TVertex finish) {
            Start = start;
            Finish = finish;
            Graph = graph;

            Done = new Dictionary<TVertex, bool>();
            foreach (var i in Graph) {
                Done.Add(i, false);
            }
            Parent = new Dictionary<TVertex, TVertex>();
            foreach (var i in Graph) {
                Parent[i] = default(TVertex);
            }
            Distances = new Dictionary<TVertex, int>();
            foreach (var i in Graph) {
                Distances[i] = int.MaxValue;
            }
            Distances[start] = 0;
        }
    }
}