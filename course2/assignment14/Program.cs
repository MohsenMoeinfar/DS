using System ;
class Program
{
    static void Main()
    {
        long Dis = long.Parse(Console.ReadLine()) ; 
        long Bu = long.Parse(Console.ReadLine()) ; 
        long Number = long.Parse(Console.ReadLine()) ; 
        string[] Input = Console.ReadLine().Split();
        long[] St  = new long[Number+1] ; 
        for(long i = 0 ; i < Number ; i++)
           St[i] = long.Parse(Input[i]) ; 
        St[Number] = Dis ; 
        long CurStor  = Bu ; 
        long PrevStat  = 0 ; 
        long Counter = 0  ;
        long j = 0 ; 
        while(j < Number)
        {
            long CurStat = St[j] ;  
            long NextStat = St[j+1] ; 
            long Wanted = NextStat - CurStat ; 
            CurStor = CurStor - (CurStat - PrevStat) ; 
            if(Wanted >  CurStor)
            {
                CurStor = 0  ; 
                CurStor += Bu ; 
                Counter++ ; 
            }
            if(Wanted > Bu)
            {
                Counter = -1 ; 
                break ; 
            }
            PrevStat = CurStat ; 
            j++;
        }
        Console.WriteLine(Counter) ;
    }
}
