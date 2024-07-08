using System  ; 

public class Program
{
    static void Main()
    {
        string MyStr1 = Console.ReadLine() ; 
        string Mystr2 = Console.ReadLine() ; 
        long[,] SaveArr = new long[MyStr1.Length+1, Mystr2.Length+1] ;
        SaveArr[0 , 0] = 0  ;
        for(long i = 1 ; i <=  MyStr1.Length ; i++)
        {
            SaveArr[i, 0] = i ;
        }
        for(long j = 1 ; j <=  Mystr2.Length ; j++)
        {
            SaveArr[0, j] = j ;
        }
        for(int  j = 1 ; j <= Mystr2.Length ; j++)
        {
            for(int  i = 1  ; i<= MyStr1.Length ; i++)
            {
                long Insertion = SaveArr[i,j-1] + 1 ; 
                long deletion = SaveArr[i-1 , j] +1 ; 
                long mathch = SaveArr[i-1 , j-1] ; 
                long MisMatch = SaveArr[i-1 ,j-1] + 1;
                if(MyStr1[i-1] == Mystr2[j-1])
                {
                    SaveArr[i,j]= Math.Min(mathch , Math.Min(Insertion,deletion)); 
                }
                else
                {
                    SaveArr[i,j]= Math.Min(MisMatch , Math.Min(Insertion,deletion)); 
                }
            }
        }
        Console.WriteLine(SaveArr[MyStr1.Length , Mystr2.Length]) ; 
    }
}