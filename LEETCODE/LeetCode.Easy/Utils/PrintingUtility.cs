namespace LeetCode.Easy.Utils;

public static class PrintingUtility
{
    public static void PrintNestedList(IList<IList<int>> nestedList)
    {
        Console.Write("[");
        for (int i = 0; i < nestedList.Count; i++)
        {
            Console.Write("[");
            for (int j = 0; j < nestedList[i].Count; j++)
            {
                Console.Write(nestedList[i][j]);
                if (j < nestedList[i].Count - 1)
                    Console.Write(",");
            }
            Console.Write("]");
            if (i < nestedList.Count - 1)
                Console.Write(",");
        }
        Console.WriteLine("]");
    }

}