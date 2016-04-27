using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class DijkstraAdjacencyListAlgorithm<TVertex> :
        DijkstraAlgorithm<GraphAdjacencyListSimplified<TVertex>, TVertex>
    {
        public DijkstraAdjacencyListAlgorithm(GraphAdjacencyListSimplified<TVertex> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            var nodes = new List<TVertex>();

            foreach (var vertex in Graph) {
                if (Equals(vertex, Start)) {
                    Distances[vertex] = 0;
                } else {
                    Distances[vertex] = int.MaxValue;
                }

                nodes.Add(vertex);
            }

            while (nodes.Count != 0) {
                nodes.Sort((x, y) => Distances[x] - Distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (Equals(smallest, Finish)) {
                    Result = new List<TVertex>();
                    while (smallest != null && Parent.ContainsKey(smallest)) {
                        Result.Add(smallest);
                        smallest = Parent[smallest];
                    }

                    break;
                }

                if (Distances[smallest] == int.MaxValue) {
                    break;
                }

                foreach (var neighbor in Graph[smallest]) {
                    var alt = Distances[smallest] + neighbor.Value;
                    if (alt < Distances[neighbor.Key]) {
                        Distances[neighbor.Key] = alt;
                        Parent[neighbor.Key] = smallest;
                    }
                }
            }
            Result.Reverse();
        }
    }
}