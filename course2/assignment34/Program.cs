using System;
class Program
{
    static long Calculate(long a, char Opt, long b)
    {
        switch (Opt)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            default:
                return 0 ; 
        }
    }
    static (long, long) MinAndMax(long i, long j, char[] Ops, long[,] m, long[,] M)
    {
        long min = long.MaxValue;
        long max = long.MinValue;
        for (long k = i; k <= j - 1; k++)
        {
            long MaxMax = Calculate(M[i, k], Ops[k], M[k + 1, j]);
            long MaxMin = Calculate(M[i, k], Ops[k], m[k + 1, j]);
            long MinMax = Calculate(m[i, k], Ops[k], M[k + 1, j]);
            long MinMin = Calculate(m[i, k], Ops[k], m[k + 1, j]);
            min = Math.Min(Math.Min(Math.Min(min, MaxMax), MaxMin), Math.Min(MinMax, MinMin));
            max = Math.Max(Math.Max(Math.Max(max, MaxMax), MaxMin), Math.Max(MinMax, MinMin));
        }
        return (min, max);
    }
    static long MaxExp(string Exp)
    {
        long n = Exp.Length / 2 + 1;
        long[,] m = new long[n, n];
        long[,] M = new long[n, n];
        long[] numbers = new long[n];
        char[] Ops = new char[n - 1];
        long z = 0 , q = 0;
        for (int i = 0; i < Exp.Length; i++)
        {
            if (i % 2 == 0)
                numbers[z++] = long.Parse(Exp[i].ToString());
            else
                Ops[q++] = Exp[i];
        }
        for (long i = 0; i < n; i++)
        {
            m[i, i] = numbers[i];
            M[i, i] = numbers[i];
        }
        for (long s = 1; s < n; s++)
        {
            for (long i = 0; i < n - s; i++)
            {
                long j = i + s;
                (long min, long max) = MinAndMax(i, j, Ops, m, M);
                m[i, j] = min;
                M[i, j] = max;
            }
        }
        return M[0, n - 1];
    }
    static void Main()
    {
        string Exp = Console.ReadLine() ; 
        long Res = MaxExp(Exp);
        Console.WriteLine(Res);
    }
}