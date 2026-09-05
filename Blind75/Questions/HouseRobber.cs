namespace Blind75.Questions;

// LeetCode 198: House Robber — second DP problem (2026-09-05)
// Houses in a line, each with money. Can't rob two ADJACENT houses. Max money?
//
// STATE DEFINITION is the key move here:
//   dp[i] = "max money robbable from houses 0..i" — it does NOT mean house i was robbed.
// With that definition, at house i there are exactly two choices:
//   rob it   -> nums[i] + dp[i-2]   (can't use i-1)
//   skip it  -> dp[i-1]
//   dp[i] = Math.Max(nums[i] + dp[i-2], dp[i-1])
//
// Note vs Climbing Stairs: that asked "how many WAYS" -> SUM the options.
// This asks "MAX money" -> take Math.Max. Signal: "how many ways" => +,
// "max/min" => Math.Max / Math.Min.
//
// Why "skip TWO houses" cases work automatically: because dp[i-2] is itself a
// best-so-far, not "house i-2 was robbed". e.g. [5,1,1,5] -> 10 (houses 0 and 3).

public class HouseRobber
{
    // Bottom-up DP with a table.
    // Time: O(n) | Space: O(n)
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];   // guard: dp[1] would be out of range

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);     // can't take both — adjacent

        for (int i = 2; i < nums.Length; i++)
            dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);

        return dp[nums.Length - 1];
    }

    // Space-optimized: dp[i] only needs the previous two values — keep two variables
    // and slide them forward. Same shape as ClimbingStairsOptimized, only + -> Math.Max.
    // Time: O(n) | Space: O(1)
    public int RobOptimized(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int prev2 = nums[0];                    // dp[i-2]
        int prev1 = Math.Max(nums[0], nums[1]); // dp[i-1]

        for (int i = 2; i < nums.Length; i++)
        {
            int curr = Math.Max(nums[i] + prev2, prev1);
            prev2 = prev1;                      // slide
            prev1 = curr;
        }
        return prev1;
    }
}
