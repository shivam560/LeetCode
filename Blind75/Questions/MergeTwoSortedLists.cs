namespace Blind75.Questions;

public class MergeTwoSortedLists
{
    public Node MergeTwoLists(Node list1, Node list2)
    {
        Node t1 = list1;
        Node t2= list2;
        Node dummy = new Node(-1);
        Node temp = dummy;
        while (list1 != null && list2 != null)
        {
            if (list1.Data < list2.Data)
            {
                temp.Next = list1;
                temp = list1;
                list1 = list1.Next;
            }
            else
            {
                temp.Next = list2;
                temp = list2;
                list2 = list2.Next;
            }
        }

        if (list1 != null) temp.Next = list1;
            else temp.Next = list2;

        return dummy.Next;
    }
}