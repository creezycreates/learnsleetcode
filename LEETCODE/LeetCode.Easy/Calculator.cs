using System;

namespace LeetCode.Easy
{
    public static class Calculator
    {
        //Given a non-negative integer x, return the square root of x rounded down 
        //to the nearest integer.The returned integer should be non-negative as well.
        //You must not use any built-in exponent function or operator.
        //For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.

        //Example 1:
        
        //Input: x = 4
        //Output: 2
        //Explanation: The square root of 4 is 2, so we return 2.
        //Example 2:

        //Input: x = 8
        //Output: 2
        //Explanation: The square root of 8 is 2.82842..., and since we round it down 
        //to the nearest integer, 2 is returned.

        //Constraints:

        //0 <= x <= 2^31 - 1

        public static int Sqrt(int x)
        {
            int y = 0;
            int quotient = 0;
            int lowerBound = -1;
            int upperBound = -1;
          

            if (x > 0)
            {
                quotient = x;
                while (true)
                {
                    quotient = quotient / 2;
                   
                    if (((double)(quotient) * (double)(quotient)) == x)
                    {
                        y = quotient;
                        break;
                    }
                    else if (((double)(quotient) * (double)(quotient)) > x)
                    {
                        if ((double)(quotient - 1) * (double)(quotient - 1) < x)
                        {
                            y = quotient - 1;
                            break;
                        }
                        else
                        {
                            upperBound = quotient;
                        }
                            
                    }
                    else if (((double)(quotient) * (double)(quotient)) < x)
                    {
                        lowerBound = quotient;
                        y = quotient;
                    }
                    if (lowerBound == 0)
                    {
                        upperBound = x;
                    }
                    if (lowerBound >= 0 && upperBound >= 0)
                    {
                        for (int i = lowerBound; i <= upperBound; i++)
                        {
                            if ((double)(i) * (double)(i) == x)
                            {
                                y = i;
                                break;
                            }
                            else if ((double)(i) * (double)(i) > x)
                            {
                                y = i - 1;
                                break;
                            }
                        }
                    }

                    if (y > 0)
                    {
                        break;
                    }
                }
            }
            return y;
        }
    }
}
