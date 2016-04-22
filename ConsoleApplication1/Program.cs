using System;
using System.Threading;

namespace ConsoleApplication1 {
    public class Program {
        public static void Swap<T>(ref T ob1, ref T ob2)
        {
            var temp = ob1;
            ob1 = ob2;
            ob2 = temp;
        }

        static void Main(string[] args) {
            var testArrayOfStrings = new[] { "aaa", "aaf", "bba", "aa", "bbbb", "bbba", "z", "zab", "ababab" };
            var testArray = new[] { 2, 4, 5, 1, 0, 10, 30, 14, 3 };
            Func<int, int, int> intComparer = (ob1, ob2) => (ob1 > ob2) ? 1 : (ob1 == ob2) ? 0 : -1;
            Func<string, string, int> stringComparer = (ob1, ob2) => (ob1.Length > ob2.Length) ? 1 : (ob1.Length == ob2.Length) ? string.Compare(ob1, ob2, StringComparison.Ordinal) : -1;

            var bubbleSortInt = new BubbleSort<int>(testArray, intComparer);
            var bubbleSortString = new BubbleSort<string>(testArrayOfStrings, stringComparer);

            Console.WriteLine(string.Join(", ", bubbleSortInt.SortedArray));
            Console.WriteLine(string.Join(", ", bubbleSortString.SortedArray));

            Thread intSortingThread = new Thread(bubbleSortInt.Run);
            Thread stringSortingThread = new Thread(bubbleSortString.Run);
            intSortingThread.Start();
            stringSortingThread.Start();
        }

        private static void Dictionary<T1, T2>() {
            throw new NotImplementedException();
        }

        public class BubbleSort<T>
        {
            public T[] SortedArray { get; }
            
            private readonly Action<T[]> SortComplete;

            private readonly Func<T, T, int> _comparer; 

            public BubbleSort() {
                SortComplete = x => Console.WriteLine(string.Join(", ", x));
            }

            public BubbleSort(T[] sortedArray, Func<T, T, int> comparer) : this() {
                SortedArray = sortedArray;
                _comparer = comparer;
            }

            public void Run() {
                for (int i = 0; i < SortedArray.Length; i++) {
                    for (int j = i; j < SortedArray.Length; j++) {
                        if (_comparer(SortedArray[i], SortedArray[j]) > 0) {
                            Swap(ref SortedArray[i], ref SortedArray[j]);
                        }
                    }
                }
                SortComplete(SortedArray);
            }
        }
    }
}
