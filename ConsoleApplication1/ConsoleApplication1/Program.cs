using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApplication1 {
    public static class ArrayExtensions {
        public static int Sum(this int[] param) {
            int sum = 0;
            foreach (int item in param) {
                sum += item;
            }
            return sum;
        }
    }

    public class Good {
        public string Title { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfArrival { get; set; }
        public int StorageNumber { get; set; }
    }

    public class GoodManager {
        private List<Good> list;

        private string template = "Title: {0}\n" +
                             "Weight: {1}\n" +
                             "Price: {2}\n" +
                             "DateOfArrival: {3}\n" +
                             "StorageNumber: {4}\n";

        public GoodManager(List<Good> list) {
            this.list = list;
        }

        public string GetInfo() {
            IEnumerable<string> data = from item in list
                                       select string.Format(template, item.Title, item.Weight, item.Price, item.DateOfArrival.ToShortDateString(), item.StorageNumber);
            return string.Join("\n", data);
        }

        public string GetInfoByTitle(string pattern) {
            IEnumerable<string> data = from item in list
                                       where item.Title.Contains(pattern)
                                       select string.Format(template, item.Title, item.Weight, item.Price, item.DateOfArrival.ToShortDateString(), item.StorageNumber);
            return string.Join("\n", data);
        }

        public string GetInfoSort() {
            IEnumerable<string> data = from item in list
                                       orderby item.Price, item.DateOfArrival
                                       select string.Format(template, item.Title, item.Weight, item.Price, item.DateOfArrival.ToShortDateString(), item.StorageNumber);

            return string.Join("\n", data);
        }

        public string GetInfoByGroups() {
            IEnumerable<IGrouping<int, Good>> data = from item in list
                                                     group item by item.StorageNumber;

            return string.Join("\n", from pair in data
                                     select "\n\nGroup: " + pair.Key + "\n\n" + string.Join("\n", 
                                        from item in pair
                                        select string.Format(template, item.Title, item.Weight, item.Price, item.DateOfArrival.ToShortDateString(), item.StorageNumber)));
        }

        public string ExecutePaging(string query) {
            string[] args = query.Split(' ');
            int page = int.Parse(args[Array.IndexOf(args, "-page") + 1]);
            int recordsCount = Math.Min(int.Parse(args[Array.IndexOf(args, "-recordsCount") + 1]), list.Count);
            
            IEnumerable<string> data = list
                .Skip(recordsCount * (page - 1))
                .Take(recordsCount)
                .Select(item => string.Format(template, item.Title, item.Weight, item.Price, item.DateOfArrival.ToShortDateString(), item.StorageNumber));
            return string.Join("\n", data);
        }
    }

    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Sum of all values in array is " + new int[5] { 1, 2, 3, 4, 5 }.Sum() + "\n");

            List<Good> list = new List<Good>() {
                    new Good() {Title = "Good1", Weight = 10, Price = 15.12M, DateOfArrival = new DateTime(2001, 08, 08), StorageNumber = 110},
                    new Good() {Title = "Good2", Weight = 2.22, Price = 3M, DateOfArrival = new DateTime(2014, 03, 17), StorageNumber = 110},
                    new Good() {Title = "Good3", Weight = 1.11, Price = 11.53M, DateOfArrival = new DateTime(2001, 11, 01), StorageNumber = 410},
                    new Good() {Title = "Good4", Weight = 5, Price = 26M, DateOfArrival = new DateTime(2003, 05, 05), StorageNumber = 350},
                    new Good() {Title = "Good5", Weight = 99, Price = 3M, DateOfArrival = new DateTime(2022, 06, 16), StorageNumber = 110},
                    new Good() {Title = "Good6", Weight = 3, Price = 3M, DateOfArrival = new DateTime(2001, 10, 02), StorageNumber = 350}
            };
            
            GoodManager gm = new GoodManager(list);
            //Console.WriteLine(gm.GetInfo());
            //Console.WriteLine(gm.GetInfoByTitle("Good"));
            //Console.WriteLine(gm.GetInfoSort());
            //Console.WriteLine(gm.GetInfoByGroups());
            Console.WriteLine(gm.ExecutePaging("-page 3 -recordsCount 2"));
        }
    }
}