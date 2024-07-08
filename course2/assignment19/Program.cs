using System;
class Program
{ 
    static long BiSearch(long[] Inp1, long key)
  {
    long low = 0 ; 
    long high = Inp1.Length-1 ;
    while (high >= low)
    {
        long mid = (low + high) / 2;
        if (key == Inp1[mid])
        {
            return mid;
        }
        else if (key < Inp1[mid])
        {
            high = mid - 1;
        }
        else
        {
            low = mid + 1;
        }
    }

     return -1;
  }
   static long BiSearchCounter(long[] Inp1, long key)
  {
    long low = 0 ; 
    long Goal  = -1 ;
    long high = Inp1.Length-1 ;
    while (high >= low)
    {
        long mid = (low + high) / 2 ;
        if (key == Inp1[mid])
        {
               Goal =mid ;
               high = mid -1 ; 
              

            
        }
        else if (key < Inp1[mid])
        {
            high = mid - 1;
        }
        else
        {
            low = mid + 1;
        }
    }

     return Goal ; 
  }
    static void Main(string[] args)
    {
        long L1 = long.Parse(Console.ReadLine()) ; 
        string InputOne = Console.ReadLine() ;
        long L2 = long.Parse(Console.ReadLine()) ; 
        string InputTwo = Console.ReadLine() ;
        long[] Ans = new long[L2] ;
        long[] inp1 = Array.ConvertAll(InputOne.Split(), long.Parse);
        long[] inp2 = Array.ConvertAll(InputTwo.Split(), long.Parse);
        long High = inp1.Length-1;
        for(long i = 0 ; i <  L2 ; i++)
        {
            long count  = BiSearchCounter(inp1 ,inp2[i]) ; 
            Ans[i] = count ;
                
          
        }
        foreach(var i in Ans)
        {
            Console.Write(i) ;
            Console.Write(" ") ;
        }
        // Console.WriteLine(BiSearchCounter(inp1 , 2));
    }
}