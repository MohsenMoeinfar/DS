using System;
class Program
{
    static void Main(string[] args)
    {
        string My2Number = Console.ReadLine();
        string[] mygoals = My2Number.Split(" ");
        int Num1 = int.Parse(mygoals[0]);
        int Num2 = int.Parse(mygoals[1]);
        int Sum = Num1 + Num2;
        Console.WriteLine(Sum);
        
    }
}

