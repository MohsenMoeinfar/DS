using System;

class Program
{
    static void Main()
    {
        string SNumber = Console.ReadLine();
        long Number = long.Parse(SNumber);

        long[] Starts = new long[Number];
        long[] Finsishes = new long[Number];

        for (long i = 0; i < Number; i++)
        {
            string[] SF = Console.ReadLine().Split();
            Starts[i] = long.Parse(SF[0]);
            Finsishes[i] = long.Parse(SF[1]);
        }
        Array.Sort(Finsishes, Starts);
        long Res1 = 1  ; 
        string Ans = "" ; 
        long tmp = 0 ; 
        long finish = Finsishes[0] ;
        Ans = Ans + finish + " " ;  
        for(int k = 0 ; k < Number-1 ;  k++)
        {
            if(finish >= Starts[k+1] )
            {
                if(tmp == 0 )
                {
                    
                    tmp++ ; 
                }
            }
            else
            {
                
                finish = Finsishes[k+1] ;
                Ans = Ans + finish + " " ; 
                Res1++ ; 
                tmp = 0  ; 
            }
        }
       
        Console.WriteLine(Res1) ; 
        Console.WriteLine(Ans) ;
    }
}