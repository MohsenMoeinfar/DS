using System ; 

public class Program
{
    static void Main()
    {
        long numberqu  = long.Parse(Console.ReadLine()) ; 
        string[] myco  = new string[10000000] ;   
        for(long k = 0  ; k < myco.Length ; k++)
        {
            myco[k] =  "not found" ;
        }
        for(long i =  0 ;  i < numberqu ;  i++)
        {
            string[] infoqu   =  Console.ReadLine().Split() ; 
            if(infoqu[0] == "add")
            {
                myco[long.Parse(infoqu[1])] =  infoqu[2]  ; 
                
            }
            if(infoqu[0] == "find")
            {
                string find  =  myco[long.Parse(infoqu[1])] ; 
                Console.WriteLine(find)  ; 

            }
            if(infoqu[0]== "del")
            {
                myco[long.Parse(infoqu[1])] =  "not found" ; 
            }
        }


    }
}