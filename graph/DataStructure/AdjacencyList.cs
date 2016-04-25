using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace graph.DataStructure
{
    public class AdjacencyList<TVertex, TWeight> : 
        IAdjacencyList<TVertex, TWeight>
        where TWeight : IComparable
    {
        public Dictionary<TVertex, Dictionary<TVertex, TWeight>> List { get; protected set; }

        public int Count
        {
            get { return List.Count; }
        }

        public bool IsReadOnly { get; protected set; }

        public Dictionary<TVertex, TWeight> this[TVertex i]
        {
            get { return List[i]; }
            set { List[i] = value; }
        } 

        public AdjacencyList()
        {
            List = new Dictionary<TVertex, Dictionary<TVertex, TWeight>>();
        }

        public AdjacencyList(IAdjacencyList<TVertex, TWeight> adjacencyList)
        {
            List = adjacencyList.List;
        }

        public void AddDirectedEdge(TVertex @from, TVertex to, TWeight weight)
        {
            List[@from].Add(to, weight);
        }

        public void AddUndirectedEdge(TVertex @from, TVertex to, TWeight weight) {
            List[@from].Add(to, weight);
            List[to].Add(@from, weight);
        }

        public void RemoveEdge(TVertex @from, TVertex to)
        {
            List[@from].Remove(to);
        }

        public TVertex GetFirstVertex()
        {
            return List.First().Key;
        }

        public TVertex GetNextVertex(TVertex currentVertex)
        {
            var keysCollection = List.Keys;
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
            return List.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.Keys.GetEnumerator();
        }

        public void Add(TVertex item)
        {
            List.Add(item, new Dictionary<TVertex, TWeight>());
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(TVertex item)
        {
            return List.ContainsKey(item);
        }

        public void CopyTo(TVertex[] array, int arrayIndex)
        {
            List.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(TVertex item)
        {
            foreach (var vertexes in List)
            {
                foreach (var vertex in vertexes.Value.Keys)
                {
                    if (vertex.Equals(item))
                    {
                        List[vertexes.Key].Remove(vertex);
                    }
                }
            }
            return List.Remove(item);
        }
    }
}