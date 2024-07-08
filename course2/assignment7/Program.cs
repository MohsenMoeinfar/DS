using System;
class Program
{
    static long Fibonacci(long Number, long m)
    {
        long First = 0;
        long Second = 1;
        long Per = Number % Period(m);
        if(Per != 0 && Per!= 1)
        {
        for (long i = 2; i <= Per; i++)
         {
            long Temp = (First + Second) % m;
            First = Second%m ;
            Second = Temp%m ;

         }
              return Second % m;
        }
        else
        {
            if(Per == 0)
            {
                return First ; 
            }
            else
            {
                return Second;
            }
        }


    }
    static long Period(long m)
    {
        long First = 0;
        long Second = 1;
        long Temp;
        long i;
        for (i = 0; i < m * m; i++)
        {
            Temp = (First + Second) % m;
            First = Second;
            Second = Temp;
            if (First == 0 && Second == 1)
            {
                return i + 1;
            }
        }
        return i + 1;
    }

    static void Main(string[] args)
    {
        string Input = Console.ReadLine();
        string[] Numbers = Input.Split(" ");
        long Number = long.Parse(Numbers[0]);
        long m = long.Parse(Numbers[1]);
        long Res = Fibonacci(Number, m);
        Console.WriteLine(Res);
    }
}