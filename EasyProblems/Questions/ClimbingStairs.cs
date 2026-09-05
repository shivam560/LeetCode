namespace EasyProblems.Questions;

// LeetCode 70: Climbing Stairs — FIRST DP PROBLEM (2026-09-05)
// n stairs, you can climb 1 or 2 steps at a time. How many distinct ways to the top?
//
// Derivation (think BACKWARDS): standing on stair i, where could you have come from?
// Only from stair i-1 (one step) or stair i-2 (two steps) — no other option.
// So ways(i) = ways(i-1) + ways(i-2). The two groups never overlap (one ends with a
// 1-step, the other with a 2-step), hence ADD them. That's Fibonacci.
// Base cases (counted by hand): ways(1) = 1, ways(2) = 2.
//
// Why DP and not plain recursion? Recursion recomputes the same subproblems
// exponentially (Ways(3) twice, Ways(2) three times, ... for n=5 alone).
// DP = "don't compute what you already computed — write it down."

public class ClimbingStairs
{
    // Bottom-up DP with a table.
    // Time: O(n) | Space: O(n)
    public int ClimbStairs(int n)
    {
        int[] dp = new int[n + 1];
        if (n == 1) return 1;          // guard: dp[2] would be out of range

        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];

        return dp[n];
    }

    // Space-optimized: dp[i] only ever needs the previous TWO values, so the rest of
    // the array is dead memory. Keep two variables and slide them forward — same idea
    // as the sliding window in Max Sum Subarray of Size K.
    // Time: O(n) | Space: O(1)
    public int ClimbStairsOptimized(int n)
    {
        if (n == 1) return 1;

        int prev2 = 1, prev1 = 2;      // ways(1), ways(2)
        for (int i = 3; i <= n; i++)
        {
            int curr = prev1 + prev2;
            prev2 = prev1;             // slide
            prev1 = curr;
        }
        return prev1;
    }
}
