namespace Blind75.Questions;

public class DetectCycleInLinkedList
{
    public bool DetectLoop(Node head)
    {
        Node slow = head;
        Node fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if(slow == fast)    return true; //this will only be true in case of a cycle loop because both will surely meet at one point    
        }                                     //beacuse fast is moving by 2 and slow by 1 their net distance is 2-1 = 1, so there will be
        return false;                         // a point where they will meet. This algo is called Tortoise and Hare Algo.
    } 
}

///Another way to solve this is using HashMap
/// var hashset = new HashSet<Node>();
/// Node curr = head;
/// while(curr!=null){
/// if(hashset.Contains(curr)){
/// return true;
/// }
/// hashset.Add(curr);
/// curr=curr.next;
/// }
/// return false
/// }