using System.Collections.Generic;
using graph.DataStructure;

namespace graph.Algorithms
{
    public abstract class DijkstraAllPaths<TGraph, TVertex> :
        AlgorithmContract<TGraph, TVertex, int>
        where TGraph : IGraph<TVertex, int>
    {
        public List<List<TVertex>> Result { get; }
        public TVertex Start { get; }
        public TVertex Finish { get; }
        public Dictionary<TVertex, bool> Done { get; }
        public Dictionary<TVertex, TVertex> Parent { get; }
        public Dictionary<TVertex, int> Distances { get; }

        protected DijkstraAllPaths(TGraph graph, TVertex start, TVertex finish) {
            Start = start;
            Finish = finish;
            Graph = graph;

            Result = new List<List<TVertex>>();
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