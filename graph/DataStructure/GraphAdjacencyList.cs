using System;
using System.Collections;
using System.Collections.Generic;

namespace graph.DataStructure
{
    public class Graph<TVertex, TWeight> : 
        IAdjacency<TVertex, TWeight>, 
        ICollection<TVertex>,
        IGraph<AdjacencyList<TVertex, TWeight>> 
        where TWeight : IComparable 
    {
        public int Count
        {
            get { return AdjacencyList.Count; }
        }

        public bool IsReadOnly { get; protected set; }
        
        public AdjacencyList<TVertex, TWeight> AdjacencyList { get; protected set; }

        public Graph() {
            AdjacencyList = new AdjacencyList<TVertex, TWeight>();
        }

        public Graph(AdjacencyList<TVertex, TWeight> adjacencyList) {
            AdjacencyList = adjacencyList;
        }

        public Graph(Graph<TVertex, TWeight> graph)
        {
            AdjacencyList = graph.AdjacencyList;
        } 

        public void Add(TVertex value) {
            AdjacencyList.Add(value);
        }

        public void Clear()
        {
            AdjacencyList.Clear();
        }

        public void AddDirectedEdge(TVertex @from, TVertex @to, TWeight weight) {
            AdjacencyList.AddDirectedEdge(@from, @to, weight);
        }

        public void AddUndirectedEdge(TVertex @from, TVertex @to, TWeight weight) {
            AdjacencyList.AddUndirectedEdge(@from, @to, weight);
        }

        public void RemoveEdge(TVertex @from, TVertex @to)
        {
            AdjacencyList.RemoveEdge(@from, @to);
        }

        public bool Contains(TVertex value) {
            return AdjacencyList.Contains(value);
        }

        public void CopyTo(TVertex[] array, int arrayIndex)
        {
            AdjacencyList.CopyTo(array, arrayIndex);
        }

        public bool Remove(TVertex value) {
            return AdjacencyList.Remove(value);
        }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return AdjacencyList.GetEnumerator();
        }

        public override string ToString() {
            return AdjacencyList.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return AdjacencyList.GetEnumerator();
        }

        public TVertex GetFirstVertex()
        {
            return AdjacencyList.GetFirstVertex();
        }

        public TVertex GetNextVertex(TVertex currentVertex) {
            return AdjacencyList.GetNextVertex(currentVertex);
        }
    }
}