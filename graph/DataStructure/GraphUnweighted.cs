namespace graph.DataStructure {

    public class GraphUnweighted<TValue> : Graph<TValue, byte> {

        public GraphUnweighted() {
            AdjacencyMatrix = new AdjacencyMatrix<TValue, byte>();
        }

        public GraphUnweighted(AdjacencyMatrix<TValue, byte> adjacencyMatrix) {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public void AddDirectedEdge(TValue from, TValue to) {
            AdjacencyMatrix.AddDirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(TValue from, TValue to) {
            AdjacencyMatrix.AddUndirectedEdge(from, to, 1);
        }
    }
}