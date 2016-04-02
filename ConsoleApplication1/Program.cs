using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleApplication1.DataStructure;
using ConsoleApplication1.MobileNetworkOperator;
using ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit;

namespace ConsoleApplication1
{
    public class Program
    {
        private static void Main() {
            var stringOrigin = ReadString("../../Resource/input.txt");
            var subscribersOrigin = ReadSubscribers("../../Resource/input2.txt");

            var stringIncoded = "";
            var subscribersIncoded = "";

            var frequencyString = GetFrequencyDictionary(stringOrigin);
            var frequencySubscribers = GetFrequencyDictionary(subscribersOrigin);

            var huffmanTreeString = new HuffmanTree<char>(frequencyString);
            var huffmanTreeSubscribers = new HuffmanTree<Subscriber>(frequencySubscribers);

            var incodedStringDictionary = huffmanTreeString.GetIncodedDictionary();
            var incodedSubscribersDictionary = huffmanTreeSubscribers.GetIncodedDictionary();

            foreach (var elementOrigin in stringOrigin) {
                stringIncoded += incodedStringDictionary[elementOrigin];
            }
            foreach (var elementOrigin in subscribersOrigin) {
                subscribersIncoded += incodedSubscribersDictionary[elementOrigin];
            }

            Console.WriteLine("\n=== STRING ===\n");
            foreach (var i in incodedStringDictionary) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Simple incoding: " + ((int) Math.Log(huffmanTreeString.Count, 2) + 1) * stringOrigin.Length);
            Console.WriteLine("Huffman incoding: " + stringIncoded.Length);
            Console.WriteLine("Incoded string:\n" + stringIncoded);

            Console.WriteLine("\n=== SUBSCRIBERS ===\n");
            foreach (var i in incodedSubscribersDictionary) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Simple incoding: " + ((int) Math.Log(huffmanTreeSubscribers.Count, 2) + 1) * subscribersOrigin.Count);
            Console.WriteLine("Huffman incoding: " + subscribersIncoded.Length);
            Console.WriteLine("Incoded subscribers:\n" + subscribersIncoded);
        }

        private static string ReadString(string path)
        {
            StringBuilder readString = new StringBuilder();
            using (var sr = new StreamReader(path)) {
                while (!sr.EndOfStream) {
                    var line = sr.ReadLine();
                    readString.Append(line);
                }
            }
            return readString.ToString();
        }

        private static List<Subscriber> ReadSubscribers(string path) {
            MobileNetworkRegister registry = MobileNetworkRegister.Instance;
            var subscriberList = new List<Subscriber>();
            using (var sr = new StreamReader(path)) {
                while (!sr.EndOfStream) {
                    var readLine = sr.ReadLine();
                    if (readLine != null) {
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
            return subscriberList;
        }

        private static Dictionary<T, int> GetFrequencyDictionary<T>(IEnumerable<T> enumerableOrigin) {
            var frequencyDictionary = new Dictionary<T, int>();
            foreach (var entityOrigin in enumerableOrigin) {
                if (frequencyDictionary.ContainsKey(entityOrigin)) {
                    frequencyDictionary[entityOrigin]++;
                } else {
                    frequencyDictionary.Add(entityOrigin, 1);
                }
            }
            return frequencyDictionary;
        }
    }
}