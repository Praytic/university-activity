using System;
using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.DataStructure
{
    public class DataStructureFactory
    {
        #region CreateAdjacencyMatrix

        public IAdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>()
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return (IAdjacencyMatrix<TVertex, TWeight>) new AdjacencyMatrixSimplified<TVertex>();
            }
            return new AdjacencyMatrix<TVertex, TWeight>();
        }

        public IAdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return (IAdjacencyMatrix<TVertex, TWeight>) new AdjacencyMatrixSimplified<TVertex>(schema);
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IAdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(Dictionary<TVertex, int> schema)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return (IAdjacencyMatrix<TVertex, TWeight>) new AdjacencyMatrixSimplified<TVertex>(schema);
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IAdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema, TWeight[,] matrix)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return
                    (IAdjacencyMatrix<TVertex, TWeight>)
                        new AdjacencyMatrixSimplified<TVertex>(schema, matrix as int[,]);
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema, matrix);
        }

        public IAdjacencyMatrix<TVertex, TWeight>
            CreateAdjacencyMatrix<TVertex, TWeight>(IAdjacencyMatrix<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return
                    (IAdjacencyMatrix<TVertex, TWeight>)
                        new AdjacencyMatrixSimplified<TVertex>(storage as AdjacencyMatrix<TVertex, int>);
            }
            return new AdjacencyMatrix<TVertex, TWeight>(storage);
        }

        #endregion

        #region CreateAdjacencyList

        public IAdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>()
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return (IAdjacencyList<TVertex, TWeight>) new AdjacencyListSimplified<TVertex>();
            }
            return new AdjacencyList<TVertex, TWeight>();
        }

        public IAdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return
                    (IAdjacencyList<TVertex, TWeight>)
                        new AdjacencyListSimplified<TVertex>(storage as Dictionary<TVertex, Dictionary<TVertex, int>>);
            }
            return new AdjacencyList<TVertex, TWeight>(storage);
        }

        public IAdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
            where TWeight : IComparable
        {
            if (typeof (TWeight) == typeof (int))
            {
                return
                    (IAdjacencyList<TVertex, TWeight>)
                        new AdjacencyListSimplified<TVertex>(storage as AdjacencyList<TVertex, int>);
            }
            return new AdjacencyList<TVertex, TWeight>(storage);
        }

        #endregion

        #region CreateGraph

        public IGraph<TVertex, TWeight>
            CreateGraphAdjacencyList<TVertex, TWeight>()
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return (IGraph<TVertex, TWeight>)new GraphAdjacencyMatrixSimplified<TVertex>();
            }
            return new GraphAdjacencyMatrix<TVertex, TWeight>();
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(TVertex[] schema)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return (IGraph<TVertex, TWeight>)new GraphAdjacencyMatrixSimplified<TVertex>(schema);
            }
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(Dictionary<TVertex, int> schema)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return (IGraph<TVertex, TWeight>)new GraphAdjacencyMatrixSimplified<TVertex>(schema);
            }
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(TVertex[] schema, TWeight[,] matrix)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return
                    (IGraph<TVertex, TWeight>)
                        new GraphAdjacencyMatrixSimplified<TVertex>(schema, matrix as int[,]);
            }
            return new GraphAdjacencyMatrix<TVertex, TWeight>(schema, matrix);
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(IAdjacencyMatrix<TVertex, TWeight> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return
                    (IGraph<TVertex, TWeight>)
                        new GraphAdjacencyMatrixSimplified<TVertex>((GraphAdjacencyMatrix<TVertex, int>)storage);
            }
            return new GraphAdjacencyMatrix<TVertex, TWeight>(storage);
        }

        public IGraph<TVertex, TWeight>
            CreateGraphAdjacencyMatrix<TVertex, TWeight>()
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return (IGraph<TVertex, TWeight>)new GraphAdjacencyListSimplified<TVertex>();
            }
            return new GraphAdjacencyList<TVertex, TWeight>();
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return
                    (IGraph<TVertex, TWeight>)
                        new GraphAdjacencyListSimplified<TVertex>(storage as Dictionary<TVertex, Dictionary<TVertex, int>>);
            }
            return new GraphAdjacencyList<TVertex, TWeight>(storage);
        }

        public IGraph<TVertex, TWeight>
            CreateGraph<TVertex, TWeight>(IAdjacencyList<TVertex, TWeight> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return
                    (IGraph<TVertex, TWeight>)
                        new GraphAdjacencyListSimplified<TVertex>(storage as AdjacencyList<TVertex, int>);
            }
            return new GraphAdjacencyList<TVertex, TWeight>(storage);
        }

        #endregion
    }
}