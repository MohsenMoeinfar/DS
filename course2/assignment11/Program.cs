using System;
class Program
{
    static int Calc(long N)
    {
        int Sum = 0  ;
        while(N > 0)
        {
        if(N >= 10)
        {
            Sum ++ ; 
            N = N - 10  ;

        }
        else if(N>= 5 && N <10)
        {
            Sum ++ ; 
            N = N - 5 ; 

        }
        else
        {
            Sum ++ ;  
            N = N -1 ;

        }
     
        }
        return Sum  ; 


    }
    static void Main(string[] args)
    {
        
        string Input = Console.ReadLine();
        long Number  = long.Parse(Input) ; 
        int Res = Calc(Number) ; 
        Console.WriteLine(Res) ; 
    }
}

