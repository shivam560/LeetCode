namespace Blind75.Questions;

// LeetCode 239: Sliding Window Maximum
// Given an array nums and integer k, return the max value in each sliding window of size k.
// Key insight: Use a monotonic decreasing deque (stores indices). Front is always the max.
// Remove smaller elements from back (they'll never be the max). Remove expired indices from front.
// Example: nums = [1,3,-1,-3,5,3,6,7], k = 3 → [3,3,5,5,6,7]

public class SlidingWindowMaximum
{
    // Pattern: Sliding Window + Monotonic Deque
    // Time: O(n) | Space: O(k)
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var d = new LinkedList<int>();
        var result = new int[nums.Length - k + 1];

        for (int right = 0; right < nums.Length; right++)
        {
            while (d.Count > 0 && nums[d.Last.Value] < nums[right])
                d.RemoveLast();

            d.AddLast(right);

            if (d.First.Value <= right - k)
                d.RemoveFirst();

            if (right >= k - 1)
                result[right - k + 1] = nums[d.First.Value];
        }
        return result;
    }
}
