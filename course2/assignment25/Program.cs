using System;
using System.Linq;
    class Program
    {
        static long Count(long[][] Segments, long Point, long Left, long Right)
        {
            if (Left > Right)
            {
                return 0;
            }
            long Mid = Left + (Right - Left) / 2;
            if (Point < Segments[Mid][0])
            {
                return Count(Segments, Point, Left, Mid - 1);
            }
            else if (Point > Segments[Mid][1])
            {
                return Count(Segments, Point, Mid + 1, Right);
            }
            else
            {
                long LeftCount = Count(Segments, Point, Left, Mid - 1);
                long RightCount = Count(Segments, Point, Mid + 1, Right);

                return 1 + LeftCount + RightCount;
            }
        }
        static void Main(string[] args)
        {
            long[] Input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long s = Input[0];
            long p = Input[1];
            long[][] Segments = new long[s][];
            for (long i = 0; i < s; i++)
            {
                Segments[i] = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            }
            long[] Points = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long[] Result = new long[Points.Length];
            Array.Sort(Segments, (a, b) => a[0].CompareTo(b[0]));
            for (long i = 0; i < Points.Length; i++)
            {
                Result[i] = Count(Segments, Points[i], 0, Segments.Length - 1);
            }
            Console.WriteLine(string.Join(" ", Result));
        }
    }

