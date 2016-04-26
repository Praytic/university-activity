using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace graph.DataStructure.Implementation
{
    public class AdjacencyList<TVertex, TWeight> :
        IAdjacency<TVertex, TWeight>,
        IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> 
        where TWeight : IComparable 
    {

        Dictionary<TVertex, TWeight> this[TVertex i]
        {
            get { return Storage[i]; }
            set { Storage[i] = value; }
        }

        public int Count {
            get { return Storage.Count; }
        }

        public bool IsReadOnly { get; }

        public Dictionary<TVertex, Dictionary<TVertex, TWeight>> Storage { get; }

        public AdjacencyList() {
            Storage = new Dictionary<TVertex, Dictionary<TVertex, TWeight>>();
        }

        public AdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
        {
            Storage = storage;
        }

        public AdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) {
            Storage = storage.Storage;
        }

        public void Add(TVertex item) {
            Storage.Add(item, new Dictionary<TVertex, TWeight>());
        }

        public void AddDirectedEdge(TVertex from, TVertex to, TWeight weight) {
            Storage[from].Add(to, weight);
        }

        public void AddUndirectedEdge(TVertex from, TVertex to, TWeight weight) {
            Storage[from].Add(to, weight);
            Storage[to].Add(from, weight);
        }

        public void Clear() {
            Storage.Clear();
        }

        public bool Contains(TVertex item) {
            return Storage.ContainsKey(item);
        }

        public void CopyTo(TVertex[] array, int arrayIndex) {
            Storage.Keys.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return Storage.Keys.GetEnumerator();
        }

        public TVertex GetFirstVertex() {
            return Storage.First().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex) {
            var keysCollection = Storage.Keys;
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

        public bool Remove(TVertex item)
        {
            return Storage.Remove(item);
        }

        public void RemoveEdge(TVertex from, TVertex to) {
            Storage[from].Remove(to);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Storage.GetEnumerator();
        }
    }
}