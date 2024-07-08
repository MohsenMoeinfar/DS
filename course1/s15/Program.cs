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
        if(numnod > 0 )
        {
            bool ans = bst( 0 , long.MinValue , long.MaxValue);
        if (ans)
        {
            Console.WriteLine("CORRECT");
        }
        else
        {
            Console.WriteLine("INCORRECT");
        }

        }
        else if(numnod == 0)
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
    static bool bst(long index, long min, long max)
    {
        if (index == -1)
        {
            return true;
        }
        if (nodes[index].Key < min || nodes[index].Key >= max)
        {
            return false;
        }
        return bst(nodes[index].Left, min, nodes[index].Key) && bst(nodes[index].Right, nodes[index].Key, max);
    }
}
