using System;
class Program
{
    static long SearchMax(long[] Numbers)
    {
        long Max1 = 0; 
        long Max2 = 0; 
        int Index1 = 0  ;
        for(int i = 0 ; i < Numbers.Length ; i++)
        {
            if(Max1 < Numbers[i]) 
            {
                Max1 = Numbers[i] ;
                Index1  = i ;  
            }
        }
        for(int j = 0 ; j < Numbers.Length ; j++)
        {
            if(Max2 < Numbers[j] && j != Index1) 
            {
                Max2 = Numbers[j] ;
                  
            }
        }
        long Ans = Max1 * Max2 ; 
        return Ans ; 
    }

    static void Main(string[] args)
    {
        long Number = long.Parse(Console.ReadLine());
        string Inp = Console.ReadLine();
        string[] StrNumbers = Inp.Split(' ');
        int n = StrNumbers.Length;
        long[] Numbers = new long[n];
        for (int i = 0; i < n; ++i)
        {
           Numbers[i] = long.Parse(StrNumbers[i]);
        }

        Console.WriteLine(SearchMax(Numbers));
    }
}