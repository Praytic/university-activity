using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace graph.DataStructure.Implementation {
    public class AdjacencyMatrix<TVertex, TWeight> :
        IAdjacency<TVertex, TWeight>,
        IStorage<TVertex, List<List<TWeight>>>
        where TWeight : IComparable 
    {
        public int Count
        {
            get { return Schema.Count; }
        }

        public bool IsReadOnly { get; }

        public List<List<TWeight>> Storage { get; }

        private Dictionary<TVertex, int> Schema { get; } 

        public TWeight this[TVertex i, TVertex j] {
            get { return Storage[Schema[i]][Schema[j]]; }
            set { Storage[Schema[i]][Schema[j]] = value; }
        }

        public AdjacencyMatrix()
        {
            Storage = new List<List<TWeight>>();
            Schema = new Dictionary<TVertex, int>();
        }

        public AdjacencyMatrix(TVertex[] schema) {
            Schema = new Dictionary<TVertex, int>();
            Storage = new List<List<TWeight>>();
            foreach (var element in schema) {
                Schema.Add(element, Count);
                var newRow = new List<TWeight>();
                foreach (var i in schema)
                {
                    newRow.Add(default(TWeight));
                }
                Storage.Add(newRow);
            }
        }

        public AdjacencyMatrix(Dictionary<TVertex, int> schema) {
            Schema = schema;
            Storage = new List<List<TWeight>>();
            foreach (var i in schema) {
                var newRow = new List<TWeight>();
                foreach (var j in schema) {
                    newRow.Add(default(TWeight));
                }
                Storage.Add(newRow);
            }
        }

        public AdjacencyMatrix(TVertex[] schema, TWeight[,] matrix) {
            Schema = new Dictionary<TVertex, int>();
            foreach (var element in schema) {
                Schema.Add(element, Count);
            }
            Storage = new List<List<TWeight>>();
            for (int i = 0; i < Count; i++) {
                var newRow = new List<TWeight>();
                for (int j = 0; j < Count; j++) {
                    newRow.Add(matrix[i, j]);
                }
                Storage.Add(newRow);
            }
        }


        public void AddDirectedEdge(TVertex @from, TVertex to, TWeight weight)
        {
            this[@from, to] = weight;
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to, TWeight weight) {
            this[@from, to] = weight;
            this[to, @from] = weight;
        }

        public void RemoveEdge(TVertex @from, TVertex to)
        {
            this[@from, to] = default(TWeight);
        }

        public TVertex GetFirstVertex()
        {
            return Schema.First().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex)
        {
            var keysCollection = Schema.Keys;
            bool isNextVertex = false;
            foreach (var key in keysCollection) {
                if (isNextVertex) {
                    return key;
                }
                if (key.Equals(currentVertex)) {
                    isNextVertex = true;
                }
            }
            return default(TVertex);
        }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return Schema.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Storage.GetEnumerator();
        }

        public void Add(TVertex item)
        {
            Schema.Add(item, Count);
            foreach (var row in Storage)
            {
                row.Add(default(TWeight));
            }
            var newRow = new List<TWeight>();
            for (int i = 0; i <= Count; i++)
            {
                newRow.Add(default(TWeight));
            }
            Storage.Add(newRow);
        }

        public void Clear()
        {
            Storage.Clear();
            Schema.Clear();
        }

        public bool Contains(TVertex item)
        {
            return Schema.ContainsKey(item);
        }

        public void CopyTo(TVertex[] array, int arrayIndex)
        {
            Schema.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(TVertex item)
        {
            if (Schema.ContainsKey(item))
            {
                var lastElement = Schema.Last();
                foreach (var vertex in this)
                {
                    this[vertex, item] = this[vertex, lastElement.Key];
                    this[item, vertex] = this[lastElement.Key, vertex];
                    Remove(lastElement.Key);
                }
                Storage.RemoveAt(lastElement.Value);
                Schema[Schema.Last().Key] = Schema[item];
                Schema.Remove(lastElement.Key);
                return true;
            }
            return false;
        }
    }
}