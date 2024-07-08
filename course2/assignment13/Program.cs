using System;
using System.Runtime.Intrinsics.Arm;
class Program
{
    static void Main(string[] args)
    {
        string NumStr = Console.ReadLine() ; 
        long Number = long.Parse(NumStr) ; 
        long[] Arr1 = new long[Number] ;
        long[] Arr2 = new long[Number] ;
        for(long i = 0  ; i< 2 ; i++)
        {
            if(i==0)
            {
                string[] ArrStr = Console.ReadLine().Split(' ');
                for(long k =0 ; k< Number ; k++)
                {
                    Arr1[k] = long.Parse(ArrStr[k]) ; 
                }
                
            }
               
            else
            {
                string[] ArrStr2 = Console.ReadLine().Split(' ');
                for(long j =0 ; j< Number ; j++)
                {
                    Arr2[j] = long.Parse(ArrStr2[j]) ; 
                }
            }
                
        }
        long Sum = 0  ;
        Array.Sort(Arr1) ;
        Array.Sort(Arr2) ; 
        for(long i =0 ; i < Number ; i++)
        {
            Sum = Sum + Arr1[i]*Arr2[i] ; 
        }
        Console.WriteLine(Sum) ; 
    }
}
