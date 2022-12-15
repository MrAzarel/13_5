using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace _13_5
{
    class MyCount
    {
        public static int a = 0;
        public static int b = 1;
        public void NormalCount()
        {
            Stopwatch stopwatch = new Stopwatch();
            int n = 0;
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                n += i;
            stopwatch.Stop();
            Console.WriteLine("Одним потоком: " + stopwatch.Elapsed);
        }

        public void ManyThreadingCount()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(Work);
                threads.Add(thread);
                Thread.Sleep(10);
            }
            stopwatch.Start();
            foreach (var item in threads)
                item.Start();
            stopwatch.Stop();
            Console.WriteLine("100 потоков: " + stopwatch.Elapsed);
        }

        void Work()
        {
            for (int i = 0; i < 10000; i++)
            {
                a += b;
                b++;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            MyCount myCount = new MyCount();
            myCount.NormalCount();
            myCount.ManyThreadingCount();
        }
    }
}
