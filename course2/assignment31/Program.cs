using System ; 
public class Program
{
    static void Main()
    {
        long Number = long.Parse(Console.ReadLine()) ; 
        string[] MyStr1arr = Console.ReadLine().Split() ; 
        long Number2 = long.Parse(Console.ReadLine()) ;  
        string[] Mystr2arr = Console.ReadLine().Split() ; 
        long Number3 = long.Parse(Console.ReadLine()) ;  
        string[] Mystr3arr = Console.ReadLine().Split() ; 
        long[, , ] SaveArr = new long[Number+1, Number2+1 , Number3+1] ;
        for(long i = 0 ;  i<= Number ; i++)
        {
            for(long j = 0 ; j <= Number2 ; j++ )
            {
                for(long k = 0 ; k <= Number3 ; k++)
                {
                    if(i==0 || j==0 || k==0)
                    {
                        SaveArr[i,j,k] = 0 ; 
                    }
                    else if(MyStr1arr[i-1] == Mystr2arr[j-1] && MyStr1arr[i-1] == Mystr3arr[k-1])
                    {
                        SaveArr[i,j,k] = SaveArr[i-1 , j-1 ,k-1] + 1 ; 
                    }
                    else
                    {
                        SaveArr[i,j,k] = Math.Max(Math.Max(SaveArr[i-1 , j , k] , SaveArr[i , j-1 , k]) , SaveArr[i , j , k-1]) ; 
                    }
                }
            }
        }
        Console.WriteLine(SaveArr[Number ,Number2 , Number3]) ; 
    }
}