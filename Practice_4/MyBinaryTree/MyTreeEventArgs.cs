using System;
using System.Collections.Generic;
using System.Text;

namespace MyBinaryTree
{
    public class MyTreeEventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public MyTreeEventArgs() { Value = default(T); }
        public MyTreeEventArgs(T Value)
        {
            this.Value = Value;
        }
    }
}
