namespace Blind75.Questions;

// Question: Can all positive integers be divided into two groups with equal sums?
// Each array element belongs to one group; group sizes need not be equal.
// Example: nums = [1,5,11,5] -> true; groups [1,5,5] and [11].
// Example: nums = [1,2,5] -> false. Both methods solve the same problem.

public class PartitionEqualSubsetSum
{
    public bool CanPartitionOptimized(int[] nums)
    {
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0)
        {
            return false;
        }

        int target = totalSum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;

        foreach (int currentNumber in nums)
        {
            for (int currentSum = target; currentSum >= currentNumber; currentSum--)
            {
                dp[currentSum] = dp[currentSum] || dp[currentSum - currentNumber];
            }
        }

        return dp[target];
    }

    public bool CanPartition(int[] nums)
    {
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0)
        {
            return false;
        }

        int target = totalSum / 2;
        bool[,] dp = new bool[nums.Length + 1, target + 1];
        dp[0, 0] = true;

        for (int availableItems = 1; availableItems <= nums.Length; availableItems++)
        {
            for (int currentSum = 0; currentSum <= target; currentSum++)
            {
                int currentNumber = nums[availableItems - 1];
                if (currentNumber <= currentSum)
                {
                    dp[availableItems, currentSum] = dp[availableItems - 1, currentSum]
                        || dp[availableItems - 1, currentSum - currentNumber];
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
