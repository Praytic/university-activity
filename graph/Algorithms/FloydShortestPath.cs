using System.Collections.Generic;
using graph.DataStructure;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation {
    public abstract class FloydShortestPath<TGraph, TVertex> :
        AlgorithmContract<TGraph, TVertex, int>
        where TGraph : IGraph<TVertex, int> 
    {
        public List<TVertex> Result { get; protected set; } 
        public TVertex Start { get; set; }
        public TVertex Finish { get; set; }
        public IMatrix<TVertex, long> Distances { get; }

        protected FloydShortestPath(TGraph graph, TVertex start, TVertex finish) {
            Start = start;
            Finish = finish;
            Graph = graph;

            Result = new List<TVertex>();
            Distances = new Matrix<TVertex, long>(Graph.Vertices);
        }
    }
}