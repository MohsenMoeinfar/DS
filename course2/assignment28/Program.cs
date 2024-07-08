using System;
using System.Collections.Generic;
public class Program
{
    static void Main()
    {
        long Number = long.Parse(Console.ReadLine());
        long[] Ans = new long[Number + 1];
        long[] Goals = new long[Number + 1];
        for (int i = 0; i <= Number; i++)
        {
            if (i < 2)
            {
                Goals[i] = 0;
                Ans[i] = 0;
            }
            else
            {
                Goals[i] = Goals[i - 1] + 1;
                Ans[i] = i - 1;
                if (i % 2 == 0 && Goals[i / 2] + 1 < Goals[i])
                {
                    Goals[i] = Goals[i / 2] + 1;
                    Ans[i] = i / 2;
                }
                if (i % 3 == 0 && Goals[i / 3] + 1 < Goals[i])
                {
                    Goals[i] = Goals[i / 3] + 1;
                    Ans[i] = i / 3;
                }
            }
        }
        List<long> Res = new List<long> { };
        long Last = Ans[Number];
        Res.Add(Number);
        for (long i = Last; i >= 1; i = Ans[i])
        {
            Res.Add(i);
        }
        Res.Reverse();
        Console.WriteLine(Goals[Number]);
        Console.WriteLine(string.Join(" ", Res));
    }
}