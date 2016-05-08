using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph.DataStructure.Implementation {
    public class Matrix<TVertex, TWeight> :
        IMatrix<TVertex, TWeight>
    {
        public int Count {
            get { return Schema.Count; }
        }

        public bool IsReadOnly { get; }

        public List<List<TWeight>> Storage { get; }

        public Dictionary<TVertex, int> Schema { get; }

        public TWeight this[TVertex i, TVertex j] {
            get { return Storage[Schema[i]][Schema[j]]; }
            set { Storage[Schema[i]][Schema[j]] = value; }
        }

        public Matrix() {
            Storage = new List<List<TWeight>>();
            Schema = new Dictionary<TVertex, int>();
        }

        public Matrix(TVertex[] schema) {
            Schema = new Dictionary<TVertex, int>();
            Storage = new List<List<TWeight>>();
            foreach (var element in schema) {
                Schema.Add(element, Count);
                var newRow = new List<TWeight>();
                foreach (var i in schema) {
                    newRow.Add(default(TWeight));
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(Dictionary<TVertex, int> schema) {
            Schema = schema;
            Storage = new List<List<TWeight>>();
            foreach (var i in schema) {
                var newRow = new List<TWeight>();
                foreach (var j in schema) {
                    newRow.Add(default(TWeight));
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(TVertex[] schema, TWeight[,] matrix) {
            Schema = new Dictionary<TVertex, int>();
            foreach (var element in schema) {
                Schema.Add(element, Count);
            }
            Storage = new List<List<TWeight>>();
            for (int i = 0; i < Count; i++) {
                var newRow = new List<TWeight>();
                for (int j = 0; j < Count; j++) {
                    newRow.Add(matrix[i, j]);
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(IMatrix<TVertex, TWeight> storage) {
            Storage = storage.Storage;
            Schema = storage.Schema;
        }

        public IEnumerator<TVertex> GetEnumerator() {
            return Schema.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Storage.GetEnumerator();
        }

        public void Add(TVertex item) {
            Schema.Add(item, Count);
            foreach (var row in Storage) {
                row.Add(default(TWeight));
            }
            var newRow = new List<TWeight>();
            for (int i = 0; i < Count; i++) {
                newRow.Add(default(TWeight));
            }
            Storage.Add(newRow);
        }

        public void Clear() {
            Storage.Clear();
            Schema.Clear();
        }

        public bool Contains(TVertex item) {
            return Schema.ContainsKey(item);
        }

        public void CopyTo(TVertex[] array, int arrayIndex) {
            Schema.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(TVertex item) {
            if (!Schema.ContainsKey(item)) return false;
            var lastElement = Schema.Last();
            foreach (var vertex in this) {
                if (!Equals(vertex, item)) {
                    this[vertex, item] = this[vertex, lastElement.Key];
                    this[item, vertex] = this[lastElement.Key, vertex];
                }
            }
            foreach (var vertex in this) {
                Storage[Schema[vertex]].RemoveAt(lastElement.Value);
            }
            Storage.RemoveAt(lastElement.Value);
            Schema[lastElement.Key] = Schema[item];
            Schema.Remove(item);
            return true;
        }

        public override string ToString() {
            StringBuilder matrix = new StringBuilder();
            foreach (var elementRow in this) {
                matrix.Append(string.Format("{0, 20} | ", elementRow));
                foreach (var elementColumn in this) {
                    matrix.Append(string.Format("{0} ", this[elementRow, elementColumn]));
                }
                matrix.AppendLine();
            }
            return matrix.ToString();
        }
    }
}