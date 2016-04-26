﻿using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.Algorithms.Implementation {
    public class DijkstraAdjacencyMatrixAlgorithm<TVertex> :
        DijkstraAlgorithm<GraphAdjacencyMatrixSimplified<TVertex>, TVertex>
    {
        public DijkstraAdjacencyMatrixAlgorithm(GraphAdjacencyMatrixSimplified<TVertex> graph, TVertex start, TVertex finish) : base(graph, start, finish)
        {
        }

        public override void Run()
        {
            bool flag = false;
            foreach (var i in Graph) {
                if (Graph[Start, i] != 0) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                Result = new List<TVertex>();
                return;
            }
            foreach (var i in Graph) {
                if (Graph[Finish, i] != 0) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                Result = new List<TVertex>();
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
            Result = new List<TVertex>();
            while (!tmp.Equals(Start)) {
                Result.Add(tmp);
                tmp = Parent[tmp];
            }
            Result.Add(tmp);
            Result.Reverse();
        }
    }
}