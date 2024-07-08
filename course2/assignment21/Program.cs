
using System;
using System.Collections.Generic ;
using Microsoft.VisualBasic;
class Program
{
    static void MergeSort(long[] Numbers)
    {
        if (Numbers.Length <= 1)
            return;

        long mid = Numbers.Length / 2;
        long[] left = new long[mid];
        long[] right = new long[Numbers.Length - mid];

        for (long i = 0; i < mid; i++)
        {
            left[i] = Numbers[i];
        }

        for (long i = mid; i < Numbers.Length; i++)
        {
            right[i - mid] = Numbers[i];
        }

        MergeSort(left);
        MergeSort(right);
        Merge(Numbers, left, right);
    }

    static void Merge(long[] Numbers, long[] left, long[] right)
    {
        long i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                Numbers[k] = left[i];
                i++;
            }
            else
            {
                Numbers[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < left.Length)
        {
            Numbers[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            Numbers[k] = right[j];
            j++;
            k++;
        }
    }

    static void Main(string[] args)
    {
        long Number =  long.Parse(Console.ReadLine()) ; 
        string[] Mystr = Console.ReadLine().Split() ; 
        long[] goals = Array.ConvertAll(Mystr , long.Parse) ; 
        MergeSort(goals) ;
        foreach(var i in goals)
        {
            Console.Write(i) ; 
            Console.Write(" ") ; 
        }
    }
}