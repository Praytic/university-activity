using System.Collections.Generic;
using ConsoleApplication1.DataStructure;
using ConsoleApplication1.MobileNetworkOperator.DataStructure;
using ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit;

namespace ConsoleApplication1.MobileNetworkOperator
{
    public class MobileNetworkRegister
    {
        private static MobileNetworkRegister _instance = new MobileNetworkRegister();

        private MobileNetworkRegister() { }

        public static MobileNetworkRegister Instance
        {
           get
            {
                if (_instance == null)
                {
                    _instance = new MobileNetworkRegister();
                }
                return _instance;
            }
        }

        public Subscriber RegisterSubscriber(string phoneNumber, string name, string rate)
        {
            return new SubscriberComparable(phoneNumber, name, rate);
        }

        public BinaryTree<Subscriber> CreateBinaryTree(List<Subscriber> subscribers) {
            return new SubscriberBinaryTree(subscribers);
        }

        public BinaryTree<Subscriber> CreateBinaryTree(List<Subscriber> subscribers,
            SubscriberComparer comparer)
        {
            return new SubscriberBinaryTree(subscribers, comparer);
        }

        public BinaryTree<Subscriber> CreateBinaryTreeByName(List<Subscriber> subscribers) {
            return new SubscriberBinaryTree(subscribers, SubscriberComparer.ByName);
        }

        public BinaryTree<Subscriber> CreateBinaryTreeByNumber(List<Subscriber> subscribers) {
            return new SubscriberBinaryTree(subscribers, SubscriberComparer.ByNumber);
        }

        public BinaryTree<Subscriber> CreateBinaryTreeByRate(List<Subscriber> subscribers) {
            return new SubscriberBinaryTree(subscribers, SubscriberComparer.ByRate);
        }
    }
}