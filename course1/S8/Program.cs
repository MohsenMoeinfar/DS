using System;
using System.Collections.Generic;
public class Job
{
    public long Worker { get; }
    public long Start { get; }

    public Job(int worker, long startedAt)
    {
        Worker = worker;
        this.Start = startedAt;
    }
}
class Program
{
    static void SiftDown(int i, int n, List<int[]> finishTime)
    {
        int minIndex = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n)
        {
            if (finishTime[minIndex][1] > finishTime[left][1])
            {
                minIndex = left;
            }
            else if (finishTime[minIndex][1] == finishTime[left][1])
            {
                if (finishTime[minIndex][0] > finishTime[left][0])
                {
                    minIndex = left;
                }
            }
        }

        if (right < n)
        {
            if (finishTime[minIndex][1] > finishTime[right][1])
            {
                minIndex = right;
            }
            else if (finishTime[minIndex][1] == finishTime[right][1])
            {
                if (finishTime[minIndex][0] > finishTime[right][0])
                {
                    minIndex = right;
                }
            }
        }

        if (minIndex != i)
        {
            int[] temp = finishTime[i];
            finishTime[i] = finishTime[minIndex];
            finishTime[minIndex] = temp;
            SiftDown(minIndex, n, finishTime);
        }
    }

    static void NextWorker(int job, int n, List<int[]> finishTime, List<Job> Jobs)
    {
        int[] root = finishTime[0];
        int nextWorker = root[0];
        long startedAt = root[1];
        Jobs.Add(new Job(nextWorker, startedAt));
        finishTime[0][1] += job;
        SiftDown(0, n, finishTime);
    }

    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        int nWorkers = int.Parse(input1[0]);
        int nJobs = int.Parse(input1[1]);

        List<int> jobs = new List<int>();
        string[] input2 = Console.ReadLine().Split();
        for (int i = 0; i < nJobs; i++)
        {
            jobs.Add(int.Parse(input2[i]));
        }

        int n = nWorkers;
        List<int[]> finishTime = new List<int[]>();
        List<Job> Jobs = new List<Job>();

        for (int i = 0; i < n; i++)
        {
            finishTime.Add(new int[] { i, 0 });
        }

        for (int i = 0; i < nJobs; i++)
        {
            int[] root = finishTime[0];
            int nextWorker = root[0];
            long startedAt = root[1];
            Jobs.Add(new Job(nextWorker, startedAt));
            finishTime[0][1] += jobs[i];
            SiftDown(0, n, finishTime);

            int minIndex = 0;
            int left = 2 * 0 + 1;
            int right = 2 * 0 + 2;

            if (left < n)
            {
                if (finishTime[minIndex][1] > finishTime[left][1])
                {
                    minIndex = left;
                }
                else if (finishTime[minIndex][1] == finishTime[left][1])
                {
                    if (finishTime[minIndex][0] > finishTime[left][0])
                    {
                        minIndex = left;
                    }
                }
            }

            if (right < n)
            {
                if (finishTime[minIndex][1] > finishTime[right][1])
                {
                    minIndex = right;
                }
                else if (finishTime[minIndex][1] == finishTime[right][1])
                {
                    if (finishTime[minIndex][0] > finishTime[right][0])
                    {
                        minIndex = right;
                    }
                }
            }

            if (minIndex != 0)
            {
                int[] temp = finishTime[0];
                finishTime[0] = finishTime[minIndex];
                finishTime[minIndex] = temp;

                minIndex = 0;
                left = 2 * minIndex + 1;
                right = 2 * minIndex + 2;

                if (left < n)
                {
                    if (finishTime[minIndex][1] > finishTime[left][1])
                    {
                        minIndex = left;
                    }
                    else if (finishTime[minIndex][1] == finishTime[left][1])
                    {
                        if (finishTime[minIndex][0] > finishTime[left][0])
                        {
                            minIndex = left;
                        }
                    }
                }

                if (right < n)
                {
                    if (finishTime[minIndex][1] > finishTime[right][1])
                    {
                        minIndex = right;
                    }
                    else if (finishTime[minIndex][1] == finishTime[right][1])
                    {
                        if (finishTime[minIndex][0] > finishTime[right][0])
                        {
                            minIndex = right;
                        }
                    }
                }

                if (minIndex != 0)
                {
                    temp = finishTime[0];
                    finishTime[0] = finishTime[minIndex];
                    finishTime[minIndex] = temp;
                }
            }
        }

        foreach (Job job in Jobs)
        {
            Console.WriteLine($"{job.Worker} {job.Start}");
        }
    }
}
