using System;
using System.Collections.Generic;
using graph.DataStructure;

namespace graph.Storages.Implementation
{
    public class GraphAdjacencyList :
        GraphAdjacencyList<int, int>
    {
        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(int[] vertices) : base(vertices)
        {
        }

        public GraphAdjacencyList(Dictionary<int, Dictionary<int, int>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IAdjacencyList<int, int> adjacencyList) : base(adjacencyList)
        {
        }

        public GraphAdjacencyList(IStorage<int, Dictionary<int, Dictionary<int, int>>> storage) : base(storage)
        {
        }
    }

    public class GraphAdjacencyList<TVertex> :
        GraphAdjacencyList<TVertex, int>
    {
        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(TVertex[] vertices) : base(vertices)
        {
        }

        public GraphAdjacencyList(Dictionary<TVertex, Dictionary<TVertex, int>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IAdjacencyList<TVertex, int> adjacencyList) : base(adjacencyList)
        {
        }

        public GraphAdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, int>>> storage) : base(storage)
        {
        }
    }

    public class GraphAdjacencyList<TVertex, TWeight> :
        AdjacencyList<TVertex, TWeight>,
        IGraph<TVertex, TWeight>
        where TWeight : IComparable 
    {
        public ICollection<TVertex> Vertices
        {
            get { return Storage.Keys; }
        }

        public GraphAdjacencyList()
        {
        }

        public GraphAdjacencyList(TVertex[] vertices) : base(vertices)
        {
        }

        public GraphAdjacencyList(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage) : base(storage)
        {
        }

        public GraphAdjacencyList(IAdjacencyList<TVertex, TWeight> adjacencyList) : base(adjacencyList)
        {
        }

        public GraphAdjacencyList(IStorage<TVertex, Dictionary<TVertex, Dictionary<TVertex, TWeight>>> storage) : base(storage)
        {
        }
    }
}