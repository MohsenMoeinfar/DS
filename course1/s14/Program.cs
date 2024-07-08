using System;
using System.Collections.Generic;
public class Node
{
    public long Key;
    public long Left;
    public long Right;
    public Node(long ky , long lft ,  long rght)
    {
        this.Key = ky ; 
        this.Left = lft ; 
        this.Right = rght ; 
    }
}
public class Program
{
    static Node[] nodes;
    static void Main()
    {
        long numnod = long.Parse(Console.ReadLine());
        nodes = new Node[numnod];
        for (long i = 0; i < numnod; i++)
        {
            string[] input = Console.ReadLine().Split();
            long ky = long.Parse(input[0]);
            long lft = long.Parse(input[1]);
            long rght = long.Parse(input[2]);
            nodes[i] = new Node (ky , lft , rght) ; 
        }
        bool ans = bst();
        if (ans)
        {
            Console.WriteLine("CORRECT");
        }
        else
        {
            Console.WriteLine("INCORRECT");
        }
    }
    static void inorder(long index, List<long> keys)
    {
        if (index == -1)
        {
            return;
        }
        Node node = nodes[index];
        inorder(node.Left, keys);
        keys.Add(node.Key);
        inorder(node.Right, keys);
    }
    static bool bst()
    {
        if (nodes.Length == 0)
        {
            return true;
        }
        List<long> keys = new List<long>();
        inorder(0, keys);
        for (int i = 1; i < keys.Count; i++)
        {
            if (keys[i] < keys[i - 1])
            {
                return false;
            }
        }
        return true;
    }
}
