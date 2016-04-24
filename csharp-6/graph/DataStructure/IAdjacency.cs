namespace graph.DataStructure
{
    public interface IAdjacency<TValue, in TWeight>
    {
        void AddDirectedEdge(TValue  @from, TValue @to, TWeight weight);

        void AddUndirectedEdge(TValue @from, TValue @to, TWeight weight);

        void RemoveEdge(TValue @from, TValue @to);

        TValue GetFirstVertex();

        TValue GetNextVertex(TValue currentVertex);
    }
}