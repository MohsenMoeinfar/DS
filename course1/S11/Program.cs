using System;
using System.Collections.Generic;
public class Program
{
    public static long P = 1000000007;
    public static long X = 269;
    static void Main()
    {
        string ptrn = Console.ReadLine();
        string txt = Console.ReadLine();
        List<long> tekrar = RabinKarp(ptrn, txt);
        foreach (var tk in tekrar)
        {
            Console.Write(tk + " ");
        }
    }
    static long hashfunc(string s, int lngth)
    {
        long hashval = 0;
        for (int i = lngth - 1; i >= 0; i--)
        {
            hashval = (hashval * X + s[i]) % P;
        }
        return hashval;
    }
    static List<long> RabinKarp(string ptrn, string txt)
    {
        long txtlngth = txt.Length;
        int ptrnlngth = ptrn.Length;
        List<long> Res = new List<long>();
        long[] txthashes = PrecomputeHashes(txt, ptrnlngth);
        long ptrnhash = hashfunc(ptrn, ptrnlngth);
        for (int i = 0; i <= txtlngth - ptrnlngth; i++)
        {
            if (ptrnhash != txthashes[i] && ptrnhash != txthashes[i] + P)
            {
                continue;

            }
            if (txt.Substring(i, ptrnlngth) == ptrn)
            {
                Res.Add(i);
            }
        }
        return Res;
    }
    static long[] PrecomputeHashes(string txt, int ptrnlngth)
    {
        int txtlngth = txt.Length;
        long[] hashes = new long[txtlngth - ptrnlngth + 1];
        string lastptrn = txt.Substring(txtlngth - ptrnlngth, ptrnlngth);
        hashes[txtlngth - ptrnlngth] = hashfunc(lastptrn, ptrnlngth);
        long y = 1;
        for (long i = 1; i <= ptrnlngth; i++)
        {
            y = (y * X) % P;
        }

        for (int i = txtlngth - ptrnlngth - 1; i >= 0; i--)
        {
            hashes[i] = (X * hashes[i + 1] + txt[i] - y * txt[i + ptrnlngth]) % P;
        }
        return hashes;
    }
}
