using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation {
    public class AdjacencyMatrix<TVertex, TWeight> :
        Matrix<TVertex, TWeight>,
        IAdjacency<TVertex, TWeight> 
        where TWeight : IComparable 
    {
        public AdjacencyMatrix() : base()
        {
        }

        public AdjacencyMatrix(TVertex[] scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(Dictionary<TVertex, int> scheme) : base(scheme)
        {
        }

        public AdjacencyMatrix(TVertex[] scheme, TWeight[,] matrix) : base(scheme, matrix)
        {
        }

        public AdjacencyMatrix(IMatrix<TVertex, TWeight> storage) : base(storage)
        {
        }

        public void AddDirectedEdge(TVertex @from, TVertex to, TWeight weight)
        {
            this[@from, to] = weight;
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to, TWeight weight) {
            this[@from, to] = weight;
            this[to, @from] = weight;
        }

        public void RemoveEdge(TVertex @from, TVertex to)
        {
            this[@from, to] = default(TWeight);
        }

        public TVertex GetFirstVertex()
        {
            return Scheme.GetFirst().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex)
        {
            var keysCollection = Scheme;
            bool isNextVertex = false;
            foreach (var key in keysCollection) {
                if (isNextVertex) {
                    return key;
                }
                if (key.Equals(currentVertex)) {
                    isNextVertex = true;
                }
            }
            return default(TVertex);
        }
    }
}