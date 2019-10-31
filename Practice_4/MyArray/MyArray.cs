using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyArray
{
    public class MyArray<T> : IEnumerable<T>
    {
        #region Fields and Properties
        private T[] array;
        private int Offset = default;
        public int LowerBound { get; private set; } = default;
        public int Capacity { get; private set; } = default;
        #endregion

        #region ctors
        public MyArray(int LowerBound, int capacity) 
        {
            if (capacity < 1) throw new ArgumentException("Capacity cannot be zero or negative number");
            this.LowerBound = LowerBound;
            this.Capacity = capacity;
            Offset = LowerBound;
            array = new T[this.Capacity];
        }
        public MyArray(T[] array)
        {
            if (array == null || array.Length < 1 ) throw new ArgumentException("Input array is empty");
            this.Capacity = array.Length;
            this.array = new T[array.Length];
            array.CopyTo(this.array, 0);
        }
        public MyArray(T[] array, int LowerBound)
        {
            if (array == null || array.Length < 1) throw new ArgumentException("Input array is empty");
            this.array = new T[array.Length];
            this.LowerBound = LowerBound;
            this.Capacity = array.Length;
            Offset = LowerBound;
            array.CopyTo(this.array, 0);
        }
        public MyArray(MyArray<T> array)
        {
            if (array == null || array.Capacity < 1) throw new ArgumentException("Input array is empty");
            this.Capacity = array.Capacity;
            this.LowerBound = array.LowerBound;
            this.Offset = LowerBound;
            this.array = new T[this.Capacity];
            array.CopyTo(this);
        }
        #endregion

        #region Methods
        public void CopyTo(T[] array)
        {
            if (array.Length < this.Capacity) throw new ArgumentException("Capacity of target array must be greater or equal to this array");
            
            for(int i = 0;i<this.Capacity;i++)
            {
                array[i] = this.array[i];
            }
        }
        public void CopyTo(MyArray<T> array)
        {
            if (array.Capacity < this.Capacity) throw new ArgumentException("Capacity of target array must be greater or equal to this array");
            for(int i = 0, k = array.LowerBound; i < this.Capacity; i++, k++)
            {
                array[k] = this.array[i];
            }
        }
        #endregion

        #region Implementations
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < LowerBound || index > Capacity + LowerBound - 1) throw new IndexOutOfRangeException($"Index out of range. Acceptable range: [{LowerBound};{LowerBound + Capacity - 1}]");
                return array[index - Offset];
            }
            set
            {
                if (index < LowerBound || index > Capacity + LowerBound - 1) throw new IndexOutOfRangeException($"Index out of range. Acceptable range: [{LowerBound};{LowerBound + Capacity - 1}]");
                array[index - Offset] = value;
            }
        }
        #endregion

    }
}
