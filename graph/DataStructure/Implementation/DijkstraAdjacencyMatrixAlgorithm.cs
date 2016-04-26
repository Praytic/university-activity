using System;
using System.Collections.Generic;

namespace graph.DataStructure.Implementation {
    public class DijkstraAdjacencyMatrixAlgorithm<TVertex> :
        AlgorithmContract<GraphAdjacencyMatrixSimplified<TVertex>>
    {
        public TVertex Start { get; private set; }
        public TVertex Finish { get; private set; }
        public Dictionary<TVertex, bool> done1;
        public Dictionary<TVertex, TVertex> parent1;
        public Dictionary<TVertex, int> distances1;
        
        public DijkstraAdjacencyMatrixAlgorithm(GraphAdjacencyMatrixSimplified<TVertex> graph, TVertex start, TVertex finish)
        {
            Start = start;
            Finish = finish;
            Graph = graph;

            done1 = new Dictionary<TVertex, bool>();
            foreach (var i in Graph) {
                done1.Add(i, false);
            }
            parent1 = new Dictionary<TVertex, TVertex>();
            foreach (var i in Graph) {
                parent1[i] = default(TVertex);
            }
            distances1 = new Dictionary<TVertex, int>();
            foreach (var i in Graph) {
                distances1[i] = int.MaxValue;
            }
            distances1[start] = 0;
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
                return new List<TValue>();
            }
            foreach (var i in adjacencyMatrix.Schema.Keys) {
                if (adjacencyMatrix[finish, i] != 0) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                return new List<TValue>();
            }
            var done1 = done;
            var parent1 = parent;
            var distances1 = distances;
            TValue current = start;
            while (!done1[current]) {
                done1[current] = true;
                foreach (var i in adjacencyMatrix.Schema.Keys) {
                    if (adjacencyMatrix[current, i] != int.MaxValue && adjacencyMatrix[current, i] != 0) {
                        int dist = adjacencyMatrix[current, i] + distances1[current];
                        if (dist < distances1[i]) {
                            distances1[i] = dist;
                            parent1[i] = current;
                        }
                    }
                }
                int min = int.MaxValue;
                foreach (var i in adjacencyMatrix.Schema.Keys) {
                    if (distances1[i] < min && !done1[i]) {
                        current = i;
                        min = distances1[i];
                    }
                }
            }
            var tmp = finish;
            var result = new List<TValue>();
            while (!tmp.Equals(start)) {
                result.Add(tmp);
                tmp = parent1[tmp];
            }
            result.Add(tmp);
            result.Reverse();
            return result;
        }
    }
}