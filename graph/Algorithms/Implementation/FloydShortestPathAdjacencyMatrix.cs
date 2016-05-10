using System;
using System.Collections.Generic;
using System.Linq;
using graph.Storages;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class FloydShortestPathAdjacencyMatrix<TVertex> :
        FloydShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public IMatrix<int, int> ParentIds { get; set; }

        public FloydShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish)
            : base(graph, start, finish) {
            ParentIds = new Matrix(Graph.VerticesIds);
            Result = new List<TVertex>();
            Distances = new Matrix<TVertex, long>(Graph.Vertices);
        }

        public override void Run()
        {
            foreach (TVertex i in Graph.Scheme) {
                foreach (TVertex j in Graph.Scheme) {
                    if (Equals(i, j)) {
                        Distances[i, j] = 0;
                    } else {
                        if (Graph[i, j] == 0) {
                            Distances[i, j] = int.MaxValue;
                        } else {
                            Distances[i, j] = Graph[i, j];
                        }
                    }
                    ParentIds[Graph.Scheme[i], Graph.Scheme[j]] = -1;
                }
            }
            foreach (TVertex k in Graph.Scheme) {
                foreach (TVertex i in Graph.Scheme) {
                    foreach (TVertex j in Graph.Scheme) {
                        long distance = Distances[i, k] + Distances[k, j];
                        if (Distances[i, j] > distance) {
                            Distances[i, j] = distance;
                            ParentIds[Graph.Scheme[i], Graph.Scheme[j]] = Graph.Scheme[k];
                        }
                    }
                }
            }
            Result.Add(Start);
            ExecutePath(Start, Finish, ParentIds);
            Result.Add(Finish);
            Result = Result.ToArray().ToList();
        }

        private void ExecutePath(TVertex i, TVertex j, IMatrix<int, int> p)
        {
            int k = p[Graph.Scheme[i], Graph.Scheme[j]];
            if (k != -1) {
                ExecutePath(i, Graph.Scheme[k], p);
                Result.Add(Graph.Scheme[k]);
                ExecutePath(Graph.Scheme[k], j, p);
            }
        }
    }
}