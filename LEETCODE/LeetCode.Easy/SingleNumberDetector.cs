namespace LeetCode.Easy;

public class SingleNumberDetector
{
    public int? SingleNumber(int[] nums)
    {
        int? uniqueNumber = null;
        
        // first we sort the array. Once we have the array sorted, we can just go through each
        // element and check if the following element is the same as the current element; If it is the 
        // same, we just set the uniqueNumber to be that one. If not, we keep going. So after the sorting,
        // find the unique number will be found in O(N) time. So we need to choose an efficient sorting algorithm.
        RadixSort(nums);

        if (nums.Length > 0)
        {
            for(int i=0; i < nums.Length; i++)
            {
                if (i != nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    uniqueNumber = nums[i];
                    break;
                }
            }
        }
        
        return uniqueNumber;
    }
    
    
    
    private int[] BubbleSort(int[] nums)
    {
        if (nums is not { Length: > 0 }) return nums;
        for (int i = 0; i < nums.Length; i++)
        {
            var numAti = nums[i];
                
            for(int j = i + 1; j < nums.Length; j++)
            {
                var numAtj = nums[j];
                    
                if (numAti > numAtj)
                {
                    var temp = numAti;
                    nums[i] = numAtj;
                    nums[j] = temp;
                }
            }
        }

        return nums;
    }
    
    private void RadixSort(int[] nums)
    {
        if (nums.Length == 0) return;

        int max = nums[0];
        foreach (int num in nums)
            if (num > max) max = num;

        // Perform counting sort for each digit (1s, 10s, 100s, etc.)
        for (int exp = 1; max / exp > 0; exp *= 10)
            CountingSort(nums, exp);
    }

    private void CountingSort(int[] nums, int exp)
    {
        int n = nums.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        // Count occurrences of digits
        for (int i = 0; i < n; i++)
            count[(nums[i] / exp) % 10]++;

        // Change count[i] so that count[i] contains actual position
        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        // Build output array (stable sort)
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (nums[i] / exp) % 10;
            output[count[digit] - 1] = nums[i];
            count[digit]--;
        }

        // Copy to original array
        for (int i = 0; i < n; i++)
            nums[i] = output[i];
    }

}