using System;
class Program
{
    static long Fib(long Number)
    {
        long First = 0  ; 
        long Second = 1 ; 
        long Temp ; 
        long Sum = 1 ;
        Number = Number % 60 ;
        if(Number == 0) 
        {
            Sum = 0 ;

        }
        else if(Number ==1)
        {
            Sum = 1 ;
        }
         /* 60  =  (10) از دوره تناوب تمرین قبلی بدست اومد برای پیدا کردن باقی مونده های بر عدد */
        // جمع هر 60 عدد دوره هم 0 میشود پس میتوانیم بجای کار با عدد بزرگ از باقی موندش بر 60 استفاده کنیم
        
        for(long i = 2  ; i <= Number ;  i++)
        {
            Temp = (First+Second)% 10 ;
            First = Second ;
            Second = Temp ;  
            Sum = Sum + Second ; 
            if(Sum >= 10)
            {
                Sum =Sum %10 ;
            }
        }
        return Sum ; 
        
    }
   
    static void Main(string[] args)
    {
        
        string Input = Console.ReadLine();
        string[] Numbers = Input.Split(" ");
        long Number = long.Parse(Numbers[0]) ; 
        long Number2 = long.Parse(Numbers[1]) ; 
        long sum1 = Fib(Number-1) ; 
        long sum2 = Fib(Number2) ; 
        long ans  ;
        if(Number == 0)
        {
            ans = sum2 ; 
        }
        else
        {
           ans = sum2-sum1 ; 
           if(ans< 0)
           {
              ans = ans + 10 ; 
           }
        }
        Console.WriteLine(ans);
    }
}

