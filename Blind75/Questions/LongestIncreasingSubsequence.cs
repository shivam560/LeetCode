namespace Blind75.Questions;

// Question: Return the length of the longest strictly increasing subsequence.
// Preserve array order; elements may be skipped, but equal values cannot extend it.
// Example: nums = [3,1,2,5,4] -> 3, from [1,2,5] or [1,2,4].
// Assumption: nums is nonempty.

public class LongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
        {
            for (int previousIndex = 0; previousIndex < currentIndex; previousIndex++)
            {
                if (nums[previousIndex] < nums[currentIndex])
                {
                    dp[currentIndex] = Math.Max(dp[currentIndex], dp[previousIndex] + 1);
                }
            }
        }

        return dp.Max();
    }
}
