namespace Blind75.Questions;

// LeetCode 322: Coin Change — fifth DP problem (2026-09-15)
// Given coin denominations and a target amount, return the FEWEST coins needed to
// make that amount, or -1 if it's impossible. Coins may be reused (unbounded).
//
// dp[i] = minimum number of coins needed to make amount i.
// dp[i] = Math.Min(dp[i], dp[i - coin] + 1) for every coin that fits (coin <= i).
// The +1 counts the coin we just used.
//
// WHY FILL WITH amount + 1 (the "impossible" sentinel):
//   - The answer can never exceed `amount` (worst case: all 1-value coins), so
//     amount+1 is a value a real answer can never take -> a safe "unreachable" marker.
//   - int.MaxValue would OVERFLOW on `dp[i - coin] + 1` and wrap negative.
// At the end, if dp[amount] is still the sentinel, the amount is unreachable -> -1.
//
// WHY GREEDY FAILS: amount 6 with coins [4,1,3] — greedy takes 4 first, then 1+1
// = 3 coins, but 3+3 = 2 coins is better. Local "biggest coin first" is not optimal.
//
// Note: `dp[amount] > amount` is a slightly more defensive final check than
// `== amount + 1`, in case the sentinel logic ever changes.

public class CoinChange
{
    // Pattern: Bottom-up DP (unbounded knapsack shape)
    // Time: O(A * C) — A = amount, C = number of coins. Space: O(A).
    public int Change(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);   // sentinel = "impossible"
        dp[0] = 0;                    // zero amount needs zero coins

        for (int currentAmount = 1; currentAmount <= amount; currentAmount++)
        {
            foreach (int coin in coins)
            {
                if (currentAmount - coin >= 0)   // coin actually fits
                {
                    dp[currentAmount] = Math.Min(dp[currentAmount],
                                                 dp[currentAmount - coin] + 1);
                }
            }
        }

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }

    private Dictionary<int, int> memo = new Dictionary<int, int>();

    // TOP-DOWN (recursion + memoization) — same problem, opposite direction.
    // Base case: amount == 0 -> 0 coins.
    // Instead of an `amount < 0` base case, guard BEFORE recursing with
    // `amount - coin >= 0` so the invalid call is never made at all.
    // Can't use Math.Min directly over raw results: -1 means "impossible" and would
    // win every Min. So track `best` and only fold in results that are >= 0.
    // Storing -1 in the memo matters too — otherwise impossible amounts get recomputed.
    //
    // Caveat: the memo key is only `amount`, but the answer also depends on `coins`.
    // Fine on LeetCode (fresh object per test); in production, scope the cache to coins.
    //
    // Time: O(A * C) | Space: O(A) cache + O(A) recursion stack
    public int ChangeTopDown(int[] coins, int amount)
    {
        if (amount == 0) return 0;
        if (memo.ContainsKey(amount)) return memo[amount];

        int best = int.MaxValue;
        foreach (int coin in coins)
        {
            if (amount - coin >= 0)
            {
                int small = ChangeTopDown(coins, amount - coin);
                if (small >= 0)                      // only usable if that path worked
                    best = Math.Min(best, small + 1);
            }
        }

        best = best == int.MaxValue ? -1 : best;
        memo[amount] = best;
        return best;
    }
}
