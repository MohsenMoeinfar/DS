using System ;
using System.Collections.Generic;
public class Program
{
    static void SiftDown(long numI , long[] arr , List<Tuple<long,long>> saver)
    {
        long minI   = numI ; 
        long left = 2 * numI + 1 ; 
        long right = 2 * numI +2  ;
        if(left < arr.Length  && arr[left] < arr[minI])
        {
            minI = left ; 
        }
        if(right < arr.Length  && arr[right] < arr[minI])
        {
            minI = right ; 
        }
        if(numI != minI)
        {
            Tuple<long,long> hom  = new Tuple<long,long>(numI , minI) ; 
            saver.Add(hom)  ; 
            long tmp  = arr[numI] ; 
            arr[numI]  = arr[minI] ; 
            arr[minI] = tmp ; 
            SiftDown(minI , arr , saver) ; 
        }

    }
    static List<Tuple<long,long>> createheap(long[] arr , List<Tuple<long,long>> saver)
    {
        for(long i = arr.Length/2 -1  ; i>= 0 ; i--)
        {
            SiftDown(i , arr, saver) ; 
        }
        return saver ; 
    }
    static void Main()
    {
        long inpnumI = long.Parse(Console.ReadLine()) ; 
        long[] Inparr = Array.ConvertAll(Console.ReadLine().Split() , long.Parse); 
        List<Tuple<long,long>> saver = new List<Tuple<long, long>>{} ; 
        saver =  createheap(Inparr , saver) ; 
        Console.WriteLine(saver.Count) ;
        foreach(var i in saver)
        {
            Console.WriteLine($"{i.Item1} {i.Item2}"); 
        }
    
    }
}