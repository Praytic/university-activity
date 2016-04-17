﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.DataStructure
{
    public class AdjacencyMatrix<TValue, TWeight> : IEnumerable
    {
        public int Size { get; protected set; }

        protected Dictionary<TValue, int> Schema { get; set; }

        protected TWeight[,] Matrix { get; set; }

        public AdjacencyMatrix()
        {
            Schema = new Dictionary<TValue, int>();
            Matrix = new TWeight[0, 0];
        }

        public TWeight this[TValue i, TValue j]
        {
            get { return Matrix[Schema[i], Schema[j]]; }
            set { Matrix[Schema[i], Schema[j]] = value; }
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
            for (int i = 0, j = Schema[value]; i < Size; i++)
            {
                Matrix[i, j] = Matrix[i, Size - 1];
                Matrix[j, i] = Matrix[Size - 1, i];
            }
            Schema[Schema.Last().Key] = Schema[value];
            Schema.Remove(value);
            Size--;
            Matrix = ResizeArray(Matrix, Size, Size);
        }

        public void AddDirectedEdge(TValue @from, TValue to, TWeight cost)
        {
            Matrix[Schema[from], Schema[to]] = cost;
        }

        public void AddUndirectedEdge(TValue @from, TValue to, TWeight cost) {
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
            foreach (var elementRow in Schema) {
                matrix.Append(string.Format("{0, 20} | ", elementRow.Key));
                foreach (var elementColumn in Schema) {
                    matrix.Append(string.Format("{0, 3}", Matrix[elementRow.Value, elementColumn.Value]));
                }
                matrix.AppendLine();
            }
            return matrix.ToString();
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
        
        public void HamiltonCycle(ref List<TValue> cycle, ref List<bool> usedVertexList, int completeVertexCount = 1) {
            TValue startVertex = cycle[completeVertexCount - 1];
            foreach (var element in Schema.Keys)
            {
                if (!Matrix[Schema[startVertex], Schema[element]].Equals(default(TWeight)))
                {
                    if (completeVertexCount == Size && element.Equals(default(TWeight)))
                    {
                        cycle[completeVertexCount] = element;
                        foreach (var vertex in cycle)
                        {
                            Console.WriteLine("{0} ", vertex);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        if (!usedVertexList[Schema[element]])
                        {
                            cycle[completeVertexCount] = element;
                            usedVertexList[Schema[element]] = true;
                            HamiltonCycle(ref cycle, ref usedVertexList, completeVertexCount + 1);
                            usedVertexList[Schema[element]] = false;
                        }
                    }
                }
            }
        }
    }
}