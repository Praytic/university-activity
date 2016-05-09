using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using graph.DataStructure;

namespace graph.Storages.Implementation
{
    public class AdjacencyList :
        AdjacencyList<int, int>
    {
        public AdjacencyList()
        {
        }

        public AdjacencyList(int[] vertices) : base(vertices) {
        }

        public AdjacencyList(Dictionary<int, Dictionary<int, int>> storage) : base(storage)
        {
        }

        public AdjacencyList(IStorage<int, Dictionary<int, Dictionary<int, int>>> storage) : base(storage)
        {
        }

        public AdjacencyList(IAdjacencyList<int, int> adjacencyList) : base(adjacencyList)
        {
        }
    }

    public class AdjacencyList<TVertex> :
        AdjacencyList<TVertex, int>
    {
        public AdjacencyList()
        {
        }

        public AdjacencyList(TVertex[] vertices) : base(vertices) {
        }

        public AdjacencyList(Dictionary<TVertex, Dictionary<TVertex, int>> storage) : base(storage)
        {
        }

        public AdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, int>>> storage) : base(storage)
        {
        }

        public AdjacencyList(IAdjacencyList<TVertex, int> adjacencyList) : base(adjacencyList)
        {
        }
    }

    public class AdjacencyList<TVertex, TWeight> :
        IAdjacencyList<TVertex, TWeight> 
        where TWeight : IComparable 
    {
#region Fields

        public int Count {
            get { return Storage.Count; }
        }

        public bool IsReadOnly { get; }

        public Dictionary<TVertex, Dictionary<TVertex, TWeight>> Storage { get; }

        public Dictionary<TVertex, TWeight> this[TVertex key]
        {
            get { return Storage[key]; }
            set { Storage[key] = value; }
        }

#endregion

#region Constructors

        public AdjacencyList() {
            Storage = new Dictionary<TVertex, Dictionary<TVertex, TWeight>>();
        }

        public AdjacencyList(TVertex[] vertices) {
            var storage = new Dictionary<TVertex, Dictionary<TVertex, TWeight>>();
            foreach (var vertex in vertices)
            {
                storage.Add(vertex, new Dictionary<TVertex, TWeight>());
            }
        }

        public AdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
        {
            Storage = storage;
        }

        public AdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) {
            Storage = storage.Storage;
        }

        public AdjacencyList(IAdjacencyList<TVertex, TWeight> adjacencyList) {
            Storage = adjacencyList.Storage;
        }

#endregion

#region Implemented Methods

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

#endregion

#region Overriden Methods

        public override string ToString() {
            StringBuilder matrix = new StringBuilder();
            foreach (var elementRow in this) {
                matrix.Append(string.Format("{0, 20} | ", elementRow));
                foreach (var elementColumn in this[elementRow]) {
                    matrix.Append(string.Format("{0} ", elementColumn.Value));
                }
                matrix.AppendLine();
            }
            return matrix.ToString();
        }

#endregion
    }
}