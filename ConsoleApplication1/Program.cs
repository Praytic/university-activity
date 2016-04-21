using System;

namespace ConsoleApplication1 {
    public class Program {
        public delegate int SortComparer<in T>(T ob1, T ob2);

        public static void Swap<T>(ref T ob1, ref T ob2)
        {
            var temp = ob1;
            ob1 = ob2;
            ob2 = temp;
        }

        public static T[] BubbleSort<T>(T[] arrayToSort, SortComparer<T> comparer) {
            for (int i = 0; i < arrayToSort.Length; i++) {
                for (int j = i; j < arrayToSort.Length; j++) {
                    if (comparer(arrayToSort[i], arrayToSort[j]) > 0) {
                        Swap(ref arrayToSort[i], ref arrayToSort[j]);
                    }
                }
            }
            return arrayToSort;
        }

        static void Main(string[] args) {
            var testArrayOfStrings = new[] { "aaa", "aaf", "bba", "aa", "bbbb", "bbba", "z", "zab", "ababab" };
            var testArray = new[] { 2, 4, 5, 1, 0, 10, 30, 14, 3 };
            Console.WriteLine(string.Join(", ", testArray));
            Console.WriteLine(string.Join(", ", testArrayOfStrings));
            var sortedTestArray = BubbleSort(testArray, (ob1, ob2) => (ob1 > ob2) ? 1 : (ob1 == ob2) ? 0 : -1);
            var sortedTestArrayOfStrings = BubbleSort(testArrayOfStrings, (ob1, ob2) => (ob1.Length > ob2.Length) ? 1 : (ob1.Length == ob2.Length) ? string.Compare(ob1, ob2, StringComparison.Ordinal) : -1);
            Console.WriteLine(string.Join(", ", sortedTestArray));
            Console.WriteLine(string.Join(", ", sortedTestArrayOfStrings));
        }
    }
}
