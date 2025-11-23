namespace LeetCode.Easy;

public class IntersectionFinder
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        int[] intersection = ComputeIntersectionFast(
            nums1, nums2);
        
        /*int[] intersection = ComputeIntersectionSlowly(
            nums1, nums2);*/
        
        return intersection;
    }

    private int[] ComputeIntersectionFast(int[] nums1,
        int[] nums2)
    {
        List<int> numsList = new List<int>();
        
        Dictionary<int, NumberStats> numbersMap = 
            new Dictionary<int, NumberStats>();
        
        FillNumbersMap(nums1, numbersMap, true);
        FillNumbersMap(nums2, numbersMap, false);

        foreach (int key in numbersMap.Keys)
        {
            if (numbersMap[key].SeenInNums1 && 
                numbersMap[key].SeenInNums2)
            {
                numsList.Add(key);
            }
        }
        
        int[] intersection = numsList.ToArray();
        
        return intersection;
    }


    private void FillNumbersMap(
        int[] nums, Dictionary<int, NumberStats> numbersMap,
        bool isNums1Array)
    {
        foreach (int number in nums)
        {
            if (!numbersMap.ContainsKey(number) && isNums1Array)
            {
                numbersMap.Add(number, new NumberStats()
                {
                    Count = 1,
                    SeenInNums1 = true,
                    SeenInNums2 = false
                });
            }
            else if (!numbersMap.ContainsKey(number) && !isNums1Array)
            {
                numbersMap.Add(number, new NumberStats()
                {
                    Count = 1,
                    SeenInNums1 = false,
                    SeenInNums2 = true
                });
            }
            else if(numbersMap.ContainsKey(number) && isNums1Array)
            {
                numbersMap[number].Count++;
                numbersMap[number].SeenInNums1 = true;
            }
            else if(numbersMap.ContainsKey(number) && !isNums1Array)
            {
                numbersMap[number].Count++;
                numbersMap[number].SeenInNums2 = true;
            }
        }
        
    }

    private int[] ComputeIntersectionSlowly(int[] nums1, 
        int[] nums2)
    {
        
        int[] intersection = nums2.Length <= nums1.Length ? 
            FindUniqueCommonElements(nums2, nums1) : 
            FindUniqueCommonElements(nums1, nums2);
        
        return intersection;
    }

    private int[] FindUniqueCommonElements(int[] smallerNums, 
        int[] biggerNums)
    {
        List<int> outputList = new List<int>();

        for (int i = 0; i < smallerNums.Length; i++)
        {
            int numberAti = smallerNums[i];
            bool numberExists = outputList.Contains(numberAti);

            if (!numberExists)
            {
                for (int j = 0; j < biggerNums.Length; j++)
                {
                    int numberAtj = biggerNums[j];

                    if (numberAti == numberAtj)
                    {
                        outputList.Add(numberAti);
                        break;
                    }
                } 
            }
        }
        
        var intersection = outputList.ToArray();
        return intersection;
    }
    
    private class NumberStats
    {
        public int Count { get; set; }
        public bool SeenInNums1 { get; set; }
        public bool SeenInNums2 { get; set; }
    }
}