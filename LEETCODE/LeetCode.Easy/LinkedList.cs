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


