using System;

// Problem: Longest Common Subsequence (LCS)
// Return the length of the longest subsequence present in both strings.
// Characters must keep relative order but do not need to be contiguous.
//
// Example:
// Input:  text1 = "abc", text2 = "ac"
// Output: 2
// Explanation: "ac" is a longest common subsequence.
//
// Optimized complexity:
// Time:  O(N * M)
// Space: O(M) for this orientation; O(min(N, M)) if the shorter string is used as the DP-column string.

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int[] dp = new int[text2.Length + 1];

        for (int i = 1; i <= text1.Length; i++)
        {
            // At j = 1, the previous-row diagonal is dp[i - 1, 0].
            // Column 0 represents the empty string, so that value is always 0.
            int prevDiagonal = 0;

            for (int j = 1; j <= text2.Length; j++)
            {
                // Before overwriting, dp[j] is the TOP value from the previous row.
                // Save it because it becomes the diagonal for the next column.
                int temp = dp[j];

                if (text1[i - 1] == text2[j - 1])
                {
                    dp[j] = 1 + prevDiagonal;
                }
                else
                {
                    // dp[j] is previous-row TOP; dp[j - 1] is current-row LEFT.
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }

                prevDiagonal = temp;
            }
        }

        return dp[text2.Length];
    }

    // Reference 2D version used to derive the optimized recurrence.
    // Example: text1 = "abc", text2 = "ac" => 2
    public int LongestCommonSubsequence2D(string text1, string text2)
    {
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <= text2.Length; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[text1.Length, text2.Length];
    }

    // Top-down reference reconstructed from the documented Oct 12 recurrence.
    // Assistant-saved reference, not a fresh learner implementation or verified run.
    // Example: text1 = "abc", text2 = "ac" => 2.
    // Time O(N*M); space O(N*M) memo plus O(N+M) recursion stack.
    public int LongestCommonSubsequenceTopDown(string text1, string text2)
    {
        // Har call ka apna memo: previous inputs ke cached results reuse nahi honge.
        var memo = new System.Collections.Generic.Dictionary<(int i, int j), int>();

        int Solve(int i, int j)
        {
            if (i == text1.Length || j == text2.Length)
                return 0;
            if (memo.TryGetValue((i, j), out int cached))
                return cached;

            int answer = text1[i] == text2[j]
                ? 1 + Solve(i + 1, j + 1)
                : Math.Max(Solve(i + 1, j), Solve(i, j + 1));
            memo[(i, j)] = answer;
            return answer;
        }

        return Solve(0, 0);
    }
}
