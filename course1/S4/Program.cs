using System ; 
using System.Collections.Generic ; 
using System.Linq ; 
class Program
{
    static void Main()
    {
        Stack<long> mystack  = new Stack<long> {} ; 
        Stack<long> saver   = new Stack<long>{}  ; 
        long max =  0 ; 
        long querynumber = long.Parse(Console.ReadLine()) ; 
        for(int i  = 0  ;  i < querynumber  ; i++)
        {
            string[] query   =  Console.ReadLine().Split()  ;
            if(query.Length ==2)
            {
                mystack.Push(long.Parse(query[1])) ;
                if(max<= mystack.Peek())
                {
                    max = mystack.Peek() ; 
                    saver.Push(max) ; 
                }
            }
            else
            {
                if(query[0] == "pop")
                {
                    var ss = mystack.Pop() ; 
                    if(ss >= max)
                    {
                        saver.Pop() ; 
                        max = saver.Peek() ; 
                    }

                }
                else if(query[0]== "max")
                {
                    long max2 =  saver.Peek();
                    Console.WriteLine(max2) ; 
                }
            }

        }

    }
}