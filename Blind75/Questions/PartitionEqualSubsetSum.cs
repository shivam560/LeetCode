namespace Blind75.Questions;

public class PartitionEqualSubsetSum
{
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
