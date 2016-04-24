namespace graph.DataStructure
{
    public class AdjacencyMatrixUnweighted<TValue> : AdjacencyMatrix<TValue, byte>
    {
        public void AddDirectedEdge(TValue @from, TValue to) {
            Matrix[Schema[from], Schema[to]] = 1;
        }

        public void AddUndirectedEdge(TValue @from, TValue to) {
            Matrix[Schema[from], Schema[to]] = 1;
            Matrix[Schema[to], Schema[from]] = 1;
        }
    }
}