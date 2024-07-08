using System ;  
 public class Program
 {
    static void Main()
    {
        string[] MyStr1 = Console.ReadLine().Split() ; 
        long w = long.Parse(MyStr1[0]) ; 
        long I  = long.Parse(MyStr1[1]) ; 
        long[] MyW = Array.ConvertAll(Console.ReadLine().Split() , long.Parse) ; 
        long[,] Iw = new long[I+1 , w+1]  ; 
        for(int k   = 0 ;  k <= w ; k++)
        {
            Iw[0 , k] = 0 ; 
        }
        for(int k   = 0 ;  k <= I ; k++)
        {
            Iw[k , 0 ] =  0 ; 
        }
        for(int z =1  ; z <=I ; z++)
        {
            for(int q = 1 ; q<= w ; q++)
            {
                if(MyW[z-1] <= q)
                {
                  Iw[z,q] = Iw[z-1 , q- MyW[z-1]] + MyW[z-1]  ; 
                  
                   if(Iw[z,q] < Iw[z-1 ,q])
                   {
                       Iw[z,q] = Iw[z-1,q]  ;
                   }
                   
                }
                else
                {
                    Iw[z , q]  = Iw[z-1 , q] ; 
                }
            }
        }
        Console.WriteLine(Iw[I,w]) ; 
    }
 }