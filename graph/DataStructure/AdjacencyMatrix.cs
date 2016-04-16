using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.DataStructure
{
    public class AdjacencyMatrix<TValue, TCost> : IEnumerable
    {
        private int Size { get; set; }

        private Dictionary<TValue, int> Schema { get; }

        private TCost[,] Matrix { get; set; }

        public AdjacencyMatrix()
        {
            Schema = new Dictionary<TValue, int>();
            Matrix = new TCost[0, 0];
        }

        public bool Contains(TValue value)
        {
            return Schema.ContainsKey(value);
        }

        public void Add(TValue value)
        {
            Schema.Add(value, Size);
            Size++;
            Matrix = ResizeArray(Matrix, Size, Size);
        }

        public void Remove(TValue value) {
            Schema.Remove(value);
            Size--;
            Matrix = ResizeArray(Matrix, Size, Size);
        }

        public void AddDirectedEdge(TValue @from, TValue to, TCost cost)
        {
            Matrix[Schema[from], Schema[to]] = cost;
        }

        public void AddUndirectedEdge(TValue @from, TValue to, TCost cost) {
            Matrix[Schema[from], Schema[to]] = cost;
            Matrix[Schema[to], Schema[from]] = cost;
        }

        public IEnumerator GetEnumerator()
        {
            return Matrix.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
            var schema = Schema.Keys.ToList();
           /* matrix.Append(string.Format("{0, 20} | ", ' '));
            for (int i = 0; i < Size; i++)
            {
                matrix.Append(schema[i].ToString()[0] + " ");
            }
            matrix.AppendLine();*/
            for (int i = 0; i < Size; i++)
            {
                matrix.Append(string.Format("{0, 20} | ", schema[i]));
                for (int j = 0; j < Size; j++)
                {
                    matrix.Append(Matrix[i, j] + " ");
                }
                matrix.AppendLine();
            }
            return matrix.ToString();
        }

        private T[,] ResizeArray<T>(T[,] original, int rows, int cols) {
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