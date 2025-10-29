namespace LeetCode.Easy;
using System.Collections.Generic;

public class MyQueue
{
    private Stack<int> leftStack;
    private Stack<int> rightStack;
    
    public MyQueue() 
    {
       leftStack = new Stack<int>();    
       rightStack = new Stack<int>();  
    }
    
    public void Push(int x)
    {
        while (rightStack.Count > 0)
        {
            int poppedInteger = rightStack.Pop();
            leftStack.Push(poppedInteger);       
        }

        leftStack.Push(x);
    }
    
    public int Pop()
    {
        int poppedInteger = -1;
        fillRightStack();
        poppedInteger = rightStack.Pop();
        return poppedInteger;
    }
    
    public int Peek() 
    {
       int peekedInteger = -1;
       fillRightStack();
       peekedInteger = rightStack.Peek();
       return peekedInteger;
    }
    
    public bool Empty()
    {
        bool isEmpty = leftStack.Count == 0 && rightStack.Count == 0;
        return isEmpty;
    }


    private void fillRightStack()
    {
        while (leftStack.Count > 0)
        {
            int poppedInteger = leftStack.Pop();
            rightStack.Push(poppedInteger);       
        }
    }

}