namespace EasyProblems.Questions;

// LeetCode 746: Min Cost Climbing Stairs — fourth DP problem (2026-09-11)
// cost[i] = price to LEAVE step i. You may start free at index 0 or 1.
// Return the min cost to reach the TOP — which is index n (one PAST the last step).
//
// THE confusing part (arrive vs leave):
//   dp[i]   = min cost to REACH step i        <- standing there
//   cost[i] = ticket to LEAVE step i          <- moving on
// Metro analogy: standing on the platform is free; boarding the train costs a ticket.
// That's why dp[0] = dp[1] = 0 — you're placed there for free — while cost[0]/cost[1]
// only get paid inside the recurrence, when you step OFF.
//
//   dp[i] = Math.Min(dp[i-1] + cost[i-1],   // came one step
//                    dp[i-2] + cost[i-2])   // came two steps
// "minimum cost" => Math.Min (vs "how many ways" => sum).
//
// Two easy traps: dp must be size n+1, and the loop must run to i <= n — otherwise
// dp[n] (the TOP) is never filled and you return 0.

public class MinCostClimbingStairs
{
    // Pattern: Bottom-up DP
    // Time: O(n) | Space: O(n) — could be O(1) with two sliding variables.
    public int MinCost(int[] cost)
    {
        int[] dp = new int[cost.Length + 1];   // +1 for the TOP
        dp[0] = 0;                             // free start
        dp[1] = 0;                             // free start

        for (int i = 2; i <= cost.Length; i++) // <= : must reach the TOP
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1],
                             dp[i - 2] + cost[i - 2]);

        return dp[cost.Length];
    }
}
