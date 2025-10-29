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
            case AppEnum.LinkedListElementRemover:
                RunLinkedListRemover();
                break;
            case AppEnum.LinkedListDuplicatesRemover:
                RunLinkedListDuplicatesRemover();
                break;
            case AppEnum.ExcelSheetEngine:
                RunExcelSheetEngine();
                break;
            case AppEnum.LinkedListPalindromeDetector:
                RunLinkedListPalindromeDetector();
                break;
            case AppEnum.QueueWithStackBuilder:
                break;
        }
    }



    private static void RunLinkedListPalindromeDetector()
    {
        string input = "";
        LinkedList list = new LinkedList();

        while (input != "exit")
        {
            Console.Write(">> Please enter the numbers " +
                          " separated by comma or type exit to stop the program: ");
            var line = Console.ReadLine();

            if (line.ToLower().Trim() == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine(">> Checking if the linked list is a palindrome...");
                ListNode head = BuildIntegersList(line);
                bool isPalindrome = list.IsPalindrome(head);
                Console.WriteLine();

                if (isPalindrome)
                {
                    Console.WriteLine(">> The linked list is a palindrome\n");
                }
                else
                {
                    Console.WriteLine(">> The linked list is not a palindrome\n");   
                }
                
               
            }
        }
    }

    private static void RunExcelSheetEngine()
    {
        string? input = "";
        int columnNumber = -1;
        bool validInput = false;
        string columnTitle = "";
        ExcelSheetEngine sheetEngine = new ExcelSheetEngine();
        
        while (input != "exit")
        {
            columnNumber = -1; 
            Console.Write(">> Please enter the column number: ");
            input = Console.ReadLine();
            if (input != null && input.ToLower().Trim() == "exit")
            {
                break;
            }
            else
            {
                validInput = Int32.TryParse(input, out columnNumber);
                if (!validInput)
                {
                    Console.WriteLine(">>ERROR: Please enter a valid column number\n");
                }
                else if(columnNumber <= 0)
                {
                    Console.WriteLine(">>ERROR: Please enter a column number greater than 0\n");
                }
                else
                {
                   columnTitle = sheetEngine.ConvertToTitle(columnNumber);
                   Console.WriteLine(">> The column title Mapping to COLUMN NUMBER " + 
                                     columnNumber + " is: " + columnTitle + "\n");
                }
            }
        }
    }
    
    private static void RunLinkedListDuplicatesRemover()
    {
        string input = "";
        LinkedList list = new LinkedList();

        while (input != "exit")
        {
            Console.Write(">> Please enter the numbers (in ascending sorted order)" +
                          " separated by comma or type exit to stop the program: ");
            var line = Console.ReadLine();

            if (line.ToLower().Trim() == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine(">> Removing Duplicates...");
                ListNode head = BuildIntegersList(line);
                head = list.DeleteDuplicates(head);
                Console.Write(">> The linked list after removing duplicates is: ");
                list.Print(head);
                Console.WriteLine("\n");
            }
        }
    }
    
    private static void RunLinkedListRemover()
    {
        string input = "";
        LinkedList list = new LinkedList();
        
        while (input != "exit")
        {
            Console.Write(">> Please enter the numbers separated by comma or exit to stop the program: ");
            var line = Console.ReadLine();

            if (line.ToLower().Trim() == "exit")
            {
                break;
            }
            else
            {
                // Build linked list from nums
                int valueToRemove = -1;
                ListNode head = BuildIntegersList(line);
                
                Console.Write(">> Please enter the value you want to remove: ");
                Int32.TryParse(Console.ReadLine(), out valueToRemove);
                head = list.RemoveElements(head, valueToRemove);
                Console.WriteLine(">> The linked list after removing the value is: ");
                list.Print(head);
                Console.WriteLine("\n");
            }
        }
    }

    private static ListNode BuildIntegersList(string line)
    {
        ListNode head = null;
        ListNode current = null;
        
        string[] tokens = line.Split(new char[] { ',' });
        
        int[] nums = Array.ConvertAll(tokens, t => int.Parse(t.Trim()));
                
        foreach (int num in nums)
        {
            if (head == null)
            {
                head = new ListNode(num);
                current = head;
            }
            else
            {
                current.next = new ListNode(num);
                current = current.next;
            }
        }

        return head;
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