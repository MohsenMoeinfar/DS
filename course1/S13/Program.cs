using System;
using System.Collections.Generic;
public class Program
{
    static List<Tuple<long, int[]>> listnodes;
    static void inorder(int start)
    {
        Stack<int> stack = new Stack<int>();
        while (start != -1 || stack.Count > 0)
        {
            while (start != -1)
            {
                stack.Push(start);
                start = listnodes[start].Item2[0];
            }
            start = stack.Pop();
            Console.Write(listnodes[start].Item1 + " ");
            start = listnodes[start].Item2[1];
        }
    }
    static void postorder(int started)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(started);
        Stack<long> ans = new Stack<long>();
        while (stack.Count > 0)
        {
            int start = stack.Pop();
            ans.Push(listnodes[start].Item1);
            if (listnodes[start].Item2[0] != -1)
            {
                stack.Push(listnodes[start].Item2[0]);
            }
            if (listnodes[start].Item2[1] != -1)
            {
                stack.Push(listnodes[start].Item2[1]);
            }
        }
        while (ans.Count > 0)
        {
            Console.Write(ans.Pop() + " ");
        }
    }
    static void preorder(int started)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(started);
        while (stack.Count > 0)
        {
            int start = stack.Pop();
            Console.Write(listnodes[start].Item1 + " ");
            if (listnodes[start].Item2[1] != -1)
            {
                stack.Push(listnodes[start].Item2[1]);
            }
            if (listnodes[start].Item2[0] != -1)
            {
                stack.Push(listnodes[start].Item2[0]);
            }
        }
    }
    static void Main()
    {
        listnodes = new List<Tuple<long, int[]>> { };
        long numberofnodes = long.Parse(Console.ReadLine());
        for (int i = 0; i < numberofnodes; i++)
        {
            string[] inp = Console.ReadLine().Split();
            long key = long.Parse(inp[0]);
            int lft = int.Parse(inp[1]);
            int rght = int.Parse(inp[2]);
            listnodes.Add(new Tuple<long, int[]>(key, new int[2] { lft, rght }));
        }
        inorder(0);
        Console.WriteLine();
        preorder(0);
        Console.WriteLine();
        postorder(0);
    }
}
