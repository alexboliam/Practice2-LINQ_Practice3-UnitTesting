using System;

namespace MyArray
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> myArray = new MyArray<int>(-5, 14);
            myArray[-5] = -5;
            myArray[-4] = -4;
            myArray[0] = 1000;
            myArray[8] = 8;

            foreach(var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            MyArray<string> m1 = new MyArray<string>(new string[5] { "a", "b", "c", "d", "e" });
            MyArray<string> m2 = new MyArray<string>(30, 6);
            m1.CopyTo(m2);
            foreach (var item in m2)
            {
                Console.WriteLine(item);
            }

            MyArray<string> m3 = new MyArray<string>(m1);
            Console.WriteLine();
        }
    }
}


