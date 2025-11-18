namespace LeetCode.Easy;

public class MissingNumberFinder
{
    public int MissingNumber(int[] nums)
    {
        int missingNumber = FindMissingNumberUsingNoExtraMemory(nums);
        //int missingNumber = FindMissingNumberUsingExtraMemory(nums);

        return missingNumber;
    }


    private int FindMissingNumberUsingNoExtraMemory(int[] nums)
    {
        int missingNumber = -1;
        int numsSum = 0;
        int rangeSum = 0;
        int n = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            numsSum+=nums[i];
        }

        for (int i = 0; i <= n; i++)
        {
            rangeSum+=i;
        }
        
        missingNumber = rangeSum - numsSum;
        
        return missingNumber;
    }
    
    
    private int FindMissingNumberUsingExtraMemory(int[] nums)
    {
        int missingNumber = -1;
        int n = nums.Length;
        int arraySize = n + 1;
        int[] expectedNumbers = new int[arraySize];

        for (int i = 0; i < expectedNumbers.Length; i++)
        {
            expectedNumbers[i] = -1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            expectedNumbers[nums[i]] = nums[i];
        }

        for (int i = 0; i < expectedNumbers.Length; i++)
        {
            if (expectedNumbers[i] == -1)
            {
                missingNumber = i;
                break;
            }
        }

        return missingNumber;
    }
}