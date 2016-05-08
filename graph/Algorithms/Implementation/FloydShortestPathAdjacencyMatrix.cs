using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyMatrix<TVertex> :
        FloydShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public Matrix<TVertex, TVertex> Vert { get; }

        public FloydShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish)
            : base(graph, start, finish)
        {
            Vert = new Matrix<TVertex, TVertex>(Graph.Schema);
            Result = new List<TVertex>();
        }

        public override void Run()
        {
            var a = new Matrix<TVertex, int>(Graph.Schema);
            var p = new Matrix<int, int>(Graph.Schema.Values.ToArray());
            foreach (var i in Graph)
            {
                foreach (var j in Graph)
                {
                    if (Equals(i, j))
                    {
                        a[i, j] = 0;
                    }
                    else
                    {
                        if (Graph[i, j] == 0)
                        {
                            a[i, j] = int.MaxValue;
                        }
                        else
                        {
                            a[i, j] = Graph[i, j];
                        }
                    }
                    p[Graph.Schema[i], Graph.Schema[j]] = -1;
                }
            }

            foreach (var k in Graph)
            {
                foreach (var i in Graph)
                {
                    foreach (var j in Graph)
                    {
                        int distance = a[i, j] + a[k, j];
                        if (a[i, j] > distance)
                        {
                            a[i, j] = distance;
                            p[Graph.Schema[i], Graph.Schema[j]] = Graph.Schema[k];
                        }
                    }
                }
            }
            
            Queue lol = new Queue();
            lol.Enqueue(Start);
            ExecutePath(Start, Finish, p, ref lol);
            lol.Enqueue(Finish);
            Result = lol.ToArray().ToList();
        }

        private void ExecutePath(TVertex i, TVertex j, Matrix<int, int> p, ref Queue lol)
        {
            int k = p[Graph.Schema[i], Graph.Schema[j]];
            if (k != -1) {
                ExecutePath(i, Graph.Schema.ToDictionary(x => x.Value, x => x.Key)[k], p, ref lol);
                lol.Enqueue(Graph.Schema.ToDictionary(x => x.Value, x => x.Key)[k]);
                ExecutePath(Graph.Schema.ToDictionary(x => x.Value, x => x.Key)[k], j, p, ref lol);
            }
        }
    }
}