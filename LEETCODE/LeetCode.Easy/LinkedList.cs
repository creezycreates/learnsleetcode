namespace LeetCode.Easy;

// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
     
    public ListNode(int val=0, ListNode? next= null) {
        this.val = val;
        this.next = next;
    }
}

public class LinkedList
{
    public bool IsPalindrome(ListNode head)
    {
        bool isPalindrome = false;
        ListNode? nodeinOriginalList = head;
        ListNode? nodeinReversedList = null;
        ListNode? cloneHeadNode = Clone(head);
        ListNode? reversedHeadNode = ReverseList(cloneHeadNode);
        
        
        nodeinOriginalList = head;
        nodeinReversedList = reversedHeadNode;

        while (nodeinOriginalList != null && nodeinReversedList != null)
        {
            if(nodeinOriginalList.val == nodeinReversedList.val)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = false;
                break;
            }
            
            nodeinOriginalList = nodeinOriginalList.next;
            nodeinReversedList = nodeinReversedList.next;
        }
        
        return isPalindrome;
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode? nextNode = null;
        ListNode? previousNode = null;
        ListNode? currentNode = head;

        while (currentNode != null)
        {
            nextNode = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            currentNode = nextNode;
            
            if(currentNode == null)
            {
                head = previousNode;
            }
        }
        
        return head;
    }
    
    public ListNode Clone(ListNode head)
    {
        ListNode? headCloneNode = null;
        ListNode? currentNode = head;
        ListNode? tempNode = null;
        ListNode? nextNode = null;
        

        while (currentNode != null)
        {
            if(currentNode == head)
            {
                headCloneNode = new ListNode(currentNode.val);
                tempNode = headCloneNode;
            }
            else
            {
                nextNode = new ListNode(currentNode.val);
                tempNode.next = nextNode;
                tempNode = nextNode;
            }
            
            currentNode = currentNode.next;
        }
        
        return headCloneNode;
    }
    
    
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode? currentNode = head;
        ListNode? tempNode = null;
        
        //Input: head = [1,1,1,2]

        while (currentNode != null)
        {
            while (currentNode.next != null && currentNode.val == currentNode.next.val)
            {
                tempNode = currentNode.next;
                currentNode.next = tempNode.next;
                tempNode = null;
            }
            
            currentNode = currentNode.next;
        }


        return head;

    }
    
    
    
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode? currentNode = head;
        ListNode? previousNode = null;

        while (currentNode != null) //1,2,3,6,4,5,6
        {
            // This is the case where the node we need to remove is the head
            if (currentNode.val == val && currentNode == head)
            {
                head = RemoveHead(head);
                currentNode = head;
            }
            else if(currentNode.val == val)
            {
                RemoveNode(previousNode, currentNode);
                currentNode = currentNode.next;
            }
            else
            {
                previousNode = currentNode;
                currentNode = currentNode.next;
            }
            
        }
      
        return head;
    }

    public void Print(ListNode head)
    {
        ListNode current = head;
        Console.Write(">> ");
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
                Console.Write(" -> ");
            current = current.next;
        }
    }

    private void RemoveNode(ListNode? previousNode, ListNode? currentNode)
    {
        if(previousNode != null && currentNode != null)
        {
            previousNode.next = currentNode.next;
            currentNode = null;
        }
    }

    private ListNode RemoveHead(ListNode head)
    {
        if (head != null)
        {
            var previousNode = head;
            head = previousNode.next;
            previousNode = null;
        }
        
        return head;
    }
}


