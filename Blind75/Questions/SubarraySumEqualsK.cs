namespace Blind75.Questions;

// LeetCode 560: Subarray Sum Equals K
// Given an integer array nums and integer k, return total number of contiguous subarrays whose sum equals k.
// Key insight: Running prefix sum + hashmap. If prefix - k exists in dict, a subarray summing to k exists.
// Same trick as Two Sum — check for complement before storing.
// Seed dict with {0:1} because a prefix sum of 0 means "from the very start."
// Example: nums = [1, 1, 1], k = 2 → 2

public class SubarraySumEqualsK
{
    // Pattern: Prefix Sum + HashMap
    // Time: O(n) | Space: O(n)
    public int SubarraySum(int[] nums, int k)
    {
        int sum = 0;
        int count = 0;
        var dict = new Dictionary<int, int>();
        dict[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (dict.ContainsKey(sum - k))
                count += dict[sum - k];
            if (dict.ContainsKey(sum))
                dict[sum]++;
            else
                dict[sum] = 1;
        }
        return count;
    }
}
