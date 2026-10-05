namespace Blind75.Questions;

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
