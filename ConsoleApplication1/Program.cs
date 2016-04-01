using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.MobileNetworkOperator;
using ConsoleApplication1.MobileNetworkOperator.DataStructure;
using ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit;

namespace ConsoleApplication1
{
    public class Program
    {
        private static void Main()
        {
            MobileNetworkRegister registry = MobileNetworkRegister.Instance;
            var subscriberList = new List<Subscriber>();

            using (var sr = new StreamReader("../../Resource/input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var readLine = sr.ReadLine();
                    if (readLine != null)
                    {
                        var inputList = readLine
                            .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        subscriberList.Add(registry.RegisterSubscriber(
                            inputList[0],
                            inputList[1],
                            inputList[2]));
                    }
                }
            }

            Subscriber newSubscriber = registry.RegisterSubscriber("32626112529", "Gdf", "KOK");
            Subscriber oldSubscriber = subscriberList[0];

            Console.WriteLine("=== IMBALANCING TREE ===");
            var imbalancedTree = registry.CreateBinaryTree(subscriberList);
            imbalancedTree.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== BALANCING TREE ===");
            var balancedTree = registry.CreateBinaryTree(subscriberList);
            balancedTree.Balance();
            balancedTree.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== ADD WITHOUT BALANCING ===");
            balancedTree.Add(newSubscriber);
            balancedTree.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== ADD WITH BALANCING ===");
            var balancedTree2 = registry.CreateBinaryTree(subscriberList);
            balancedTree2.Balance();
            balancedTree2.AddAndBalance(newSubscriber);
            balancedTree2.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== DELETE WITHOUT BALANCING ===");
            balancedTree = registry.CreateBinaryTree(subscriberList);
            balancedTree.Delete(oldSubscriber);
            balancedTree.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== DELETE WITH BALANCING ===");
            balancedTree2 = registry.CreateBinaryTree(subscriberList);
            balancedTree2.Balance();
            balancedTree2.DeleteAndBalance(oldSubscriber);
            balancedTree2.Preorder();
            Console.WriteLine();
            
            Console.WriteLine("=== SEARCH BY NUMBER ===");
            var balancedTree3 = registry.CreateBinaryTreeByNumber(subscriberList);
            balancedTree3.AddAndBalance(newSubscriber);
            balancedTree3.AddAndBalance(oldSubscriber);
            ((SubscriberBinaryTree)balancedTree3).SearchByField("89047541618");
            Console.WriteLine();

            Console.WriteLine("=== CHANGE BALANCE INTRODUCTION ===");
            var balancedTree4 = registry.CreateBinaryTreeByName(subscriberList);
            balancedTree4.Balance();
            balancedTree4.Preorder();
            Console.WriteLine();

            Console.WriteLine("=== GET MOST FREQUENT VALUE ===");
            var balancedTree5 = registry.CreateBinaryTreeByName(subscriberList);
            balancedTree5.Balance();
            object result = ((SubscriberBinaryTree)balancedTree5).GetMostFrequentValue();
            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}