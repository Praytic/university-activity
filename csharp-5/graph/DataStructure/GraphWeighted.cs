namespace graph.DataStructure
{
    public class GraphWeighted<TValue, TCost> : Graph<TValue> {
        private readonly AdjacencyMatrix<TValue, TCost> _adjacencyMatrix;

        public GraphWeighted()
        {
            _adjacencyMatrix = new AdjacencyMatrix<TValue, TCost>();
        }
        public GraphWeighted(AdjacencyMatrix<TValue, TCost> adjacencyMatrix) {
            _adjacencyMatrix = adjacencyMatrix;
        }

        public void AddDirectedEdge(TValue from, TValue to, TCost cost)
        {
            _adjacencyMatrix.AddDirectedEdge(from, to, cost);
        }

        public void AddUndirectedEdge(TValue from, TValue to, TCost cost) {
            _adjacencyMatrix.AddUndirectedEdge(from, to, cost);
        }
    }
}