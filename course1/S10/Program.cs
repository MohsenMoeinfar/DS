using System;
using System.Collections.Generic;

public class Program
{
    static long hashfunc(string s, long m)
    {
        long p = 1000000007;
        long x = 263;
        long hashval = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            hashval = (hashval * x + s[i]) % p;
        }
        hashval = hashval % p;
        return hashval  % m;
    }
    static void Add(string s, List<string>[] hashtable, long m)
    {
        long index = hashfunc(s, m);
        if (!hashtable[index].Contains(s))
        {
            hashtable[index].Insert(0, s);
        }
    }
    static bool Find(string s, List<string>[] hashtable, long m)
    {
        long index = hashfunc(s, m);
        return hashtable[index].Contains(s);
    }

    static void Delete(string s, List<string>[] hashtable, long m)
    {
        long index = hashfunc(s, m);
        hashtable[index].Remove(s);
    }
    static List<string> Check(long i, List<string>[] hashtable)
    {
        return hashtable[i];
    }
    static void Main()
    {
        long m = long.Parse(Console.ReadLine());
        long numberqu = long.Parse(Console.ReadLine());
        List<string>[] hashtable = new List<string>[m];
        for (long i = 0; i < m; i++)
        {
            hashtable[i] = new List<string>();
        }
        for (long i = 0; i < numberqu; i++)
        {
            string[] qu = Console.ReadLine().Split();
            string op = qu[0];
            string val = qu[1];
            if (op == "add")
            {
                Add(val, hashtable, m);

            }
            else if (op == "del")
            {
                Delete(val, hashtable, m);

            }
            else if (op == "find")
            {
                if (Find(val, hashtable, m) == true)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }

            }
            else if (op == "check")
            {
                long index = long.Parse(val);
                List<string> samechain = Check(index, hashtable);
                Console.WriteLine(string.Join(" ", samechain));
            }
        }
    }
}