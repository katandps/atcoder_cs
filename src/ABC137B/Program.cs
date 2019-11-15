﻿using System;
using System.Linq;

namespace ABC137B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] KX = CIN.IntArray();
            for (int i = KX[1] - KX[0] + 1; i < KX[1] + KX[0]; i++)
            {
                Console.Write(i + " ");
                
            }
            Console.WriteLine("");
        }
    }

    internal static class CIN
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}