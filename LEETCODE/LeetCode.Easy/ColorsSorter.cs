namespace LeetCode.Easy;

public class ColorsSorter
{
    
    public void SortColors(int[] nums)
    {
        //SortColorsByCounting(nums);
        SortColorsWithThreePointers(nums);
    }

    public void Print(int[] nums)
    {
        Console.WriteLine(">> " + string.Join(",", nums));
    }



    private void SortColorsWithThreePointers(int[] nums)
    {
        int low = 0;
        int mid = 0;
        int temp = -1;
        int high = nums.Length - 1;
        
        while (mid <= high)
        {
            if (nums[mid] == 2)
            {
                temp = nums[high];
                nums[high] = nums[mid];
                nums[mid] = temp;
                high--;
            }
            else if (nums[mid] == 1)
            {
                mid++;
            }
            else if(nums[mid] == 0)
            {
                temp = nums[low];
                nums[low] = nums[mid];
                nums[mid] = temp;
                low++;
                mid++;
            }
        }
    }
    
    private void SortColorsByCounting(int[] nums)
    {
        int zerosCount = CountInteger(nums, 0);
        int onesCount = CountInteger(nums, 1);
        int twosCount = CountInteger(nums, 2);

        int firstLimit = zerosCount;
        int secondLimit = firstLimit + onesCount;
        int thirdLimit = secondLimit + twosCount;
        
        for(int i=0; i < firstLimit; i++)
        {
            nums[i] = 0;
        }

        for (int i = firstLimit; i < secondLimit; i++)
        {
            nums[i] = 1;
        }
        
        for(int i=secondLimit; i < thirdLimit; i++)
        {
            nums[i] = 2;
        }
    }

    private int CountInteger(int[] nums, int number)
    {
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == number)
            {
                count++;
            }
        }

        return count;
    }
}