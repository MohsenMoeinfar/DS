using System;
class Program
{
    static double Cal(double Cap, double[] Weights, double[] Values)
    { 
        double Sum = 0;
        int[] Indexes = new int[Weights.Length];
        for (int i = 0; i < Weights.Length; i++)
        {
            Indexes[i] = i;
        }
        Array.Sort(Indexes, (x, y) => (Values[y] / Weights[y]).CompareTo(Values[x] / Weights[x]));
        foreach (var Index in Indexes)
        {
            if (Cap == 0)
                return Sum;
            double Tmp = Math.Min(Weights[Index], Cap);
            Sum += Tmp * (double)Values[Index] / Weights[Index];
            Cap -= Tmp;
        }
        return Sum;
    }
    
    static void Main(string[] args)
    {
        string[] Inp = Console.ReadLine().Split(' ');
        int N = int.Parse(Inp[0]);
        double Cap = double.Parse(Inp[1]);
        double[] Values = new double[N];
        double[] Weights = new double[N];
        for (int i = 0; i < N; i++)
        {
            string[] Inp2 = Console.ReadLine().Split(' ');
            Values[i] = double.Parse(Inp2[0]);
            Weights[i] = double.Parse(Inp2[1]);
        }
        double Ans = Cal(Cap, Weights, Values);
        Console.WriteLine(Ans.ToString("F4"));
    }
}