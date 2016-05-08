using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.DataStructure.Implementation {
    public class AdjacencyMatrix<TVertex, TWeight> :
        Matrix<TVertex, TWeight>,
        IAdjacency<TVertex, TWeight> 
        where TWeight : IComparable 
    {
        public AdjacencyMatrix() : base()
        {
        }

        public AdjacencyMatrix(TVertex[] schema) : base(schema)
        {
        }

        public AdjacencyMatrix(Dictionary<TVertex, int> schema) : base(schema)
        {
        }

        public AdjacencyMatrix(TVertex[] schema, TWeight[,] matrix) : base(schema, matrix)
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
            return Schema.First().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex)
        {
            var keysCollection = Schema.Keys;
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