namespace LeetCode.Easy;

public class NextGreaterElementFinder
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] output = FindNextGreaterElementsFast(nums1, nums2);
        //int[] output = FindNextGreaterElementsSlowly(nums1, nums2);

        return output;
    }

    private int[] FindNextGreaterElementsFast(int[] nums1,
        int[] nums2)
    {
        int[] output = new int[nums1.Length];
        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (int num in nums1)
        {
            map[num] = -1;
        }

        for (int i = nums2.Length - 1; i >= 0; i--)
        {
            int num = nums2[i];
            while (stack.Count > 0 && stack.Peek() < num)
            {
                stack.Pop();
            }

            if (stack.Count == 0 && map.ContainsKey(nums2[i]))
            {
                map[nums2[i]] = -1;
            }
            else if (stack.Count > 0 && map.ContainsKey(nums2[i]))
            {
                map[nums2[i]] = stack.Peek();
            }
            stack.Push(num);
        }

        int outputIndex = 0;
        foreach (int key in map.Keys)
        {
            output[outputIndex] = map[key];
            outputIndex++;
        }
        
        return output;
    }

    private int[] FindNextGreaterElementsSlowly(int[] nums1,
        int[] nums2)
    {
        int[] output = new int[nums1.Length];
        int outputIndex = -1;

        for (int i = 0; i < nums1.Length; i++)
        {
            int numAti = nums1[i];
            outputIndex++;
            
            for(int j=0; j < nums2.Length; j++)
            {
                int numAtj = nums2[j];

                if (numAti == numAtj)
                {
                    var num2Index = j + 1;
                    var foundGreaterElement = false;
                    for (int k = num2Index; k < nums2.Length; k++)
                    {
                        if (k < nums2.Length && nums2[k] > numAti)
                        {
                            output[outputIndex] = nums2[k];
                            foundGreaterElement = true;
                            break;
                        }
                    }

                    if (!foundGreaterElement)
                    {
                        output[outputIndex] = -1;
                    }
                    
                    break;
                }
            }

        }

        return output;
    }
}