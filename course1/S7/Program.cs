using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    static long Find(long x , long[] parents)
    {
        if (x != parents[x])
            parents[x] = Find(parents[x] , parents);
        return parents[x];
    }
    static long Merge(long destination, long source , long[] rank , long[] sizes , long[] parents)
    {
        long rootofdest = Find(destination ,parents);
        long rootofsource = Find(source , parents);

        if (rootofdest == rootofsource)
            return sizes[rootofdest];

        if (rank[rootofdest] < rank[rootofsource])
        {
            parents[rootofdest] = rootofsource;
            sizes[rootofsource] += sizes[rootofdest];
            return sizes[rootofsource];
        }
        else
        {
            parents[rootofsource] = rootofdest;
            sizes[rootofdest] += sizes[rootofsource];

            if (rank[rootofdest] == rank[rootofsource])
                rank[rootofdest]++;

            return sizes[rootofdest];
        }
    }
    static void Main()
    {
        string[] Inp = Console.ReadLine().Split();
        long n = long.Parse(Inp[0]);
        long m = long.Parse(Inp[1]);
        long[] parents = new long[n];
        long[] sizes = new long[n];
        long[] rank = new long[n];
        List<long> ans = new List<long> { };
        long[] rows = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        for (long i = 0; i < n; i++)
        {
            rank[i] = 0;
            parents[i] = i;
            sizes[i] = rows[i];
        }
        long max = rows.Max();
        for (long i = 0; i < m; i++)
        {
            string[] inp = Console.ReadLine().Split();
            long destination = long.Parse(inp[0]) - 1;
            long source = long.Parse(inp[1]) - 1;
            long changedsize = Merge(destination, source , rank , sizes , parents);
            max = Math.Max(max, changedsize);
            ans.Add(max);
        }
        foreach (var i in ans)
        {
            Console.WriteLine(i);
        }
    }
}

