using System ; 
public class Program
{
    static long Output(long i , long j ,long[,] Arr , string[] S1 , string[] S2)
    {
        long count  = 0 ; 
        if(i==0 && j==0)
        {
            return 0  ;
        }
        if(i> 0 && j> 0 &&  Arr[i,j] == Arr[i-1 , j-1])
        {
            count = 1 + Output(i-1,j-1 , Arr , S1 , S2) ; 

        }
        else if(i> 0 && j> 0 &&  Arr[i,j] == Arr[i-1 , j] + 1)
        {
            count = count + Output(i-1,j , Arr , S1 , S2) ; 
        }
        else if(i> 0 && j> 0 &&  Arr[i,j] == Arr[i , j-1] + 1)
        {
            count = count + Output(i,j-1 , Arr , S1 , S2) ; 
        }
        // else if(i> 0 && j> 0 &&  Arr[i,j] == Arr[i-1 , j-1] + 1)
        // {
        //     count = count + Output(i-1,j-1 , Arr , S1 , S2) ; 
        // }
        
        return count  ; 
    }
    static void Main()
    {
        long Number = long.Parse(Console.ReadLine()) ; 
        string[] MyStr1arr = Console.ReadLine().Split() ; 
        long Number2 = long.Parse(Console.ReadLine()) ;  
        string[] Mystr2arr = Console.ReadLine().Split() ; 
        long[,] SaveArr = new long[Number+1, Number2+1] ;
        SaveArr[0 , 0] = 0  ;
        for(long i = 1 ; i <=  Number ; i++)
        {
            SaveArr[i, 0] = i ;
        }
        for(long j = 1 ; j <=  Number2 ; j++)
        {
            SaveArr[0, j] = j ;
        }
        for(int  j = 1 ; j <= Number2 ; j++)
        {
            for(int  i = 1  ; i<= Number ; i++)
            {
                long Insertion = SaveArr[i,j-1] + 1 ; 
                long deletion = SaveArr[i-1 , j] +1 ; 
                long mathch = SaveArr[i-1 , j-1] ; 
                // long MisMatch = SaveArr[i-1 ,j-1] + 1;
                if(MyStr1arr[i-1] == Mystr2arr[j-1])
                {
                    SaveArr[i,j]= Math.Min(mathch , Math.Min(Insertion,deletion)); 
                }
                else
                {
                    SaveArr[i,j]=  Math.Min(Insertion,deletion); 
                }
            }
        }
        long Ans = Output(Number , Number2 , SaveArr , MyStr1arr , Mystr2arr)  ; 
        Console.WriteLine(Ans) ; 
    }
}