using System;
using System.Collections;
using  System.Collections.Generic ; 

public class Program
{
    static void Main()
    {
        string Mystr = Console.ReadLine();
        List<char> random = new List<char> {};
        long Count = 0;
        bool mohsen = false;
        long maxbaz = 0 ;
        long tmp2 = 0 ; 
        foreach (var i in Mystr)
        {
            // if(i == '[' ||  i== ']' || i== '(' || i== ')' || i== '{' || i== '}')
            // {
            random.Add(i);

            // }
        }
        Stack<char> ll = new Stack<char> {};
        foreach (var i in random)
        {
            if (i == '(' || i == '[' || i == '{')
            {
                ll.Push(i);
                Count++;
                tmp2 = 1 ;
            }
            else if ((i == ')' || i == ']' || i == '}') && ll.Count != 0 )
            {
                maxbaz = ll.Count ; 
                if(maxbaz >= tmp2)
                {
                    tmp2 = maxbaz ; 
                }
                char tmp = ll.Pop();
                if (tmp == '(' && i != ')')
                {
                    mohsen = false;
                    Count = Count+1 ; 
                    break;


                }
                else if (tmp == '[' && i != ']')
                {
                    mohsen = false;
                    Count = Count+1 ; 
                    break;

                }
                else if (tmp == '{' && i != '}')
                {
                    mohsen = false;
                    Count = Count+1 ; 
                    break;
                }
                else
                {
                    mohsen = true;
                    Count++;

                }
                
            }
            else if ((i == ')' || i == ']' || i == '}') && ll.Count == 0 )
            {
                mohsen = false ;
                Count = Count + 1 ; 
                break;
            }
            else
            {
                Count++;

            }
          
        }
        if(ll.Count != 0  &&  mohsen == true)
        {
            mohsen = false ; 
            Count = Count - (tmp2-ll.Count)*2 ; 
                
        }
        if (mohsen == true)
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine(Count);
        }
    }
}