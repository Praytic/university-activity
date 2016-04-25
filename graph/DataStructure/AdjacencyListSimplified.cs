namespace graph.DataStructure
{
    public class AdjacencyListSimplified<TVertex> :
        AdjacencyList<TVertex, int>,
        ISimplified 
    {
        public AdjacencyListSimplified()
        {
        }

        public AdjacencyListSimplified(IAdjacencyList<TVertex, int> adjacencyList) : base(adjacencyList)
        {
        }

        public void AddDirectedEdge(TVertex @from, TVertex to) {
            List[@from].Add(to, 1);
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to) {
            List[@from].Add(to, 1);
            List[to].Add(@from, 1);
        }
    }
}