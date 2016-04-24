using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.DataStructure
{
    public class AdjacencyMatrix<TValue, TWeight> : IMatrix<TValue, TWeight>, IAdjacency<TValue, TWeight>
    {
        public int Count
        {
            get { return Schema.Count; }
        }

        public bool IsReadOnly { get; protected set; }

        public Dictionary<TValue, int> Schema { get; protected set; }

        public TWeight[,] Matrix { get; protected set; }

        public AdjacencyMatrix()
        {
            Schema = new Dictionary<TValue, int>();
            Matrix = new TWeight[0, 0];
        }

        public AdjacencyMatrix(TValue[] schema, TWeight[,] matrix) {
            Schema = new Dictionary<TValue, int>();
            foreach (var element in schema) {
                Schema.Add(element, Count);
            }
            Matrix = matrix;
        }

        public TWeight this[TValue i, TValue j]
        {
            get { return Matrix[Schema[i], Schema[j]]; }
            set { Matrix[Schema[i], Schema[j]] = value; }
        }

        public void Clear()
        {
            Schema.Clear();
            Matrix = new TWeight[0, 0];
        }

        public bool Contains(TValue value)
        {
            return Schema.ContainsKey(value);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            Matrix.CopyTo(array, arrayIndex);
        }

        public void Add(TValue value)
        {
            Schema.Add(value, Count);
            Matrix = ResizeArray(Matrix, Count, Count);
        }

        public bool Remove(TValue value) {
            if (!Schema.ContainsKey(value))
            {
                return false;
            }
            for (int i = 0, j = Schema[value]; i < Count; i++)
            {
                Matrix[i, j] = Matrix[i, Count - 1];
                Matrix[j, i] = Matrix[Count - 1, i];
            }
            Schema[Schema.Last().Key] = Schema[value];
            Schema.Remove(value);
            Matrix = ResizeArray(Matrix, Count, Count);
            return true;
        }

        public void AddDirectedEdge(TValue @from, TValue to, TWeight weight)
        {
            Matrix[Schema[from], Schema[to]] = weight;
        }

        public void AddUndirectedEdge(TValue @from, TValue to, TWeight weight) {
            Matrix[Schema[from], Schema[to]] = weight;
            Matrix[Schema[to], Schema[from]] = weight;
        }

        public void RemoveEdge(TValue @from, TValue to) {
            Matrix[Schema[from], Schema[to]] = default(TWeight);
            Matrix[Schema[to], Schema[from]] = default(TWeight);
        }

        public IEnumerator GetEnumerator()
        {
            return Schema.Keys.GetEnumerator();
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return Schema.Keys.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
            foreach (var elementRow in Schema) {
                matrix.Append(string.Format("{0, 20} | ", elementRow.Key));
                foreach (var elementColumn in Schema) {
                    matrix.Append(string.Format("{0} ", Matrix[elementRow.Value, elementColumn.Value]));
                }
                matrix.AppendLine();
            }
            return matrix.ToString();
        }

        public TValue GetFirstVertex()
        {
            return Schema.Keys.First();
        }

        public TValue GetNextVertex(TValue currentVertex)
        {
            var keysCollection = Schema.Keys;
            bool isNextVertex = false;
            foreach (var key in keysCollection)
            {
                if (isNextVertex)
                {
                    return key;
                }
                if (key.Equals(currentVertex))
                {
                    isNextVertex = true;
                }
            }
            return default(TValue);
        }

        protected T[,] ResizeArray<T>(T[,] original, int rows, int cols) {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }
    }
}