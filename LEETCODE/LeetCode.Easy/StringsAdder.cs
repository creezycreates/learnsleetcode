namespace LeetCode.Easy;

public class StringsAdder
{
    public string AddStrings(string num1, string num2)
    {
        string result = "";
        
        int carry = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;
        int totalCharactersCount = 0;
        int visitedCharactersCount = 0;
        
        
        if (num1.Length >= num2.Length)
        {
            totalCharactersCount = num1.Length;
        }
        else
        {
            totalCharactersCount = num2.Length;
        }


        while (visitedCharactersCount != totalCharactersCount)
        {
            var num1Digit = -1;
            var num2Digit = -1;
            var addedValue = - -1;


            if (i >= 0)
            {
                num1Digit = GetDigit(num1[i]);
                i--;
            }
            
            if( j >= 0)
            {
                num2Digit = GetDigit(num2[j]);
                j--;
            }

            if (num1Digit != -1 && num2Digit != -1)
            {
                addedValue = num1Digit + num2Digit + carry;
                carry = GetCarry(addedValue);
                result = GetResult(addedValue, result);
               
            }
            else if (num1Digit != -1 && num2Digit == -1)
            {
                addedValue = num1Digit + carry;
                carry = GetCarry(addedValue);
                result = GetResult(addedValue, result);
            }
            else if (num2Digit != -1 && num1Digit == -1)
            {
                addedValue = num2Digit + carry;
                carry = GetCarry(addedValue);
                result = GetResult(addedValue, result);
            }
            
            visitedCharactersCount++;
       
        }

        if (carry > 0)
        {
            result = carry + result;
        }


        return result;
    }
    
    private int GetDigit(char character)
    {
        int digit = -1;
        int zeroDecimalValue = 48;
        int characterDecimalValue = (int)character;
        digit = characterDecimalValue - zeroDecimalValue;
        
        return digit;
    }

    private int GetCarry(int addedValue)
    {
        int carry = -1;
        
        if (addedValue >= 10)
        {
            carry = addedValue / 10;
            addedValue = addedValue % 10;
        }
        else
        {
            carry = 0;
        }

        return carry;
    }
    
    private string GetResult(int addedValue, string result)
    {
        if (addedValue >= 10)
        {
            addedValue = addedValue % 10;
            result = addedValue + result;
        }
        else
        {
            result = addedValue + result;
        }
        
        return result;
    }
}