using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int c = 0;
        while (c * (c + 1) / 2 < n && n - c * (c + 1) / 2 > c)
        {
            c++;
        }
        c--;
        Console.WriteLine(c + 1);
        for (int i = 0; i < c; i++)
        {
            Console.Write(i + 1 + " ");
        }
        Console.Write(n - c * (c + 1) / 2);
    }
}