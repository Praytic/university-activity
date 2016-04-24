using System.Collections.Generic;

namespace graph.DataStructure {

    public class GraphSimple<TValue> : Graph<TValue, int> {

        public GraphSimple()
        {
        }

        public GraphSimple(AdjacencyMatrix<TValue, int> adjacencyMatrix) : base(adjacencyMatrix)
        {
        }

        public GraphSimple(Graph<TValue, int> graph) : base(graph)
        {
        }

        public List<List<TValue>> GetAllPaths(TValue start, TValue finish)
        {
            var result = new List<List<TValue>>();
            var adjacencyMatrix = AdjacencyMatrix;
            while (true)
            {
                var done1 = new Dictionary<TValue, bool>();
                foreach (var i in AdjacencyMatrix.Schema.Keys) {
                    done1.Add(i, false);
                }
                var parent1 = new Dictionary<TValue, TValue>();
                foreach (var i in AdjacencyMatrix.Schema.Keys) {
                    parent1[i] = default(TValue);
                }
                var distances1 = new Dictionary<TValue, int>();
                foreach (var i in AdjacencyMatrix.Schema.Keys) {
                    distances1[i] = int.MaxValue;
                }
                distances1[start] = 0;
                var shortestPath = GetShortestPath(start, finish, done1, parent1, distances1, adjacencyMatrix);
                if (shortestPath.Count > 0)
                {
                    result.Add(shortestPath);
                    var previousVertex = start;
                    for (int i = 0; i < shortestPath.Count; i++)
                    {
                        adjacencyMatrix[previousVertex, shortestPath[i]] = 0;
                        previousVertex = shortestPath[i];
                    }
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public List<TValue> GetShortestPath(TValue start, TValue finish)
        {
            var done1 = new Dictionary<TValue, bool>();
            foreach (var i in AdjacencyMatrix.Schema.Keys) {
                done1.Add(i, false);
            }
            var parent1 = new Dictionary<TValue, TValue>();
            foreach (var i in AdjacencyMatrix.Schema.Keys) {
                parent1[i] = default(TValue);
            }
            var distances1 = new Dictionary<TValue, int>();
            foreach (var i in AdjacencyMatrix.Schema.Keys) {
                distances1[i] = int.MaxValue;
            }
            distances1[start] = 0;
            return GetShortestPath(start, finish, done1, parent1, distances1, AdjacencyMatrix);
        }

        private List<TValue> GetShortestPath(TValue start, TValue finish, Dictionary<TValue, bool> done, 
            Dictionary<TValue, TValue> parent, Dictionary<TValue, int> distances, IMatrix<TValue, int> adjacencyMatrix)
        {
            bool flag = false;
            foreach (var i in adjacencyMatrix.Schema.Keys)
            {
                if (adjacencyMatrix[start, i] != 0)
                {
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
            if (!flag)
            {
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
            while (!tmp.Equals(start))
            {
                result.Add(tmp);
                tmp = parent1[tmp];
            }
            result.Add(tmp);
            result.Reverse();
            return result;
        }
    }
}