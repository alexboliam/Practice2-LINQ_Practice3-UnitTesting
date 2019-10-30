﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyBinaryTree
{
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; } = default;
        public MyBinaryTree() { }

        #region Events
        public delegate void EventHandler(object sender, MyTreeEventArgs<T> e);
        public event EventHandler OnInsert;
        public event EventHandler OnRemove;
        #endregion

        #region Methods
        //public void Insert(T Data) => this.Insert(this.Root, Data);
        //private Node<T> Insert(Node<T> node, T Data)
        //{
        //    if (node == null)
        //        return new Node<T>(Data);
        //    else if (Data.CompareTo(node.Data) == -1)
        //        return Insert(node.Left, Data);
        //    else return Insert(node.Right, Data);
        //}
        public void Insert(T Data)
        {
            Node<T> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (Data.CompareTo(after.Data) == -1)
                    after = after.Left;
                else
                {
                    after = after.Right;
                }
            }

            Node<T> newNode = new Node<T>(Data);
            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else if (Data.CompareTo(before.Data) == -1)
            {
                before.Left = newNode;
            }
            else
            {
                before.Right = newNode;
            }
            OnInsert(this, new MyTreeEventArgs<T>(newNode.Data));
        }
        public void Remove(T Data)
        {
            this.Remove(this.Root, Data);
            OnRemove(this, new MyTreeEventArgs<T>(Data));
        }
        private Node<T> Remove(Node<T> parent, T Data)
        {
            if (parent == null)
                return parent;

            if (Data.CompareTo(parent.Data) == -1)
                parent.Left = Remove(parent.Left, Data);
            else if (Data.CompareTo(parent.Data) == 1)
                parent.Right = Remove(parent.Right, Data);
            else
            {
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;


                parent.Data = MinValue(parent.Right);
                parent.Right = Remove(parent.Right, parent.Data);
            }

            return parent;

        }
        public Node<T> Find(T Data) => this.Find(Data, this.Root);
        private Node<T> Find(T Data, Node<T> parent)
        {
            if (parent != null)
            {
                if (Data.CompareTo(parent.Data) == 0)
                    return parent;
                if (Data.CompareTo(parent.Data) == -1)
                    return Find(Data, parent.Left);
                if (Data.CompareTo(parent.Data) == 1)
                    return Find(Data, parent.Right);
            }
            return null;
        }
        private T MinValue(Node<T> node)
        {
            T minv = node.Data;

            while (node.Left != null)
            {
                minv = node.Left.Data;
                node = node.Left;
            }

            return minv;
        }
        public void Traverse(Node<T> Root)
        {
            if (Root == null)
                return;
            Traverse(Root.Left);
            Console.Write(Root.Data + " ");
            Traverse(Root.Right);
        }
        #endregion
        public IEnumerator<T> GetEnumerator()
        {
            if (Root.Left != null)
            {
                foreach (var v in Root.Left)
                {
                    yield return v;
                }
            }

            yield return Root.Data;

            if (Root.Right != null)
            {
                foreach (var v in Root.Right)
                {
                    yield return v;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Root.Left != null)
            {
                foreach (var v in Root.Left)
                {
                    yield return v;
                }
            }

            yield return Root.Data;

            if (Root.Right != null)
            {
                foreach (var v in Root.Right)
                {
                    yield return v;
                }
            }
        }
    }
}