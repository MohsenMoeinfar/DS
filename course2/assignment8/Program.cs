using System;
class Program
{
   
    static void Main(string[] args)
    {
        long First = 0  ; 
        long Second = 1 ; 
        long Temp ; 
        string Input = Console.ReadLine();
        long Number = long.Parse(Input) ; 
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
        Console.WriteLine(Sum);
    }
}
