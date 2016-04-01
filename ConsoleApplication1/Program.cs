using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.DataStructure;

namespace ConsoleApplication1
{
    public class Program
    {
        private static void Main()
        {
            var charMap = new Dictionary<char, int>();
            var finalCodeMap = new Dictionary<char, string>();

            using (var sr = new StreamReader("../../Resource/input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line == null) continue;
                    var readLine = line.ToCharArray();
                    foreach (var charValue in readLine)
                    {
                        if (charMap.ContainsKey(charValue))
                        {
                            charMap[charValue]++;
                        }
                        else
                        {
                            charMap.Add(charValue, 1);
                        }
                    }
                }
            }
            var charSortedMap = charMap.OrderBy(a => a.Value);
            var charSortedList = new List<Node<int>>();
            foreach (var valuePair in charSortedMap)
            {
                charSortedList.Add(new Node<int>(valuePair.Value));
            }

            Node<int> mergeNode = (charSortedList.Count == 0) ? null : charSortedList[0];
            while (charSortedList.Count > 1)
            {
                var leftNode = charSortedList[0];
                var rightNode = charSortedList[1];
                mergeNode = new Node<int>(leftNode.Value + rightNode.Value);
                Node<int>.AddNodeLeft(ref mergeNode, leftNode);
                Node<int>.AddNodeRight(ref mergeNode, rightNode);
                charSortedList.RemoveRange(0, 2);
                charSortedList.Add(mergeNode);
                charSortedList.Sort((a, b) => a.Value.CompareTo(b.Value));
            }
            var charCodedList = new List<string>();
            Node<int>.GetCodeList(mergeNode, ref charCodedList);
            charCodedList.Reverse();
            int index = 0;
            foreach (var mapEntry in charSortedMap)
            {
                finalCodeMap[mapEntry.Key] = charCodedList[index++];
            }
            foreach (var code in finalCodeMap)
            {
                Console.WriteLine(code);
            }
        }
    }
}