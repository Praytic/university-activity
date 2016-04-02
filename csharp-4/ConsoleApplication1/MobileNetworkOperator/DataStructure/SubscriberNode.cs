using System.Collections.Generic;
using ConsoleApplication1.DataStructure;
using ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit;

namespace ConsoleApplication1.MobileNetworkOperator.DataStructure
{
    public class SubscriberNode : Node<Subscriber>
    {
        public SubscriberNode(Subscriber value) : base(value)
        {
        }

        public static void GetValuesDictionary(Node<Subscriber> node,
            ref Dictionary<object, int> result, SubscriberComparer comparer)
        {
            if (node != null)
            {
                if (result.ContainsKey(node.Value.Name))
                {
                    result[comparer.GetField(node.Value)]++;
                }
                else
                {
                    result.Add(comparer.GetField(node.Value), 1);
                }
                GetValuesDictionary(node.Right, ref result, comparer);
                GetValuesDictionary(node.Left, ref result, comparer);
            }
        }
    }
}