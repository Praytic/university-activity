using System.Collections.Generic;
using System.Security.Cryptography;

namespace graph.DataStructure
{
    public class Graph<TValue, TWeight> {
        protected AdjacencyMatrix<TValue, TWeight> AdjacencyMatrix;

        public Graph() {
            AdjacencyMatrix = new AdjacencyMatrix<TValue, TWeight>();
        }

        public Graph(AdjacencyMatrix<TValue, TWeight> adjacencyMatrix) {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public void AddNode(TValue value) {
            AdjacencyMatrix.Add(value);
        }

        public void AddDirectedEdge(TValue from, TValue to, TWeight cost) {
            AdjacencyMatrix.AddDirectedEdge(from, to, cost);
        }

        public void AddUndirectedEdge(TValue from, TValue to, TWeight cost) {
            AdjacencyMatrix.AddUndirectedEdge(from, to, cost);
        }

        public bool Contains(TValue value) {
            return AdjacencyMatrix.Contains(value);
        }

        public void RemoveNode(TValue value) {
            AdjacencyMatrix.Remove(value);
        }

        public override string ToString() {
            return AdjacencyMatrix.ToString();
        }

        public List<TValue> HamiltonCycle()
        {
            List<TValue> hamiltonCycle = new List<TValue>(new TValue[AdjacencyMatrix.Size + 1]);
            var visitedVertexList = new List<bool>(new bool[AdjacencyMatrix.Size + 1]);
            visitedVertexList[0] = true;
            AdjacencyMatrix.HamiltonCycle(ref hamiltonCycle, ref visitedVertexList);
            return hamiltonCycle;
        }
    }
}