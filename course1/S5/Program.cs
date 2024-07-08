using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long[] nums = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long m = long.Parse(Console.ReadLine());
        long[] suff = new long[n+1];
        long[] pref = new long[n+1];
        for (long i = 0; i < n; i++)
        {
            if (i % m == 0)
            {
                pref[i] = nums[i];
            }
            else
            {
                pref[i] = Math.Max(pref[i - 1], nums[i]);
            }
        }
        for (long j = n - 1; j >= 0; j--)
        {
            if (j % m == m - 1)
            {
                suff[j] = nums[j];
            }
            else
            {
                suff[j] = Math.Max(suff[j + 1], nums[j]);
            }
        }
        for (long k = 0; k <= n - m; k++)
        {
            long max = Math.Max(suff[k], pref[k + m - 1]);
            Console.Write(max + " ");
        }
    }
}
