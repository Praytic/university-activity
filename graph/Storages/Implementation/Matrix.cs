using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace graph.Storages.Implementation {

    public class Matrix : Matrix<int> {
        public Matrix(int[,] matrix)
        {
            var array = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                array[i] = i;
            }
            Scheme = new Scheme<int>(array);
            Storage = new List<List<int>>();
            for (int i = 0; i < Count; i++) {
                var newRow = new List<int>();
                for (int j = 0; j < Count; j++) {
                    newRow.Add(matrix[i, j]);
                }
                Storage.Add(newRow);
            }
        }

        public Matrix()
        {
        }

        public Matrix(int[] scheme) : base(scheme)
        {
        }

        public Matrix(Dictionary<int, int> scheme) : base(scheme)
        {
        }

        public Matrix(int[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public Matrix(IMatrix<int, int> storage) : base(storage)
        {
        }

        public Matrix(Scheme<int> scheme) : base(scheme)
        {
        }

        public Matrix(ICollection<int> scheme) : base(scheme)
        {
        }
    }

    public class Matrix<T> : Matrix<T, int> {
        public Matrix()
        {
        }

        public Matrix(T[] scheme) : base(scheme)
        {
        }

        public Matrix(Dictionary<T, int> scheme) : base(scheme)
        {
        }

        public Matrix(T[] scheme, int[,] matrix) : base(scheme, matrix)
        {
        }

        public Matrix(IMatrix<T, int> storage) : base(storage)
        {
        }

        public Matrix(Scheme<T> scheme) : base(scheme)
        {
        }

        public Matrix(ICollection<T> scheme) : base(scheme)
        {
        }
    }

    public class Matrix<T, TW> :
        IMatrix<T, TW>
    {
        #region Overriden Fields

        public int Count {
            get { return Scheme.Count; }
        }

        public bool IsReadOnly { get; }

        public List<List<TW>> Storage { get; protected set; }

        public Scheme<T> Scheme { get; protected set; }

        public int this[T key]
        {
            get { return Scheme[key]; }
            set { Scheme[key] = value; }
        }

        public T this[int key]
        {
            get { return Scheme[key]; }
        }

        public TW this[T i, T j] {
            get { return Storage[Scheme[i]][Scheme[j]]; }
            set { Storage[Scheme[i]][Scheme[j]] = value; }
        }

        public TW this[int i, int j]
        {
            get { return Storage[i][j]; }
            set { Storage[i][j] = value; }
        }

#endregion

        #region Constructors
        
        public Matrix() {
            Storage = new List<List<TW>>();
            Scheme = new Scheme<T>();
        }

        public Matrix(T[] scheme) {
            Scheme = new Scheme<T>(scheme);
            Storage = new List<List<TW>>();
            foreach (var element in scheme) {
                var newRow = new List<TW>();
                foreach (var i in scheme) {
                    newRow.Add(default(TW));
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(Dictionary<T, int> scheme) {
            Scheme = new Scheme<T>(scheme);
            Storage = new List<List<TW>>();
            foreach (var i in scheme) {
                var newRow = new List<TW>();
                foreach (var j in scheme) {
                    newRow.Add(default(TW));
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(T[] scheme, TW[,] matrix) {
            Scheme = new Scheme<T>(scheme);
            Storage = new List<List<TW>>();
            for (int i = 0; i < Count; i++) {
                var newRow = new List<TW>();
                for (int j = 0; j < Count; j++) {
                    newRow.Add(matrix[i, j]);
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(IMatrix<T, TW> storage) {
            Storage = storage.Storage;
            Scheme = storage.Scheme;
        }

        public Matrix(Scheme<T> scheme) {
            Scheme = scheme;
            Storage = new List<List<TW>>();
            foreach (var i in scheme) {
                var newRow = new List<TW>();
                foreach (var j in scheme) {
                    newRow.Add(default(TW));
                }
                Storage.Add(newRow);
            }
        }

        public Matrix(ICollection<T> scheme) {
            Scheme = new Scheme<T>(scheme);
            Storage = new List<List<TW>>();
            foreach (var i in scheme) {
                var newRow = new List<TW>();
                foreach (var j in scheme) {
                    newRow.Add(default(TW));
                }
                Storage.Add(newRow);
            }
        }

        #endregion

        #region Implemented Methods

        public IEnumerator<T> GetEnumerator() {
            return Scheme.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Storage.GetEnumerator();
        }

        public void Add(T item) {
            Scheme.Add(item);
            foreach (var row in Storage) {
                row.Add(default(TW));
            }
            var newRow = new List<TW>();
            for (int i = 0; i < Count; i++) {
                newRow.Add(default(TW));
            }
            Storage.Add(newRow);
        }

        public void Clear() {
            Storage.Clear();
            Scheme.Clear();
        }

        public bool Contains(T item) {
            return Scheme.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            if (!Scheme.Contains(item)) return false;
            var lastElement = Scheme.GetLast();
            foreach (var vertex in this) {
                if (!Equals(vertex, item)) {
                    this[vertex, item] = this[vertex, lastElement.Key];
                    this[item, vertex] = this[lastElement.Key, vertex];
                }
            }
            foreach (var vertex in this) {
                Storage[Scheme[vertex]].RemoveAt(lastElement.Value);
            }
            Storage.RemoveAt(lastElement.Value);
            var tmp = Scheme[item];
            Scheme.Remove(item);
            Scheme[lastElement.Key] = tmp;
            return true;
        }

        #endregion
    
        #region Overriden Methods

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

#endregion

    }
}