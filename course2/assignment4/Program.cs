using System;
class Program
{
    static void Main(string[] args)
    {
        long First = 0  ; 
        long Second = 1 ; 
        long Prev ; 
        long Number = long.Parse(Console.ReadLine()) ; 
        if(Number == First || Number == Second)
        {
            Console.WriteLine(Number) ; 
        }
        else                              
        {
            for(int i = 2  ; i <= Number ; i++)
            {
                Prev = Second%10 ; 
                Second = Second%10 + First%10   ; 
                First = Prev%10  ;
            }
            Console.WriteLine(Second%10) ; 
        }
    }
}


