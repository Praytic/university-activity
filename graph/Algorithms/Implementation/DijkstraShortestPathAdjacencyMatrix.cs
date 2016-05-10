﻿using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation {
    public class DijkstraShortestPathAdjacencyMatrix<TVertex> :
        DijkstraShortestPath<GraphAdjacencyMatrix<TVertex, int>, TVertex>
    {
        public DijkstraShortestPathAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, int> graph, TVertex start, TVertex finish) : base(graph, start, finish) {
            Result = new List<TVertex>();
            Done = new Dictionary<TVertex, bool>();
            foreach (var i in Graph) {
                Done.Add(i, false);
            }
            ParentIds = new Dictionary<int, int>();
            foreach (var i in Graph) {
                ParentIds[Graph.Scheme[i]] = -1;
            }
            Distances = new Dictionary<TVertex, int>();
            foreach (var i in Graph) {
                Distances[i] = int.MaxValue;
            }
            Distances[start] = 0;
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
                            ParentIds[Graph.Scheme[i]] = Graph.Scheme[current];
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
            if (ParentIds[Graph.Scheme[Finish]] == -1)
            {
                return;
            }
            var tmp = Graph.Scheme[Finish];
            while (tmp != Graph.Scheme[Start] || tmp == -1) {
                Result.Add(Graph.Scheme[tmp]);
                tmp = ParentIds[tmp];
            }
            Result.Add(Graph.Scheme[tmp]);
            Result.Reverse();
        }
    }
}