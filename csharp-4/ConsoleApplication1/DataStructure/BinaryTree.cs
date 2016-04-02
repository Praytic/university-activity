using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.DataStructure
{
    public class BinaryTree<T>
    {
        protected Node<T> Tree;

        public BinaryTree()
        {
            Tree = null;
        }

        public BinaryTree(Node<T> node)
        {
            Tree = node;
        }

        public BinaryTree(List<T> nodeList)
        {
            foreach (var node in nodeList)
            {
                Add(node);
            }
        }

        public void Add(T value)
        {
            Node<T>.Add(ref Tree, value);
        }

        public virtual void AddAndBalance(T value)
        {
            Add(value);
            if (!IsBalanced())
            {
                //Console.WriteLine("WAS BALANSED");
                Balance();
            }
        }

        public void Preorder()
        {
            Node<T>.Preorder(Tree);
        }

        public void Inorder()
        {
            Node<T>.Inorder(Tree);
        }

        public void Postorder()
        {
            Node<T>.Postorder(Tree);
        }

        public virtual T Search(T value)
        {
            Node<T> node;
            Node<T>.Search(Tree, value, out node);
            Node<T>.Print(node);
            return node.Value;
        }

        public void Delete(T value)
        {
            Node<T>.Delete(ref Tree, value);
        }

        public virtual void DeleteAndBalance(T value)
        {
            Delete(value);
            if (!IsBalanced())
            {
                //Console.WriteLine("WAS BALANSED");
                Balance();
            }
        }

        public virtual void SearchToRoot(T value)
        {
            Node<T>.SearchToRoot(ref Tree, value);
        }

        public virtual void InsertToRoot(T value)
        {
            Node<T>.InsertToRoot(ref Tree, value);
        }

        public virtual void Balance()
        {
            Node<T>.Balance(ref Tree);
        }

        public virtual void InsertRandom(T value)
        {
            var rnd = new Random();
            Node<T>.InsertRandom(ref Tree, value, rnd);
        }

        public bool IsBalanced()
        {
            return Node<T>.IsBalanced(Tree);
        }
    }
}