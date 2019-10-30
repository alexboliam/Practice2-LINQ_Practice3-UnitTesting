using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestInfo> tests = new List<TestInfo>() { 
                new TestInfo("Ivanov", "Ivan", "DataBase Systems №1", "10/10/2019", 50f), new TestInfo("Petrov", "Petro", "DataBase Systems №1", "10/10/2019", 88f),
                new TestInfo("Maksakov", "Maksim", "DataBase Systems №1", "10/10/2019", 90f), new TestInfo("Ivanov", "Ivan", "OLAP №2", "20/10/2019", 40f),
                new TestInfo("Petrov", "Oleg", "DataBase Systems №1", "10/10/2019", 35f), new TestInfo("Romanov", "Roman", "OLAP №2", "20/10/2019", 30f),
                new TestInfo("Kudryashov", "Kirill", "OLAP №2", "20/10/2019", 50f), new TestInfo("Bondar", "Ivan", "OLAP №2", "20/10/2019", 60f),
                new TestInfo("Koval", "Dmitry", "OLAP №2", "20/10/2019", 70f), new TestInfo("Hovan", "Jeka", "Operation qualities №1", "30/09/2019", 100f),
                new TestInfo("Roztaman", "Ivan", "Operation qualities №1", "30/09/2019", 95f), new TestInfo("Zavarniy", "Tolik", "Operation qualities №1", "30/09/2019", 94.5f)};
            
            MyBinaryTree<TestInfo> b = new MyBinaryTree<TestInfo>();

            b.OnInsert += OnTreeInsert;
            b.OnRemove += OnThreeRemove;

            foreach (var item in tests)
            {
                b.Insert(item);
            }

            foreach (var item in b)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            b.Remove(tests[3]);
            b.Remove(tests[5]);
            Console.WriteLine();

            foreach (var item in b)
            {
                Console.Write(item + " ");
            }

            
        }

        public static void OnTreeInsert<T>(object sender, MyTreeEventArgs<T> e)
        {
            Console.WriteLine("Element added to tree: " + e.Value.ToString());
        }
        public static void OnThreeRemove<T>(object sender, MyTreeEventArgs<T> e)
        {
            Console.WriteLine("Element removed from tree: " + e.Value.ToString());
        }
    }
}
