// See https://aka.ms/new-console-template for more information
using LeetCode.Easy;

int x = 0;
bool numberEntered = false;
string input = "";
while(input != "exit")
{
    
    Console.Write(">> Please enter a number:");
    input = Console.ReadLine()!;
    numberEntered = Int32.TryParse(input, out x);
    if(numberEntered)
    {
        int y = Calculator.Sqrt(x);
        Console.WriteLine("SLOWSQRT(" + x + ") = " + y);
    }
    else if(input!.ToLower().Trim() != "exit")
    {
        Console.WriteLine(">>ERROR: Please enter a number or exit");
    }
  
}
