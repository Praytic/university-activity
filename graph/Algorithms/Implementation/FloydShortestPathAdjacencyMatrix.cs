using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyMatrix<TVertex> :
        FloydShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public FloydShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish)
            : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            Result = new AdjacencyMatrix<TVertex, int>(Graph.Schema);
            foreach (var i in Graph)
            {
                foreach (var j in Graph)
                {
                    if (Graph[i, j] != 0)
                    {
                        Result[i, j] = Graph[i, j];
                    }
                    else
                    {
                        if (!Equals(i, j))
                        {
                            Result[i, j] = int.MaxValue;
                        }
                    }
                }
            }

            foreach (var k in Graph)
            {
                foreach (var i in Graph)
                {
                    foreach (var j in Graph)
                    {
                        if (Result[i, j] > Result[i, k] + Result[k, j])
                        {
                            Result[i, j] = Result[i, k] + Result[k, j];
                        }
                    }
                }
            }
        }
    }
}