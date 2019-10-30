﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBinaryTree
{
    public class NodeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private MyBinaryTree<T> myTree;
        private Queue<T> queue;
        public NodeEnumerator(MyBinaryTree<T> myTree)
        {
            this.myTree = myTree;
            queue = new Queue<T>();
            Traverse(this.myTree.Root);
        }

        public T Current => queue.Dequeue();
        object IEnumerator.Current { get { return Current; } }

        public void Dispose() { }
        public void Traverse(Node<T> Root)
        {
            if (Root == null)
                return;
            Traverse(Root.Left);
            queue.Enqueue(Root.Data);
            Traverse(Root.Right);
        }
        public bool MoveNext()
        {
            if (queue.Count > 0)
                return true;
            return false;
        }
        public void Reset() { }
    }
}