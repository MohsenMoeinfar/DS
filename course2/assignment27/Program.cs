using System ;
public class Program
{
    static void Main()
    {
        long Input  = long.Parse(Console.ReadLine()) ; 
        long Ans = Counter(Input) ; 
        Console.WriteLine(Ans) ;
    }
    private static long Counter(long Money)
    {
        int[] Coins = new int[]{1,3,4} ; 
        long[] Mo = new long[Money+1] ; 
        Mo[0] = 0 ; 
        for(int i = 1 ; i <= Money ; i++)
        {
            Mo[i]  = long.MaxValue ; 
            foreach(var j in Coins)
            {
                if(i >= j)
                {
                    long Money2 = Mo[i - j] + 1 ; 
                    if(Money2 < Mo[i])
                    {
                        Mo[i] = Money2 ; 
                    }
                }
            }
        }
        return Mo[Money] ; 
    }
}