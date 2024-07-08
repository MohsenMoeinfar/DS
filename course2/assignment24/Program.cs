using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void MergeSortForSegments(List<Tuple<int, int>> Segments)
{
    if (Segments.Count <= 1)
        return;

    int Mid = Segments.Count / 2;
    List<Tuple<int, int>> Left = new List<Tuple<int, int>>();
    List<Tuple<int, int>> Right = new List<Tuple<int, int>>();

    for (int i = 0; i < Mid; i++)
        Left.Add(Segments[i]);

    for (int i = Mid; i < Segments.Count; i++)
        Right.Add(Segments[i]);

    MergeSortForSegments(Left);
    MergeSortForSegments(Right);

    MergeSeg(Segments, Left, Right);
}

static void MergeSeg(List<Tuple<int, int>> Segments, List<Tuple<int, int>> Left, List<Tuple<int, int>> Right)
{
    int i = 0, j = 0, k = 0;

    while (i < Left.Count && j < Right.Count)
    {
        if (Left[i].Item1 >= Right[j].Item1)
        {
            Segments[k] = Left[i];
            i++;
        }
        else
        {
            Segments[k] = Right[j];
            j++;
        }
        k++;
    }

    while (i < Left.Count)
    {
        Segments[k] = Left[i];
        i++;
        k++;
    }

    while (j < Right.Count)
    {
        Segments[k] = Right[j];
        j++;
        k++;
    }
}
    static void Main(string[] args)
    {
        string[] Input = Console.ReadLine().Split(' ');
        int s = int.Parse(Input[0]);
        int p = int.Parse(Input[1]);
        List<Tuple<int, int>> v = new List<Tuple<int, int>>();
        for (int i = 0; i < s; i++)
        {
            Input = Console.ReadLine().Split(' ');
            int x = int.Parse(Input[0]);
            int y = int.Parse(Input[1]);
            v.Add(new Tuple<int, int>(x, 1));
            v.Add(new Tuple<int, int>(y + 1, -1));
        }
        List<Tuple<int, int>> Ps = new List<Tuple<int, int>>();
        string[] PointsInput = Console.ReadLine().Split();
        for (int i = 0; i < p; i++)
        {
            int x = int.Parse(PointsInput[i]);
            Ps.Add(new Tuple<int, int>(x, i));
        }
        MergeSortForSegments(v) ;
        Ps.Sort();
        int Count = 0;
        int[] Ans = new int[p];
        foreach (var x in Ps)
        {
            while (v.Count > 0 && v.Last().Item1 <= x.Item1)
            {
                Count += v.Last().Item2;
                v.RemoveAt(v.Count - 1);
            }
            Ans[x.Item2] = Count;
        }
        foreach (var x in Ans)
        {
            Console.Write(x + " ");
        }
    }
}