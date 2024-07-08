using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read the number of people
        int n = int.Parse(Console.ReadLine());

        // Read the tablemates
        int[] tablemates = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Read the gifts
        int[] gifts = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Create an array to store gifts for each table
        int[] tableGifts = new int[n];

        // Calculate gifts for each table
        for (int i = 0; i < n; i++)
        {
            int table = i + 1;
            int person = i + 1;
            while (tablemates[person - 1] != person)
            {
                table += tablemates[person - 1];
                person = tablemates[person - 1];
            }
            tableGifts[table - 1] += gifts[i];
        }

        foreach (var gift in tableGifts)
        {
            Console.WriteLine(gift);
        }
    }
}
