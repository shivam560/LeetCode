namespace Blind75.Questions;

// LeetCode 503: Next Greater Element II
// Circular array — for each element, find the next greater number, wrapping around
// to the start if needed. If none exists, -1.
// Key insight: Monotonic decreasing stack of indices, but iterate 2*n times using
// idx = i % n to simulate going around the array twice (so wrapped next-greaters are
// found). Push only during the first pass (i < n). Default result to -1.
// Example: [1,2,1] -> [2,-1,2]

public class NextGreaterElementII
{
    // Pattern: Monotonic Stack + circular traversal (modulo)
    // Time: O(n) | Space: O(n)
    public int[] NextGreaterElements(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        Array.Fill(result, -1);
        var stack = new Stack<int>();

        for (int i = 0; i < 2 * n; i++)
        {
            int idx = i % n;
            while (stack.Count > 0 && nums[stack.Peek()] < nums[idx])
            {
                int k = stack.Pop();
                result[k] = nums[idx];
            }
            if (i < n)
                stack.Push(idx);
        }
        return result;
    }
}
