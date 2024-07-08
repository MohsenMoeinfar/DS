using System;
class Program
{
    static void Main(string[] args)
    {
        //ب م م  * ک م م ==  ضرب دو عدد
        string My2Number  = Console.ReadLine()  ; 
        string[] Numbers = My2Number.Split(" ") ; 
        long N1 = long.Parse(Numbers[0]) ; 
        long N2 = long.Parse(Numbers[1]) ; 
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
            long Lcm = (long.Parse(Numbers[0]) * long.Parse(Numbers[1]) ) / N2 ; 
            Console.WriteLine(Lcm) ;
        }
        else
        {
            long Lcm = (long.Parse(Numbers[0]) * long.Parse(Numbers[1]) ) / N1 ; 
            Console.WriteLine(Lcm) ; 
        }
    }
}



