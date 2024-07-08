using System;
using System.Collections.Generic;
class Program
{
    static double Distance(Tuple<int, int> Point1, Tuple<int, int> Point2)
    {
        return Math.Sqrt(Math.Pow(Point1.Item1 - Point2.Item1, 2) + Math.Pow(Point1.Item2 - Point2.Item2, 2));
    }
    static double MinimalDistance(Tuple<int, int>[] Points, int Left, int Right)
    {
        if (Right - Left <= 2)
        {
            return FClosest(Points, Left, Right);
        }
        int Mid = (Left + Right) / 2;
        double LeftMin = MinimalDistance(Points, Left, Mid);
        double RightMin = MinimalDistance(Points, Mid, Right);
        double MinDist = Math.Min(LeftMin, RightMin);
        var Tmp = new List<Tuple<int, int>>();
        for (int i = Left; i < Right; i++)
        {
            if (Math.Abs(Points[i].Item1 - Points[Mid].Item1) < MinDist)
            {
                Tmp.Add(Points[i]);
            }
        }
        Tmp.Sort((Point1, Point2) => Point1.Item2.CompareTo(Point2.Item2));
        for (int i = 0; i < Tmp.Count; i++)
        {
            for (int j = i + 1; j < Tmp.Count && (Tmp[j].Item2 - Tmp[i].Item2) < MinDist; j++)
            {
                double Dis = Distance(Tmp[i], Tmp[j]);
                if (Dis < MinDist)
                {
                    MinDist = Dis;
                }
            }
        }
        return MinDist;
    }
    static double FClosest(Tuple<int, int>[] Points, int Left, int Right)
    {
        double Min = double.MaxValue;
        for (int i = Left; i < Right; ++i)
        {
            for (int j = i + 1; j < Right; ++j)
            {
                double Dis = Distance(Points[i], Points[j]);
                if (Dis < Min)
                {
                    Min = Dis;
                }
            }
        }
        return Min;
    }
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Tuple<int, int>[] Points = new Tuple<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            string[] Input = Console.ReadLine().Split();
            int x = int.Parse(Input[0]);
            int y = int.Parse(Input[1]);
            Points[i] = new Tuple<int, int>(x, y);
        }
        Array.Sort(Points, (Point1, Point2) => Point1.Item1.CompareTo(Point2.Item1));
        double Ans = MinimalDistance(Points, 0, n);
        Console.WriteLine($"{Ans:F4}");
    }
}
