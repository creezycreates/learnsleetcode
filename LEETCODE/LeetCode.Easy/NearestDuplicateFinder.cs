namespace LeetCode.Easy;

public class NearestDuplicateFinder
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        bool duplicateExists = NearbyDuplicateExistsFast(nums, k);
        //bool duplicateExists = NearbyDuplicateExistsSlow(nums, k);
        
        return duplicateExists;
    }




    private bool NearbyDuplicateExistsFast(int[] nums, int k)
    {
        bool exists = false;
        Dictionary<int, CountPair> numbersMap = new Dictionary<int, CountPair>();


        for (int i = 0; i < nums.Length; i++)
        {
            int number = nums[i];
            if (numbersMap.Keys.Contains(number))
            {
                 numbersMap[number].Count++;
                 numbersMap[number].Distance = Math.Abs(i-numbersMap[number].Distance);
                 if (numbersMap[number].Distance <= k)
                 {
                     exists = true;
                     break;
                 }
                 else
                 {
                     numbersMap[number].Distance = i;
                 }
                
            }
            else
            {
                numbersMap.Add(number, new CountPair
                {
                    Count = 1, Distance = i
                });
            }
        }
        
        
        return exists;
    }
    
    private bool NearbyDuplicateExistsSlow(int[] nums, int k)
    {
        bool exists = false;

        for (int i = 0; i < nums.Length; i++)
        {
            int endIndex = i + k;
            if (endIndex > nums.Length)
            {
                endIndex = nums.Length - 1; 
            }

            for (int j = i + 1; j <= endIndex; j++)
            {
                if (j < nums.Length && endIndex <= nums.Length && 
                    nums[i] == nums[j])
                {
                    exists = true;
                    break;
                }
            }
            if (exists) break;
        }
        
        return exists;
    }
    
    private class CountPair
    {
        public int Count { get; set; }
        public int Distance { get; set; }
        
    }
}