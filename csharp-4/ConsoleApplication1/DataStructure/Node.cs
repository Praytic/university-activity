using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.DataStructure
{
    public class Node<T>
    {
        private int _counter;
        private Node<T> _left;
        private Node<T> _right;
        private bool? _code;

        public Node(T value)
        {
            Value = value;
            _counter = 1;
            _left = null;
            _right = null;
            _code = null;
        }

        public T Value { get; private set; }

        public Node<T> Left
        {
            get { return _left; }
        }

        public Node<T> Right
        {
            get { return _right; }
        }

        public char Code {
            get { return ((bool)_code) ? '1' : '0'; }
        }

        public static void Search(Node<T> node, T value, out Node<T> result)
        {
            if (node == null)
            {
                result = null;
            }
            else
            {
                if (((IComparable) (node.Value)).CompareTo(value) == 0)
                {
                    result = node;
                }
                else
                {
                    if (((IComparable) (node.Value)).CompareTo(value) > 0)
                    {
                        Search(node._left, value, out result);
                    }
                    else
                    {
                        Search(node._right, value, out result);
                    }
                }
            }
        }

        public static void Add(ref Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else
            {
                node._counter++;
                if (((IComparable) (node.Value)).CompareTo(value) > 0)
                {
                    Add(ref node._left, value);
                }
                if (((IComparable) (node.Value)).CompareTo(value) <= 0)
                {
                    Add(ref node._right, value);
                }
            }
        }

        public static void AddNodeRight(ref Node<T> node, Node<T> rightNode)
        {
            if (node != null)
            {
                node._counter++;
                node._right = rightNode;
            }
        }

        public static void AddNodeLeft(ref Node<T> node, Node<T> leftNode) {
            if (node != null) {
                node._counter++;
                node._left = leftNode;
            }
        }

        public static void Delete(ref Node<T> node, object value)
        {
            if (node == null)
            {
                throw new Exception("Node reference is missing");
            }
            if (((IComparable) (node.Value)).CompareTo(value) > 0)
            {
                Delete(ref node._left, value);
            }
            else
            {
                if (((IComparable) (node.Value)).CompareTo(value) < 0)
                {
                    Delete(ref node._right, value);
                }
                else
                {
                    if (node._left == null)
                    {
                        node = node._right;
                    }
                    else if (node._right == null)
                    {
                        node = node._left;
                    }
                    else
                    {
                        Del(node, ref node._left);
                    }
                }
            }
        }

        public static void Preorder(Node<T> node)
        {
            if (node != null)
            {
                Print(node);
                Preorder(node._left);
                Preorder(node._right);
            }
        }

        public static void Inorder(Node<T> node)
        {
            if (node != null)
            {
                Inorder(node._left);
                Print(node);
                Inorder(node._right);
            }
        }

        public static void Postorder(Node<T> node)
        {
            if (node != null)
            {
                Postorder(node._left);
                Postorder(node._right);
                Print(node);
            }
        }

        public static void Balance(ref Node<T> node)
        {
            if (node == null || node._counter == 1) return;
            Part(ref node, node._counter/2);
            Balance(ref node._left);
            Balance(ref node._right);
        }

        public static void Part(ref Node<T> node, int counter)
        {
            var x = (node._left == null) ? 0 : node._left._counter;
            if (x > counter)
            {
                Part(ref node._left, counter);
                RotationRight(ref node);
            }
            if (x < counter)
            {
                Part(ref node._right, counter - x - 1);
                RotationLeft(ref node);
            }
        }

        public static void InsertRandom(ref Node<T> node, T value, Random rnd)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else
            {
                if (rnd.Next() < int.MaxValue/(node._counter + 1))
                {
                    InsertToRoot(ref node, value);
                }
                else
                {
                    node._counter++;
                    if (((IComparable) (node.Value)).CompareTo(value) > 0)
                    {
                        InsertRandom(ref node._left, value, rnd);
                    }
                    else
                    {
                        InsertRandom(ref node._right, value, rnd);
                    }
                }
            }
        }

        public static void SearchToRoot(ref Node<T> node, T value)
        {
            if (node != null)
            {
                if (((IComparable) (node.Value)).CompareTo(value) == 0)
                {
                    return;
                }
                if (((IComparable) (node.Value)).CompareTo(value) > 0)
                {
                    SearchToRoot(ref node._left, value);
                    RotationRight(ref node);
                }
                else
                {
                    SearchToRoot(ref node._right, value);
                    RotationLeft(ref node);
                }
            }
        }

        public static void InsertToRoot(ref Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else
            {
                node._counter++;
                if (((IComparable) (node.Value)).CompareTo(value) > 0)
                {
                    InsertToRoot(ref node._left, value);
                    RotationRight(ref node);
                }
                else
                {
                    InsertToRoot(ref node._right, value);
                    RotationLeft(ref node);
                }
            }
        }

        public static bool IsBalanced(Node<T> node)
        {
            if (node != null)
            {
                if (GetNodeDeltaCounter(node) > 1)
                {
                    return false;
                }
                if (!IsBalanced(node._left) || !IsBalanced(node._right))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Print(Node<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("null");
                return;
            }
            var deltaCounter = GetNodeDeltaCounter(node);
            if (deltaCounter > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("({0}, {1})\n", node.Value, deltaCounter);
            Console.ResetColor();
        }

        public static void GetCodeList(Node<T> node, ref List<string> codeList, StringBuilder code = null)
        {
            if (code == null)
            {
                code = new StringBuilder("");
            }
            if (node == null)
            {
                code.Length--;
            } else {
                code.Append('0');
                GetCodeList(node.Left, ref codeList, code);
                code.Append('1');
                GetCodeList(node.Right, ref codeList, code);
                if (node.Right == null && node.Left == null) {
                    codeList.Add(code.ToString());
                }
                code.Length = (code.Length > 0) ? code.Length-1 : 0;
            }
        } 

        private static int GetNodeDeltaCounter(Node<T> node)
        {
            int leftCounter = (node._left != null) ? node._left._counter : 0,
                rightCounter = (node._right != null) ? node._right._counter : 0,
                deltaCounter = Math.Abs(leftCounter - rightCounter);
            return deltaCounter;
        }

        private static void Count(ref Node<T> node)
        {
            node._counter = 1;
            if (node._left != null) node._counter += node._left._counter;
            if (node._right != null) node._counter += node._right._counter;
        }

        public static void RotationRight(ref Node<T> node)
        {
            var x = node._left;
            node._left = x._right;
            x._right = node;

            Count(ref node);
            Count(ref x);

            node = x;
        }

        public static void RotationLeft(ref Node<T> node)
        {
            var x = node._right;
            node._right = x._left;
            x._left = node;

            Count(ref node);
            Count(ref x);

            node = x;
        }

        private static void Del(Node<T> parent, ref Node<T> node)
        {
            if (node._right != null)
            {
                Del(parent, ref node._right);
            }
            else
            {
                parent.Value = node.Value;
                node = node._left;
            }
        }
    }
}