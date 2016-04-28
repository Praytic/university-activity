using System;
using System.Collections.Generic;
using graph.DataStructure.Implementation;

namespace graph.DataStructure {
    public class DataStructureFactory {
        public IDataStructure<TVertex, List<List<TWeight>>>
            CreateAdjacencyMatrix<TVertex, TWeight>()
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyMatrixSimplified<TVertex>() as AdjacencyMatrix<TVertex, TWeight>;
            }
            return new AdjacencyMatrix<TVertex, TWeight>();
        }

        public IDataStructure<TVertex, List<List<TWeight>>>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyMatrixSimplified<TVertex>(schema) as AdjacencyMatrix<TVertex, TWeight>;
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IDataStructure<TVertex, List<List<TWeight>>>
            CreateAdjacencyMatrix<TVertex, TWeight>(Dictionary<TVertex, int> schema)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyMatrixSimplified<TVertex>(schema) as AdjacencyMatrix<TVertex, TWeight>;
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema);
        }

        public IDataStructure<TVertex, List<List<TWeight>>>
            CreateAdjacencyMatrix<TVertex, TWeight>(TVertex[] schema, TWeight[,] matrix)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyMatrixSimplified<TVertex>(schema, matrix as int[,]) as AdjacencyMatrix<TVertex, TWeight>;
            }
            return new AdjacencyMatrix<TVertex, TWeight>(schema, matrix);
        }

        public IDataStructure<TVertex, List<List<TWeight>>>
            CreateAdjacencyMatrix<TVertex, TWeight>(AdjacencyMatrix<TVertex, TWeight> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyMatrixSimplified<TVertex>(storage as AdjacencyMatrix<TVertex, int>) as AdjacencyMatrix<TVertex, TWeight>;
            }
            return new AdjacencyMatrix<TVertex, TWeight>(storage);
        }

        public IDataStructure<TVertex, >
            CreateAdjacencyList<TVertex, TWeight>()
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyListSimplified<TVertex>() as AdjacencyList<TVertex, TWeight>;
            }
            return new AdjacencyList<TVertex, TWeight>();
        }

        public AdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(Dictionary<TVertex, Dictionary<TVertex, TWeight>> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyListSimplified<TVertex>(storage as Dictionary<TVertex, Dictionary<TVertex, int>>) as AdjacencyList<TVertex, TWeight>;
            }
            return new AdjacencyList<TVertex, TWeight>(storage);
        }

        public AdjacencyList<TVertex, TWeight>
            CreateAdjacencyList<TVertex, TWeight>(AdjacencyList<TVertex, TWeight> storage)
            where TWeight : IComparable {
            if (typeof(TWeight) == typeof(int)) {
                return new AdjacencyListSimplified<TVertex>(storage as AdjacencyList<TVertex, int>) as AdjacencyList<TVertex, TWeight>;
            }
            return new AdjacencyList<TVertex, TWeight>(storage);
        }
        
    }
}