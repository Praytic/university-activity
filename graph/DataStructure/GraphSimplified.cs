using System.Collections.Generic;

namespace graph.DataStructure {

    public class GraphSimplified<TVertex> : 
        Graph<TVertex, int>,
        IGraph<AdjacencyListSimplified<TVertex>>,
        ISimplified
    {
        public new AdjacencyListSimplified<TVertex> AdjacencyList { get; }

        public GraphSimplified()
        {
        }

        public GraphSimplified(AdjacencyListSimplified<TVertex> adjacencyList) : base(adjacencyList)
        {
        }

        public GraphSimplified(GraphSimplified<TVertex> graph) : base(graph)
        {
        }

        public void AddDirectedEdge(TVertex @from, TVertex to) {
            AdjacencyList.AddDirectedEdge(@from, to);
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to) {
            AdjacencyList.AddUndirectedEdge(@from, to);
        }

        public List<TVertex> GetShortestPathDijkstra(TVertex start, TVertex finish)
        {
            var done1 = new Dictionary<TVertex, bool>();
            foreach (TVertex i in AdjacencyList) {
                done1.Add(i, false);
            }
            var parent1 = new Dictionary<TVertex, TVertex>();
            foreach (TVertex i in AdjacencyList) {
                parent1[i] = default(TVertex);
            }
            var distances1 = new Dictionary<TVertex, int>();
            foreach (TVertex i in AdjacencyList) {
                distances1[i] = int.MaxValue;
            }
            distances1[start] = 0;
            return GetShortestPathDijkstra(start, finish, done1, parent1, distances1, AdjacencyList);
        }

        private List<TVertex> GetShortestPathDijkstra(TVertex start, TVertex finish, Dictionary<TVertex, bool> done, 
            Dictionary<TVertex, TVertex> parent, Dictionary<TVertex, int> distances, IAdjacencyList<TVertex, int> adjacencyList)
        {
            TVertex current = start;
            while (!done[current]) {
                done[current] = true;
                foreach (TVertex i in adjacencyList) {
                    int dist = adjacencyList[current][i] + distances[current];
                    if (dist < distances[i]) {
                        distances[i] = dist;
                        parent[i] = current;
                    }
                }
                int min = int.MaxValue;
                foreach (TVertex i in adjacencyList) {
                    if (distances[i] < min && !done[i]) {
                        current = i;
                        min = distances[i];
                    }
                }
            }
            var tmp = finish;
            var result = new List<TVertex>();
            while (!tmp.Equals(start))
            {
                result.Add(tmp);
                tmp = parent[tmp];
            }
            result.Add(tmp);
            result.Reverse();
            return result;
        }
    }
}