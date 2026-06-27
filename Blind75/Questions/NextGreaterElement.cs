namespace Blind75.Questions;

// LeetCode 496: Next Greater Element I
// nums1 is a subset of nums2. For each element of nums1, find the first greater
// element to its right in nums2. If none, -1.
// Key insight: Monotonic decreasing stack over nums2 builds a {value -> next greater}
// map (nums2 values are distinct). Then nums1 is just O(1) lookups.
// Example: nums1 = [4,1,2], nums2 = [1,3,4,2] -> [-1, 3, -1]

public class NextGreaterElement
{
    // Pattern: Monotonic Stack + HashMap
    // Time: O(m + n) | Space: O(m)   (m = nums2.Length, n = nums1.Length)
    public int[] NextGreaterElementI(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, int>();
        var stack = new Stack<int>();
        int[] result = new int[nums1.Length];

        for (int i = 0; i < nums2.Length; i++)
        {
            while (stack.Count > 0 && stack.Peek() < nums2[i])
            {
                int k = stack.Pop();
                dict[k] = nums2[i];
            }
            stack.Push(nums2[i]);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            if (dict.ContainsKey(nums1[i]))
                result[i] = dict[nums1[i]];
            else
                result[i] = -1;
        }
        return result;
    }
}
