namespace EasyProblems.Questions;

// Max Sum Subarray of Size K
// Given an array of integers and a number k, find the maximum sum of any contiguous subarray of size k.
// Key insight: Fixed sliding window. Instead of recalculating the sum from scratch, reuse the previous sum:
//              subtract the element leaving the window, add the element entering.
//              "What can I reuse from the previous step?" → the core sliding window idea.
// Example: nums = [2, 1, 5, 1, 3, 2], k = 3 → 9 (subarray [5, 1, 3])

public class MaxSumSubarrayOfSizeK
{
    // Pattern: Sliding Window (Fixed Size)
    // Time: O(n) | Space: O(1)
    public int MaxSumSubarray(int[] nums, int k)
    {
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        int max = sum;

        for (int i = k; i < nums.Length; i++)
        {
            sum = sum - nums[i - k] + nums[i];
            max = Math.Max(max, sum);
        }

        return max;
    }
}
