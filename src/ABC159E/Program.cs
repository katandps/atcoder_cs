﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC159E.Input;

namespace ABC159E
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
            if (t == typeof(string[])) return _ => (T) (object) Cast<string>()(_);
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
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = Convert<string[]>(String());
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
        private int H;
        private int W;
        private long K;
        private string[] S;

        public void Solve()
        {
            Cin(out H, out W, out K);
            Cin(H, out S);

            long[][] wh = new long[H][];
            for (int i = 0; i < H; i++)
            {
                wh[i] = new long[W];
                for (int j = 0; j < W; j++)
                {
                    bool white = S[i][j] == '1';
                    wh[i][j] = white ? 1 : 0;
                }
            }

            long ans = H * W;
            //hについて、h[i]とh[i+1]の間が切れているかどうかのbit全探索 512*10*10000なので間に合うはず...
            long hcut = (long) Math.Pow(2, H - 1);
            for (int i = 0; i < hcut; i++)
            {
                long cut = 0;
                long[] block = new long[H];

                var t = i;
                for (int k = 0; k < H; k++)
                {
                    if (t % 2 == 1) cut++;
                    t = t >> 1;
                }

                // ヨコに見て、ホワイトの合計がKを超える瞬間に切る = 現在の状態を新しくして、分割回数を増やす
                var alreadyCut = false;
                for (int j = 0; j < W; j++)
                {
                    t = i;
                    var y = 0;
                    for (int k = 0; k < H; k++)
                    {
                        block[y] += wh[k][j];
                        if (t % 2 == 1) y++;
                        t = t >> 1;
                    }

                    bool shouldCut = false;
                    foreach (long l in block)
                    {
                        if (l > K)
                        {
                            shouldCut = true;
                            break;
                        }
                    }

                    if (shouldCut && alreadyCut)
                    {
                        cut = H * W;
                        break;
                    }

                    if (shouldCut)
                    {
                        cut++;
                        block = new long[H];
                        j -= 1;
                        alreadyCut = true;
                    }
                    else
                    {
                        alreadyCut = false;
                    }
                }

                ans = Math.Min(ans, cut);
            }

            Console.WriteLine(ans);
        }
    }
}