using System;

public class Program
{
    public static long NewMerge(long[] MyArr)
    {
        if (MyArr.Length <= 1)
            return 0;

        long count = 0;
        int mid = MyArr.Length / 2;
        long[] left = new long[mid];
        long[] right = new long[MyArr.Length - mid];

        for (long i = 0; i < left.Length; i++)
        {
            left[i] = MyArr[i];
        }

        for (long i = 0; i < right.Length; i++)
        {
            right[i] = MyArr[i + left.Length];
        }

        count += NewMerge(left);
        count += NewMerge(right);
        count += Goal(MyArr, left, right);

        return count;
    }

    public static long Goal(long[] MyArr, long[] left, long[] right)
    {
        long count = 0;
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                MyArr[k] = left[i];
                i++;
            }
            else
            {
                MyArr[k] = right[j];
                count += left.Length - i;
                j++;
            }
            k++;
        }

        while (i < left.Length)
        {
            MyArr[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            MyArr[k] = right[j];
            j++;
            k++;
        }

        return count;
    }

    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        long[] numbers = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long ans = NewMerge(numbers);
        Console.WriteLine(ans);
    }
}