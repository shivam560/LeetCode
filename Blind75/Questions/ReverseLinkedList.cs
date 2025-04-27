namespace Blind75.Questions;

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
