namespace Blind75.Questions;

// Question: Count subsets whose elements sum to exactly target.
// Each position may be selected once; equal values at different indices are distinct.
// Example: nums = [1,2,3,4], target = 5 -> 2: [1,4] and [2,3].
// Example: nums = [2,2], target = 2 -> 2 (choose either position).
// Assumptions: positive numbers, nonnegative target, count fits int.
// For target 0, the empty subset is the one valid subset.

public class SubsetSumCounter
{
    public int CountSubsets(int[] nums, int target)
    {
        int[,] dp = new int[nums.Length + 1, target + 1];
        dp[0, 0] = 1;

        for (int availableItems = 1; availableItems <= nums.Length; availableItems++)
        {
            for (int currentSum = 0; currentSum <= target; currentSum++)
            {
                int currentNumber = nums[availableItems - 1];
                if (currentNumber <= currentSum)
                {
                    dp[availableItems, currentSum] = dp[availableItems - 1, currentSum]
                        + dp[availableItems - 1, currentSum - currentNumber];
                }
                else
                {
                    dp[availableItems, currentSum] = dp[availableItems - 1, currentSum];
                }
            }
        }

        return dp[nums.Length, target];
    }
}
