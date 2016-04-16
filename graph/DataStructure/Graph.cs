using System.Data;

namespace graph.DataStructure {

    public class Graph<TValue> : DataSet {
        private readonly AdjacencyMatrix<TValue, byte> _adjacencyMatrix;

        public Graph() {
            _adjacencyMatrix = new AdjacencyMatrix<TValue, byte>();
        }

        public Graph(AdjacencyMatrix<TValue, byte> adjacencyMatrix) {
            _adjacencyMatrix = adjacencyMatrix;
        }

        public void AddNode(TValue value) {
            _adjacencyMatrix.Add(value);
        }

        public void AddDirectedEdge(TValue from, TValue to) {
            AddDirectedEdge(from, to, 1);
        }

        public void AddDirectedEdge(TValue from, TValue to, byte cost) {
            _adjacencyMatrix.AddDirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(TValue from, TValue to) {
            AddUndirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(TValue from, TValue to, byte cost) {
            _adjacencyMatrix.AddUndirectedEdge(from, to, cost);
        }

        public bool Contains(TValue value) {
            return _adjacencyMatrix.Contains(value);
        }

        public void Remove(TValue value) {
            _adjacencyMatrix.Remove(value);
        }

        public override string ToString() {
            return _adjacencyMatrix.ToString();
        }
    }
}