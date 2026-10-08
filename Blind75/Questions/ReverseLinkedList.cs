namespace Blind75.Questions;

// Question: Reverse a singly linked list and return its new head.
// Example: 1 -> 2 -> 3 -> null becomes 3 -> 2 -> 1 -> null.

public class ReverseLinkedList
{
    public Node Reverse(Node head)
    {
        Node curr = head;   
        Node prev = null;
        Node next;
        while (curr != null)
        {
            next = curr.Next;
            curr.Next = prev;   
            prev = curr;
            curr = next;
            
        }

        return prev;
    }
}


public class Node
{
    public Node Next { get; set; }  
    public int Data { get; set; }

    public Node(int data, Node next=null)
    {
        Data = data;
        Next = next;
    }
}
