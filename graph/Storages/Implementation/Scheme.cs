using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace graph.Storages.Implementation
{
    public class Scheme : Scheme<int>
    {
        public Scheme()
        {
        }

        public Scheme(int[] scheme) : base(scheme)
        {
        }

        public Scheme(Dictionary<int, int> scheme) : base(scheme)
        {
        }

        public Scheme(ICollection<int> scheme) : base(scheme)
        {
        }
    }

    public class Scheme<T> : ICollection<T> {

        private readonly Dictionary<T, int> _scheme;

        private readonly Dictionary<int, T> _reversedScheme;

        public Dictionary<T, int>.KeyCollection Keys
        {
            get { return _scheme.Keys; }
        }

        public Dictionary<T, int>.ValueCollection Values {
            get { return _scheme.Values; }
        }

        public int Count
        {
            get { return _scheme.Count; }
        }

        public bool IsReadOnly { get; }

        public T this[int i]
        {
            get { return _reversedScheme[i]; }
            set
            {
                if (_reversedScheme.ContainsKey(i)) {
                    throw new ArgumentException("This key already exists in this scheme");
                }
                _scheme[value] = i;
                _reversedScheme[i] = value;
            }
        }

        public int this[T i] {
            get { return _scheme[i]; }
            set
            {
                if (_reversedScheme.ContainsKey(value))
                {
                    throw new ArgumentException("This value already exists in this scheme");
                }
                _scheme[i] = value;
                _reversedScheme[value] = i;
            }
        }

        public Scheme() {
            _scheme = new Dictionary<T, int>();
            _reversedScheme = new Dictionary<int, T>();
        }

        public Scheme(T[] scheme) : this() {
            for (int i = 0; i < scheme.Length; i++)
            {
                _scheme[scheme[i]] = i;
                _reversedScheme[i] = scheme[i];
            }
        }

        public Scheme(Dictionary<T, int> scheme) : this() {
            _scheme = scheme;
            foreach (var i in scheme)
            {
                if (_reversedScheme.ContainsKey(i.Value))
                {
                    throw new ArgumentException("This dictionary containes duplicate values");
                }
                _reversedScheme.Add(i.Value, i.Key);
            }
        }

        public Scheme(ICollection<T> scheme) : this()
        {
            int i = 0;
            foreach (var item in scheme) {
                _scheme[item] = i;
                _reversedScheme[i++] = item;
            }
        }

        public bool Remove(T key)
        {
            var tmp = _scheme[key];
            return _scheme.Remove(key) && _reversedScheme.Remove(tmp);
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return _scheme.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _scheme.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _scheme.Keys.GetEnumerator();
        }

        public void Add(T item)
        {
            var tmp = GetLast().Value;
            if (_scheme.ContainsKey(item)) {
                throw new ArgumentException("This key already exists in this scheme");
            }
            _scheme[item] = GetLast().Value;
            _reversedScheme[GetLast().Value] = item;
        }

        public bool Contains(T item)
        {
            return _scheme.ContainsKey(item);
        }

        public void Clear()
        {
            _scheme.Clear();
            _reversedScheme.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            _scheme.Keys.CopyTo(array, arrayIndex);
        }

        public KeyValuePair<T, int> GetLast()
        {
            return _scheme.Last();
        }

        public KeyValuePair<T, int> GetFirst() {
            return _scheme.First();
        }
    }
}