namespace Blind75.Questions;

// LeetCode 142: Linked List Cycle II
// Given a linked list, return the node where the cycle begins. If no cycle, return null.
// Key insight: After slow and fast meet, send one pointer back to head.
// Move both at 1 step — where they meet is the cycle start. Math: A = C - B.
// Example: 1 → 2 → 3 → 4 → 5 → 3 → cycle start = node 3

public class LinkedListCycleII
{
    // Pattern: Fast & Slow Pointers (Floyd's Cycle Detection)
    // Time: O(n) | Space: O(1)
    public ListNode DetectCycle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                var pointer1 = head;
                var pointer2 = slow;
                while (pointer1 != pointer2)
                {
                    pointer1 = pointer1.next;
                    pointer2 = pointer2.next;
                }
                return pointer1;
            }
        }
        return null;
    }
}
