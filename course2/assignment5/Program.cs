using System;
class Program
{
    static void Main(string[] args)
    {
        string My2Number  = Console.ReadLine()  ; 
        string[] Numbers = My2Number.Split(" ") ; 
        long N1 = int.Parse(Numbers[0]) ; 
        long N2 = int.Parse(Numbers[1]) ; 
        while(N1 != 0 && N2 != 0)
        {
            if(N1 >= N2)
            {
                N1 = N1 % N2  ; 
            }
            else
            {
                N2 = N2 % N1 ; 

            }
        }
        if(N1 == 0)
        {
            Console.WriteLine(N2) ;
        }
        else
        {
            Console.WriteLine(N1) ; 
        }
    }
}



