using System;

class Program
{
    static void Swap(long[] MyArr , long N1 , long N2)
    {
        long temp = MyArr[N1] ; 
        MyArr[N1] = MyArr[N2] ; 
        MyArr[N2] = temp  ;
    }
    static (int M1 , int M2) Partition(long[] MyArr , long Start , long Finsih)
    {
        long Pivot = MyArr[Start] ; 
        int  St = (int)Start  ;
        int Fi = (int)Finsih ; 
        long i = Start+1 ; 
        while(i <= Fi)
        {
            if(MyArr[i]< Pivot)
            {
                Swap(MyArr , i ,St) ;
                i++ ; 
                St++ ; 
            }
            else if(MyArr[i] > Pivot)
            {
                Swap(MyArr , i , Fi)  ;
                Fi-- ;
            }
            else
            {
                i++ ;
            }
        }
        return (St , Fi) ;
    }
    static void RandomizedQuickSort(long[] MyArr , int Start , int Finsih)
    {
        if(Start >= Finsih)
        {
            return ; 
        }
        int Random  = new Random().Next(Start , Finsih+1) ;
        Swap(MyArr , Start , Random) ; 
        (int M1 , int M2)  = Partition(MyArr , Start , Finsih) ; 
        RandomizedQuickSort(MyArr , Start , M1-1) ; 
        RandomizedQuickSort(MyArr , M2+1  , Finsih) ; 
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        RandomizedQuickSort(arr, 0, n - 1);
        Console.WriteLine(string.Join(" ", arr));
    }
}