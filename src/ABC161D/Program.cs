﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC161D.Input;

namespace ABC161D
{
    static class Input
    {
        private static Func<string, T[]> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToArray();

        private static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(string[])) return _ => (T) (object) _.Split(' ');
            if (t == typeof(int[])) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(long[])) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(double[])) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        private static T Convert<T>(string s) => Convert<T>()(s);

        private static string String() => Console.ReadLine();

        private static string[] String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToArray();

        public static void Cin<T>(out T a) => a = Convert<T>(String());

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
            set(v[5], out a6);
        }

        private static void set<T1>(string s, out T1 o1) => o1 = Convert<T1>(s);

        public static void Cin<T>(long n, out T[] l) => l = String(n).Select(Convert<T>()).ToArray();

        public static void Cin<T1, T2>(long n, out T1[] l1, out T2[] l2)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i]);
        }

        public static void Cin<T1, T2, T3>(long n, out T1[] l1, out T2[] l2, out T3[] l3)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i]);
        }

        public static void Cin<T1, T2, T3, T4>(long n, out T1[] l1, out T2[] l2, out T3[] l3, out T4[] l4)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            l4 = new T4[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i], out l4[i]);
        }

        public static void Cin<T>(out T[] a) => a = Convert<T[]>(String());

        public static void Cin<T>(long h, out T[][] map) => map = String(h).Select(Convert<T[]>()).ToArray();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(streamWriter);
            new Solver().Solve();
            Console.Out.Flush();
        }

        public static void Debug()
        {
            new Solver().Solve();
        }
    }

    class Solver
    {
        public void Solve()
        {
            long k;
            Cin(out k);
            dfs("1");
            dfs("2");
            dfs("3");
            dfs("4");
            dfs("5");
            dfs("6");
            dfs("7");
            dfs("8");
            dfs("9");
            runrun.Sort();
            Console.WriteLine(runrun[(int) k - 1]);
        }
        List<long> runrun = new List<long>();


        void dfs(string cur)
        {
            runrun.Add(long.Parse(cur));
            if (cur.Length > 10) return;
            var last = cur.Last();
            switch (last)
            {
                case '0':
                    dfs(cur + '0');
                    dfs(cur + '1');
                    break;
                case '1':
                    dfs(cur + '0');
                    dfs(cur + '1');
                    dfs(cur + '2');
                    break;
                case '2':
                    dfs(cur + '1');
                    dfs(cur + '2');
                    dfs(cur + '3');
                    break;
                case '3':
                    dfs(cur + '2');
                    dfs(cur + '3');
                    dfs(cur + '4');
                    break;
                case '4':
                    dfs(cur + '3');
                    dfs(cur + '4');
                    dfs(cur + '5');
                    break;
                case '5':
                    dfs(cur + '4');
                    dfs(cur + '5');
                    dfs(cur + '6');
                    break;
                case '6':
                    dfs(cur + '5');
                    dfs(cur + '6');
                    dfs(cur + '7');
                    break;
                case '7':
                    dfs(cur + '6');
                    dfs(cur + '7');
                    dfs(cur + '8');
                    break;
                case '8':
                    dfs(cur + '7');
                    dfs(cur + '8');
                    dfs(cur + '9');
                    break;
                case '9':
                    dfs(cur + '8');
                    dfs(cur + '9');
                    break;
            }
        }

    }
}