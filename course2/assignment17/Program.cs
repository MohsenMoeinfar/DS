using System;

class Program {
public static void Swap(string[] Arr, int i, int j) 
{
    string temp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = temp;
}
public static int Compare(string X, string Y) 
{
    return string.Compare(X + Y, Y + X);
}
public static void Sort(string[] Arr) 
{
    int n = Arr.Length;
    for (int i = 0; i < n - 1; i++) 
    {
      for (int j = 0; j < n - 1; j++) 
      {
        if (Compare(Arr[j], Arr[j + 1]) < 0) 
        {
          Swap(Arr, j, j + 1);
        }
      }
    }
}
public static void Main (string[] args) 
{
    int n = int.Parse(Console.ReadLine()); 
    string[] Numbers = Console.ReadLine().Split(); 
    Sort(Numbers);
    string Res = string.Join("", Numbers); 
    Console.WriteLine(Res); 
}

 

  


}