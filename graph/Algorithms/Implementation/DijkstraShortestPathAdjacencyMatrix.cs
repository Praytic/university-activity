using System.Collections.Generic;
using System.Linq;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation {
    public class DijkstraShortestPathAdjacencyMatrix<TVertex> :
        DijkstraShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public DijkstraShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            bool flag = false;
            foreach (var i in Graph) {
                if (Graph[Start, i] != 0 || Graph[Finish, i] != 0) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                return;
            }
            TVertex current = Start;
            while (!Done[current]) {
                Done[current] = true;
                foreach (var i in Graph) {
                    if (Graph[current, i] != int.MaxValue && Graph[current, i] != 0) {
                        int dist = Graph[current, i] + Distances[current];
                        if (dist < Distances[i]) {
                            Distances[i] = dist;
                            Parent[i] = current;
                        }
                    }
                }
                int min = int.MaxValue;
                foreach (var i in Graph) {
                    if (Distances[i] < min && !Done[i]) {
                        current = i;
                        min = Distances[i];
                    }
                }
            }
            var tmp = Finish;
            while (!tmp.Equals(Start)) {
                Result.Add(tmp);
                tmp = Parent[tmp];
            }
            Result.Add(tmp);
            Result.Reverse();
        }
    }
}