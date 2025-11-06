namespace LeetCode.Easy;

public class ThreeSumSolver
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> triplets = FetchTriplets(nums, 0);
        return triplets;
    }

    public static void Print(IList<IList<int>> triplets)
    {
        foreach (IList<int> triplet in triplets)
        {
            Console.WriteLine(">> " + string.Join(",", triplet));
        }
    }

    private IList<IList<int>> FetchTriplets(int[] nums, int target)
    {
        IList<IList<int>> triplets = new List<IList<int>>();
        HashSet<string> seenTriplets = new HashSet<string>();
      

        for (int i = 0; i < nums.Length; i++)
        {
            int number = nums[i];
            int complement = target - number;
            int[] numbersToScan = ComputeScannableNumbers(nums, i);
            IList<IList<int>> couples = TwoSum(numbersToScan, complement);
            
           
            if (couples.Count > 0)
            {
                foreach (IList<int> couple in couples)
                {
                    List<int> triplet = new List<int> { number, couple[0], couple[1] };
                    triplet.Sort();
                    string tripletsKey = string.Join(",", triplet);

                    if (!seenTriplets.Contains(tripletsKey))
                    {
                        triplets.Add(triplet);
                        seenTriplets.Add(tripletsKey);
                    }
                    
                }
            }
        }
        
        
        return triplets;
    }

    private IList<IList<int>> TwoSum(int[] nums, int target)
    {
        IList<IList<int>> couples = FindCouplesFast(nums, target);
        //IList<IList<int>> couples = FindCouplesSlowly(nums, target);
        return couples;
    }

    private IList<IList<int>> FindCouplesSlowly(int[] nums, int target)
    {
        IList<IList<int>> couples = new List<IList<int>>();
        

        for (int i = 0; i < nums.Length; i++)
        {
            int numAti = nums[i];

            for (int j = i + 1; j < nums.Length; j++)
            {
                int numAtj = nums[j];
                if (
                        (numAti + numAtj == target) 
                       
                    )
                {
                    couples.Add(new List<int> { numAti, numAtj });
                }
            }
        }

        return couples;
    }

    private IList<IList<int>> FindCouplesFast(int[] nums, int target)
    {
        IList<IList<int>> couples = new List<IList<int>>();
        HashSet<int> seenNumbers = new HashSet<int>();
        

        for (int i = 0; i < nums.Length; i++)
        {
            int numAti = nums[i];
            int complement = target - numAti;

            if (seenNumbers.Contains(complement))
            {
                couples.Add(new List<int> { complement, numAti });
            }
            else
            {
                seenNumbers.Add(numAti);
            }
            

        }

        return couples;
    }

    private int[] ComputeScannableNumbers(int[] nums, int i)
    {
        int[] scannableNumbers;
        List<int> numsList = new List<int>();

        for (int j = 0; j < nums.Length; j++)
        {
            if (i != j)
            {
                numsList.Add(nums[j]);
            }
        }
        
        scannableNumbers = numsList.ToArray();

        return scannableNumbers;
    }
}