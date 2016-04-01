using System;
using System.Collections.Generic;

namespace ConsoleApplication1 {
    public class BinaryTree<T> {
        protected Node<T> Tree;

        public BinaryTree() {
            Tree = null;
        }

        public BinaryTree(Node<T> node) {
            Tree = node;
        }

        public BinaryTree(List<T> nodeList) {
            foreach (var node in nodeList) {
                Node<T>.Add(ref Tree, node);
            }
        }

        public void Add(T value) {
            Node<T>.Add(ref Tree, value);
        }

        public void AddAndBalance(T value) {
            Node<T>.Add(ref Tree, value);
            if (!Node<T>.IsBalanced(Tree)) {
                //Console.WriteLine("WAS BALANSED");
                Node<T>.Balance(ref Tree);
            }
        }

        public void Preorder() {
            Node<T>.Preorder(Tree);
        }

        public void Inorder() {
            Node<T>.Inorder(Tree);
        }

        public void Postorder() {
            Node<T>.Postorder(Tree);
        }

        public T Search(T value) {
            Node<T> node;
            Node<T>.Search(Tree, value, out node);
            Node<T>.Print(node);
            return node.Value;
        }

        public void Delete(T value) {
            Node<T>.Delete(ref Tree, value);
        }

        public void DeleteAndBalance(T value) {
            Node<T>.Delete(ref Tree, value);
            if (!Node<T>.IsBalanced(Tree)) {
                //Console.WriteLine("WAS BALANSED");
                Node<T>.Balance(ref Tree);
            }
        }

        public void SearchToRoot(T value) {
            Node<T>.SearchToRoot(ref Tree, value);
        }

        public void InsertToRoot(T value) {
            Node<T>.InsertToRoot(ref Tree, value);
        }

        public void Balance() {
            Node<T>.Balance(ref Tree);
        }

        public void InsertRandom(T value) {
            var rnd = new Random();
            Node<T>.InsertRandom(ref Tree, value, rnd);
        }

        public bool IsBalanced() {
            return Node<T>.IsBalanced(Tree);
        }
    }
}