using System;

namespace graph.DataStructure
{
    public interface IAdjacency<TVertex, in TWeight> where TWeight : IComparable
    {
        void AddDirectedEdge(TVertex  @from, TVertex @to, TWeight weight);

        void AddUndirectedEdge(TVertex @from, TVertex @to, TWeight weight);

        void RemoveEdge(TVertex @from, TVertex @to);

        TVertex GetFirstVertex();

        TVertex GetNextVertex(TVertex currentVertex);
    }
}