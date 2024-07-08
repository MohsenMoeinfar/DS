using System;
using System.Collections.Generic  ; 
public class Node
{
    public long Key;
    public long Sum;
    public Node Left;
    public Node Right;
    public Node Parent;
    public Node(long key, long sum, Node left, Node right, Node parent)
    {
        this.Key = key;
        this.Sum = sum;
        this.Left = left;
        this.Right = right;
        this.Parent = parent;
    }
}
public class MySplay
{
    public Node root;
    public void Add(long val)
    {
        var leftright = Split(root, val);
        var left = leftright.Item1;
        var right = leftright.Item2;
        Node newnode = null;
        if (right == null || right.Key != val)
        {
            newnode = new Node(val, val, null, null, null);
        }
        root = Merge(Merge(left, newnode), right);
    }
    public void Del(long val)
    {
        var nx = Find(root, val);
        var next = nx.Item1;
        root = nx.Item2;
        if (next == null || next.Key != val)
        {
            return;
        }
        Splay(next);
        root = Merge(root.Left, root.Right);
        if (root != null)
        {
            root.Parent = null;
        }
    }
    public bool Search(long val)
    {
        var nx = Find(root, val);
        var next = nx.Item1;
        root = nx.Item2;
        if (next != null && next.Key == val)
        {
            return true;
        }
        return false;
    }
    public Tuple<Node, Node> Find(Node root, long key)
    {
        var v = root;
        Node last = root;
        Node next = null;
        while (v != null)
        {
            if (v.Key >= key && (next == null || v.Key < next.Key))
            {
                next = v;
            }
            last = v;
            if (v.Key == key)
            {
                break;
            }
            if (v.Key < key)
            {
                v = v.Right;
            }
            else
            {
                v = v.Left;
            }
        }
        root = Splay(last);
        return new Tuple<Node, Node>(next, root);
    }
    public Node Splay(Node v)
    {
        if (v == null)
        {
            return null;
        }
        while (v.Parent != null)
        {
            if (v.Parent.Parent == null)
            {
                zigorzag(v);
            }
            else
            {
                zigzig_or_zigzag(v);
            }
        }
        return v;
    }
    public long Sum(long start, long finish)
    {
        var nx1 = Split(root, start);
        var left = nx1.Item1;
        var mid = nx1.Item2;
        var nx2 = Split(mid, finish + 1);
        mid = nx2.Item1;
        var right = nx2.Item2;
        long ans = 0;
        if (mid != null)
        {
            ans += mid.Sum;
        }
        root = Merge(Merge(left, mid), right);
        return ans;
    }
    public void Update(Node v)
    {
        if (v == null)
            return;
        v.Sum = v.Key + (v.Left?.Sum ?? 0) + (v.Right?.Sum ?? 0);
        if (v.Left != null)
        {
            v.Left.Parent = v;
        }
        if (v.Right != null)
        {
            v.Right.Parent = v;
        }
    }
    public void zigorzag(Node v)
    {
        var parent = v.Parent;
        var grandparent = v.Parent.Parent;
        if (parent == null)
        {
            return;
        }
        if (parent.Left == v)
        {
            var m = v.Right;
            v.Right = parent;
            parent.Left = m;
        }
        else
        {
            var m = v.Left;
            v.Left = parent;
            parent.Right = m;
        }
        Update(parent);
        Update(v);
        v.Parent = grandparent;
        if (grandparent != null)
        {
            if (grandparent.Left == parent)
            {
                grandparent.Left = v;
            }
            else
            {
                grandparent.Right = v;
            }
        }
    }
    public void zigzig_or_zigzag(Node v)
    {
        if (v.Parent.Left == v && v.Parent.Parent.Left == v.Parent)
        {
            zigorzag(v.Parent);
            zigorzag(v);
        }
        else if (v.Parent.Right == v && v.Parent.Parent.Right == v.Parent)
        {
            zigorzag(v.Parent);
            zigorzag(v);
        }
        else
        {
            zigorzag(v);
            zigorzag(v);
        }
    }
    public Tuple<Node, Node> Split(Node root, long key)
    {
        var goalroot = Find(root, key);
        var nx = goalroot.Item1;
        root = goalroot.Item2;
        if (nx == null)
        {
            return new Tuple<Node, Node>(root, null);
        }
        var right = Splay(nx);
        var left = right.Left;
        right.Left = null;
        if (left != null)
        {
            left.Parent = null;
        }
        Update(left);
        Update(right);
        return new Tuple<Node, Node>(left, right);
    }
    public Node Merge(Node left, Node right)
    {
        if (left == null)
        {
            return right;
        }
        if (right == null)
        {
            return left;
        }
        while (right.Left != null)
        {
            right = right.Left;
        }
        right = Splay(right);
        right.Left = left;
        Update(right);
        return right;
    }
}
public class Program
{
    static void Main()
    {
        const long mod = 1000000001;
        var mytree = new MySplay();
        var opnum = long.Parse(Console.ReadLine());
        long savesum = 0;
        for (long i = 0; i < opnum; i++)
        {
            var inp = Console.ReadLine().Split();
            if (inp[0] == "+")
            {
                var x = long.Parse(inp[1]);
                mytree.Add((x + savesum) % mod);
            }
            else if (inp[0] == "-")
            {
                var x = long.Parse(inp[1]);
                mytree.Del((x + savesum) % mod);
            }
            else if (inp[0] == "?")
            {
                var x = long.Parse(inp[1]);
                if(mytree.Search((x + savesum) % mod))
                {
                     Console.WriteLine("Found") ;
                }
                else
                {
                     Console.WriteLine("Not found") ;
                }
            }
            else if (inp[0] == "s")
            {
                var left = long.Parse(inp[1]);
                var right = long.Parse(inp[2]);
                var res = mytree.Sum((left + savesum) % mod, (right + savesum) % mod);
                Console.WriteLine(res);
                savesum = res % mod;
            }
        }
    }
}
 // Add(12) ; 
            // Add(1) ; 
            // Del(1) ;
            // bool hast = Search(12) ;  
            // if(hast == true)
            // {
            //     Console.WriteLine("yaftshod")  ; 
            // }
            // else
            // {
            //     Console.WriteLine("gashtam nabod nagard nist ") ; 
            // }