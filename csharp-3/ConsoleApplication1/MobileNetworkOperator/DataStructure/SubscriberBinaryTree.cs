using System;
using System.Collections.Generic;
using ConsoleApplication1.DataStructure;
using ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit;

namespace ConsoleApplication1.MobileNetworkOperator.DataStructure
{
    public class SubscriberBinaryTree : BinaryTree<Subscriber>
    {
        public SubscriberComparer FieldBalancer { get; }

        public SubscriberBinaryTree(IEnumerable<Subscriber> subscribersList)
        {
            FieldBalancer = SubscriberComparer.Default;
            foreach (var subscriber in subscribersList)
            {
                Node<Subscriber>.Add(ref Tree, new SubscriberComparable(subscriber));
            }
        }

        public SubscriberBinaryTree(IEnumerable<Subscriber> subscribersList, SubscriberComparer comparer) {
            FieldBalancer = comparer;
            foreach (var subscriber in subscribersList)
            {
                Node<Subscriber>.Add(ref Tree, new SubscriberComparable(subscriber));
            }
        }

        public override void AddAndBalance(Subscriber value) {
            Add(new SubscriberComparable(value, FieldBalancer));
            if (!IsBalanced()) {
                //Console.WriteLine("WAS BALANSED");
                Balance();
            }
        }

        public Subscriber SearchByField(object value)
        {
            var dummySubscriber = FieldBalancer.GetDummy(value);
            return Search(dummySubscriber);
        }

        public object GetMostFrequentValue()
        {
            var valuesDictionary =
                new Dictionary<object, int>();
            SubscriberNode.GetValuesDictionary(Tree, ref valuesDictionary, FieldBalancer);
            object mostFrequentValue = null;
            foreach (var valueEntry in valuesDictionary)
            {
                if (mostFrequentValue == null)
                {
                    mostFrequentValue = valueEntry.Key;
                }
                if (valuesDictionary[mostFrequentValue].CompareTo(valueEntry.Value) < 0)
                {
                    mostFrequentValue = valueEntry.Key;
                }
            }
            return mostFrequentValue;
        }
    }
}