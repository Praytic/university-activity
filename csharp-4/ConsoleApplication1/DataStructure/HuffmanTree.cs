using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.DataStructure
{
    public class HuffmanTree<T> : BinaryTree<int>
    {
        protected Dictionary<T, int> FrequencyDictionary;

        public int Count
        {
            get { return FrequencyDictionary.Count; }
        }

        public HuffmanTree(Dictionary<T, int> frequencyDictionary)
        {
            FrequencyDictionary = frequencyDictionary;
            var sortedPairs = frequencyDictionary.OrderBy(a => a.Value);
            var sortedNodeList = new List<Node<int>>();
            foreach (var valuePair in sortedPairs) {
                sortedNodeList.Add(new Node<int>(valuePair.Value));
            }

            Tree = (sortedNodeList.Count == 0) ? null : sortedNodeList[0];
            while (sortedNodeList.Count > 1) {
                var leftNode = sortedNodeList[0];
                var rightNode = sortedNodeList[1];
                Tree = new Node<int>(leftNode.Value + rightNode.Value);
                Node<int>.AddNodeLeft(ref Tree, leftNode);
                Node<int>.AddNodeRight(ref Tree, rightNode);
                sortedNodeList.RemoveRange(0, 2);
                sortedNodeList.Add(Tree);
                sortedNodeList.Sort((a, b) => a.Value.CompareTo(b.Value));
            }
        }

        public Dictionary<T, string> GetIncodedDictionary() {
            var incodedList = new List<string>();
            var incodedDictionary = new Dictionary<T, string>();
            HummanNode.GetIncodedList(Tree, ref incodedList);
            incodedList.Reverse();
            
            var sortedPairs = FrequencyDictionary.OrderBy(a => a.Value);
            var index = 0;
            foreach (var mapEntry in sortedPairs) {
                incodedDictionary[mapEntry.Key] = incodedList[index++];
            }
            return incodedDictionary;
        }

        public void PrintFrequencyDictionary()
        {
            foreach (var i in FrequencyDictionary)
            {
                Console.WriteLine(i);
            }
        }
    }
}