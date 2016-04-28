using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation {

    public class FloydShortestPathAdjacencyMatrix<TVertex> :
        FloydShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex> {

        public FloydShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish) {
        }

        public override void Run()
        {
            Result = new AdjacencyMatrix<TVertex, int>(Graph.Schema);
            int count = 0;
            foreach (var i in Graph)
            {
                foreach (var j in Graph) {
                    if (Graph[i, j] != 0 && Graph[i, j] != int.MaxValue) {
                        Result[i, j] = count;
                    } else {
                        Result[i, j] = -1;
                    }
                }
                count++;
            }

            foreach (var k in Graph)
            {
                foreach (var i in Graph)
                {
                    foreach (var j in Graph)
                    {
                        if (Graph[i, k] == int.MaxValue || Graph[k, j] == int.MaxValue)
                        {
                            continue;
                        }

                        if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                        {
                            Graph[i, j] = Graph[i, k] + Graph[k, j];
                            Result[i, j] = Result[k, j];
                        }
                    }
                }
            }
        }
    }
}