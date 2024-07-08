
using System;
using System.Collections.Generic ;
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
    static long FindMost(long[] Arr)
    {
        long  Max = 0;
        long Current = 1;
        long CurrentNum = Arr[0];
        for (long i = 1; i < Arr.Length; i++)
        {
            if (Arr[i] == CurrentNum)
            {
                Current++;
            }
            else
            {
                if (Current >  Max)
                {
                     Max = Current;
                }
                CurrentNum = Arr[i];
                Current = 1;
            }
        }
        if (Current >  Max)
        {
                Max = Current;
        }
        return  Max;
    }

    static void Main(string[] args)
    {
        long Number = long.Parse(Console.ReadLine()) ;
        long[] Numbers = new long[Number] ; 
        Numbers = Array.ConvertAll(Console.ReadLine().Split() , long.Parse) ; 
        MergeSort(Numbers) ; 
        long count = 1 ; 
        long Goal  = Number/2 ; 
        List<long> Counts = new List<long>{} ; 
        long n = Numbers.Length;
        count  = FindMost(Numbers) ; 
        if (count > n / 2)
        {
            Console.WriteLine(1) ;
        }
        else
        {
            Console.WriteLine(0) ;
        }
}
}


