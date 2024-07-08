using System;
using System.Collections.Generic;

class Program
{
     static void Main()
     {
          long[] inp = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
          long BufferSize = inp[0];
          long PACKNUM = inp[1];
          List<int> Times = new List<int>();
          List<int> ans  = new List<int>(); 
          for (int i = 0; i < PACKNUM; i++)
          {
               string[] packet = Console.ReadLine().Split();
               int timearr = int.Parse(packet[0]);
               int protime = int.Parse(packet[1]);
               while (Times.Count > 0 && Times[0] <= timearr)
               {
                    Times.RemoveAt(0);
               }

               if (Times.Count >= BufferSize)
               {
                    ans.Add(-1) ;
               }
               else
               {
                    int start =  0 ;

                    if (Times.Count > 0)
                    {
                         start = Math.Max(timearr, Times[Times.Count - 1]);
                    }
                    else
                    {
                         start = timearr;
                    }
                    int curr = start + protime;
                    Times.Add(curr);
                    ans.Add(start) ; 
               }
          }
          foreach(var i  in  ans)
          {
                Console.WriteLine(i) ; 
          }
     }
}
