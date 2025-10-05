using LeetCode.Easy.Enums;
using LeetCode.Easy.Utils;

namespace LeetCode.Easy;

public static class Apps
{
    public static void Run(AppEnum appName)
    {
        switch (appName)
        {
            case AppEnum.Squarerootcalculator:
                RunSquareRootCalculator();
                break;
            case AppEnum.Pascaltrianglegenerator:
                RunPascalTriangleGenerator();
                break;
            case AppEnum.SingleNumberDetector:
                RunSingleNumberDector();
                break;
        }
    }



    private static void RunSingleNumberDector()
    {
        Console.Write(">> Please enter the numbers separated by comma: ");
        var line = Console.ReadLine();
        string[] tokens = line.Split(new char[] { ',' });
        int[] nums = new int[tokens.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(tokens[i]);
        }
        
        SingleNumberDetector detector = new SingleNumberDetector();
        int? uniqueNumber = detector.SingleNumber(nums);

        if (uniqueNumber == null)
        {
            Console.WriteLine("No unique number found");
        }
        else
        {
            Console.WriteLine("The unique number is: " + uniqueNumber);
        }
    }
    
    private static void RunPascalTriangleGenerator()
    {
        int rowsCount = 0;
        bool numberEntered = false;
        string input = string.Empty;
        Console.Write(">> Please enter the number of rows you want to generate:");
        input = Console.ReadLine()!;
        numberEntered = Int32.TryParse(input, out rowsCount);

        if (numberEntered)
        {
            IList<IList<int>> triangle = PascalTriangleGenerator.Generate(rowsCount);
            PrintingUtility.PrintNestedList(triangle);
        }
        else
        {
            Console.WriteLine(">>ERROR: Please enter a number");
        }
    }
    
    private static void RunSquareRootCalculator()
    {
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
    }
}