using System ; 

public class Program
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long[] prizes = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long sum = 0;
        foreach (var prize in prizes)
        {
            sum += prize;
        }
        if (sum % 3 != 0)
        {
            Console.WriteLine(0);
            return;
        }

        long goal = sum / 3;
        long[,,] dp = new long[n + 1, goal + 1, goal + 1];

        for (long i = 1; i <= n; i++)
        {
            for (long j = 0; j <= goal; j++)
            {
                for (long k = 0; k <= goal; k++)
                {
                    if (prizes[i - 1] > j || prizes[i - 1] > k)
                    {
                        dp[i, j, k] = dp[i - 1, j, k];
                    }
                    else
                    {
                        dp[i, j, k] = Math.Max(dp[i - 1, j - prizes[i - 1], k] + prizes[i - 1], Math.Max(dp[i - 1, j, k - prizes[i - 1]] + prizes[i - 1], dp[i - 1, j, k]));
                    }
                }
            }
        }

        if (dp[n, goal, goal] == goal)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}