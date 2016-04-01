using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApplication1 {

    public class Program {
        static void Main() {
            List<int> inputList = new List<int>();
            using (StreamReader sr = new StreamReader("../../input.txt")) {
                inputList = sr
                    .ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToList();
            }
            BinaryTree<int> tree = new BinaryTree<int>();
            foreach (int inputValue in inputList) {
                tree.Add(inputValue);
            }
            tree.Postorder();
            foreach (int inputValue in inputList) {
                if (inputValue % 2 == 1) {
                    tree.Delete(inputValue);
                }
            }
            Console.WriteLine();
            tree.Postorder();
        }
    }
}

