namespace LeetCode.Easy;

public class StringReverser
{
    public void ReverseString(char[] s)
    {
        ReverseStringUsingTwoPointer(s);
        //ReverseStringUsingExtraSpace(s);

    }

    private void ReverseStringUsingTwoPointer(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            left++;
            right--;
        }
    }
    
    private void ReverseStringUsingExtraSpace(char[] s)
    {
        int j = 0;
        char[] output = new char[s.Length];

        for (int i = s.Length - 1; i >= 0; i--)
        {
            output[j] = s[i];
            j++;
        }
        
        for(int k = 0; k < output.Length; k++)
        {
            s[k] = output[k];
        }
    }
}