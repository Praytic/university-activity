using System;
using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.DataStructure
{
    public class DataStructureFactory
    {
        #region CreateAdjacencyMatrix
        
        public AdjacencyMatrix<TVertex, int>
            CreateAdjacencyMatrix<TVertex>()
        {
            return new AdjacencyMatrix<TVertex, int>();
        }

        public AdjacencyMatrix<TVertex, int>
            CreateAdjacencyMatrix<TVertex>(TVertex[] schema)
        {
            return new AdjacencyMatrix<TVertex, int>(schema);
        }

        public AdjacencyMatrix<TVertex, int>
            CreateAdjacencyMatrix<TVertex>(Dictionary<TVertex, int> schema)
        {
            return new AdjacencyMatrix<TVertex, int>(schema);
        }

        public AdjacencyMatrix<TVertex, int>
            CreateAdjacencyMatrix<TVertex>(TVertex[] schema, int[,] matrix)
        {
            return new AdjacencyMatrix<TVertex, int>(schema, matrix);
        }

        public AdjacencyMatrix<TVertex, int>
            CreateAdjacencyMatrix<TVertex>(AdjacencyMatrix<TVertex, int> storage)
        {
            return new AdjacencyMatrix<TVertex, int>(storage);
        }

        public AdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>()
            where TWeight : IComparable
        {
            return new AdjacencyMatrix<TVertex, TWeight>();
        }

        public AdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema)
            where TWeight : IComparable
        {
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public AdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(Dictionary<TVertex, int> schema)
            where TWeight : IComparable
        {
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public AdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema, TWeight[,] matrix)
            where TWeight : IComparable
        {
            return new AdjacencyMatrix<TVertex, TWeight>(schema, matrix);
        }

        public AdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(AdjacencyMatrix<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            return new AdjacencyMatrix<TVertex, TWeight>(storage);
        }

        #endregion

        #region CreateAdjacencyList

        public AdjacencyList<TVertex, int>
            CreateAdjacencyList<TVertex>()
        {
            return new AdjacencyList<TVertex, int>();
        }

        public AdjacencyList<TVertex, int>
            CreateAdjacencyList<TVertex>(TVertex[] vertexes) {
            var storage = new Dictionary<TVertex, Dictionary<TVertex, int>>();
            foreach (var vertex in vertexes)
            {
                storage.Add(vertex, new Dictionary<TVertex, int>());
            }
            return new AdjacencyList<TVertex, int>(storage);
        }

        public AdjacencyList<TVertex, int>
            CreateAdjacencyList<TVertex>(Dictionary<TVertex, Dictionary<TVertex, int>> storage) 
        { 
            return new AdjacencyList<TVertex, int>(storage);
        }

        public AdjacencyList<TVertex, int>
            CreateAdjacencyList<TVertex>(IAdjacencyList<TVertex, int> storage)
        {
            return new AdjacencyList<TVertex, int>(storage);
        }

        public AdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>()
            where TWeight : IComparable
        {
            return new AdjacencyList<TVertex, TWeight>();
        }

        public AdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
            where TWeight : IComparable
        {
            return new AdjacencyList<TVertex, TWeight>(storage);
        }

        public AdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            return new AdjacencyList<TVertex, TWeight>(storage);
        }

        #endregion

        #region CreateGraph
        
        public GraphAdjacencyList<TVertex, int>
            CreateGraphAdjacencyList<TVertex>()
        {
            return new GraphAdjacencyList<TVertex, int>();
        }

        public GraphAdjacencyList<TVertex, TWeight>
            CreateGraphAdjacencyList<TVertex, TWeight>()
            where TWeight : IComparable
        {
            return new GraphAdjacencyList<TVertex, TWeight>();
        }

        public GraphAdjacencyMatrix<TVertex, int>
            CreateGraph<TVertex>(TVertex[] schema)
        {
            return new GraphAdjacencyMatrix<TVertex, int>(schema);
        }

        public GraphAdjacencyMatrix<TVertex, TWeight>
            CreateGraphAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema)
            where TWeight : IComparable
        {
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public GraphAdjacencyMatrix<TVertex, int>
            CreateGraph<TVertex>(Dictionary<TVertex, int> schema)
        {
            return new GraphAdjacencyMatrix<TVertex, int>(schema);
        }

        public GraphAdjacencyMatrix<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(Dictionary<TVertex, int> schema)
            where TWeight : IComparable
        {
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public GraphAdjacencyMatrix<TVertex, int>
            CreateGraph<TVertex>(TVertex[] schema, int[,] matrix)
        {
            return new GraphAdjacencyMatrix<TVertex, int>(schema, matrix);
        }

        public GraphAdjacencyMatrix<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(TVertex[] schema, TWeight[,] matrix)
            where TWeight : IComparable
        {
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema, matrix);
        }

        public GraphAdjacencyMatrix<TVertex, int>
            CreateGraph<TVertex>(AdjacencyMatrix<TVertex, int> storage)
        {
            return new GraphAdjacencyMatrix<TVertex, int>(storage);
        }

        public GraphAdjacencyMatrix<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(AdjacencyMatrix<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            return new GraphAdjacencyMatrix<TVertex, TWeight>(storage);
        }

        public GraphAdjacencyMatrix<TVertex, int>
            CreateGraphAdjacencyMatrix<TVertex>()
        {
            return new GraphAdjacencyMatrix<TVertex, int>();
        }

        public GraphAdjacencyMatrix<TVertex, TWeight>
            CreateGraphAdjacencyMatrix<TVertex, TWeight>()
            where TWeight : IComparable
        {
            return new GraphAdjacencyMatrix<TVertex, TWeight>();
        }

        public GraphAdjacencyList<TVertex, int>
            CreateGraphAdjacencyList<TVertex>(TVertex[] vertexes) {
            return new GraphAdjacencyList<TVertex, int>(CreateAdjacencyList(vertexes));
        }

        public GraphAdjacencyList<TVertex, int>
            CreateGraph<TVertex>(Dictionary<TVertex, Dictionary<TVertex, int>> storage)
        {
            return new GraphAdjacencyList<TVertex, int>(storage);
        }

        public GraphAdjacencyList<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
            where TWeight : IComparable
        {
            return new GraphAdjacencyList<TVertex, TWeight>(storage);
        }

        public GraphAdjacencyList<TVertex, int>
            CreateGraph<TVertex>(IAdjacencyList<TVertex, int> storage)
        {
            return new GraphAdjacencyList<TVertex, int>(storage);
        }

        public GraphAdjacencyList<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            return new GraphAdjacencyList<TVertex, TWeight>(storage);
        }

        #endregion
    }
}