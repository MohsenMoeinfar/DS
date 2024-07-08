using System;
using System.Collections.Generic;
public class Program
{
    static void computehash(string s, long x, long m1, long m2, long[] h1, long[] h2)
    {
        for (int i = 1; i <= s.Length; i++)
        {
            h1[i] = (x * h1[i - 1] + s[i - 1]) % m1;
            h2[i] = (x * h2[i - 1] + s[i - 1]) % m2;
        }
    }
    static long Pow(long x, long length, long m)
    {
        long res = 1;
        while (length > 0)
        {
            if (length % 2 == 1)
                res = (res * x) % m;
            x = (x * x) % m;
            length /= 2;
        }
        return res;
    }
    static long computesub(long start, long length, long[] h, long m, long x)
    {
        long hash = (h[start + length] - Pow(x, length, m) * h[start] + m) % m;
        return (hash + m) % m;
    }
    static void Main()
    {
        string s = Console.ReadLine();
        long qu = long.Parse(Console.ReadLine());
        long m1 = 1000000007;
        long m2 = 1000000009;
        long x = new Random().Next(1, 1000000000);
        long[] h1 = new long[s.Length + 1];
        long[] h2 = new long[s.Length + 1];
        computehash(s, x, m1, m2, h1, h2);
        for (long i = 0; i < qu; i++)
        {
            string[] query = Console.ReadLine().Split();
            long a = long.Parse(query[0]);
            long b = long.Parse(query[1]);
            long l = long.Parse(query[2]);
            long hasha1 = computesub(a, l, h1, m1, x);
            long hashb1 = computesub(b, l, h1, m1, x);
            long hasha2 = computesub(a, l, h2, m2, x);
            long hashb2 = computesub(b, l, h2, m2, x);
            if (hasha1 == hashb1 && hasha2 == hashb2)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
