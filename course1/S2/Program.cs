using System ;  
public class Program
{
     static void Main()
     {
        long NumberOfNodes  = long.Parse(Console.ReadLine()) ; 
        long[] parents  = Array.ConvertAll(Console.ReadLine().Split() , long.Parse)  ; 
        long[] heights = new long[NumberOfNodes];
        long max = 0;
        for (long i = 0; i < NumberOfNodes; i++)
        {
            long height = 0;
            long j = i;
            while (j != -1)
            {
                if (heights[j] != 0)
                {
                    height += heights[j];
                    break;
                }
                height++;
                j = parents[j];
            }
            heights[i] = height;
            max = Math.Max(max, height);
        }
        Console.WriteLine(max) ; 
     }
}