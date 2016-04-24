using System;

namespace graph.DataStructure
{
    public interface IAdjacency<TValue, in TWeight> where TWeight : IComparable
    {
        void AddDirectedEdge(TValue  @from, TValue @to, TWeight weight);

        void AddUndirectedEdge(TValue @from, TValue @to, TWeight weight);

        void RemoveEdge(TValue @from, TValue @to);

        TValue GetFirstVertex();

        TValue GetNextVertex(TValue currentVertex);
    }
}