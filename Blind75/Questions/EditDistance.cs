using System;
using System.Collections.Generic;

// Problem: Edit Distance (LeetCode 72)
// Minimum number of operations (insert, remove, modify one character) to turn word1 into word2.
//
// Example:
// Input:  word1 = "LOVE", word2 = "MOVIE"
// Output: 2   (LOVE -> MOVE by modifying L->M, then MOVE -> MOVIE by inserting I)
//
// Recurrence (Case A: last characters differ, Case B: they match):
//   A: 1 + Min(remove, insert, modify)
//   B: no cost, take the diagonal
//
// Bottom-up:  dp[i, j] = edit distance of the first i chars of x and first j chars of y.
//             Base row/column: dp[i, 0] = i (i removes), dp[0, j] = j (j inserts).
//             Remove = dp[i-1, j], Insert = dp[i, j-1], Modify = dp[i-1, j-1].
//             Time O(N * M). Space O(N * M); only the previous row is needed, so O(M) is possible.
//
// Top-down:   Solve(i, j) = edit distance of the SUFFIXES x[i..] and y[j..].
//             Base: i == x.Length -> y.Length - j inserts; j == y.Length -> x.Length - i removes.
//             Time O(N * M). Space O(N * M) memo + O(N + M) recursion stack.

public class EditDistanceSolution
{
    // Bottom-up (prefix state). Written by the learner.
    public int EditDistance(string x, string y)
    {
        int[,] dp = new int[x.Length + 1, y.Length + 1];

        for (int i = 0; i <= x.Length; i++)
        {
            dp[i, 0] = i;
        }

        for (int j = 0; j <= y.Length; j++)
        {
            dp[0, j] = j;
        }

        for (int i = 1; i <= x.Length; i++)
        {
            for (int j = 1; j <= y.Length; j++)
            {
                if (x[i - 1] == y[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
            }
        }

        return dp[x.Length, y.Length];
    }

    // Top-down (suffix state). Logic is the learner's; the three compile fixes (declare `answer`,
    // missing semicolon, Solve/EditDistanceTopDown naming) and memo.Clear() were applied when saving.
    private readonly Dictionary<(int i, int j), int> memo = new();

    public int EditDistanceTopDown(string a, string b)
    {
        // memo key is only (i, j), so stale entries from a previous input would give wrong answers.
        memo.Clear();
        return Solve(0, 0, a, b);
    }

    private int Solve(int i, int j, string a, string b)
    {
        if (i == a.Length)
            return b.Length - j;
        if (j == b.Length)
            return a.Length - i;

        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];

        int answer;
        if (a[i] == b[j])
            answer = Solve(i + 1, j + 1, a, b);
        else
            answer = 1 + Math.Min(Solve(i + 1, j, a, b), Math.Min(Solve(i, j + 1, a, b), Solve(i + 1, j + 1, a, b)));

        memo[(i, j)] = answer;
        return answer;
    }

    // Learner's corrected Oct 14 1D algorithm, saved under a distinct method name.
    // Dimension guidance and two syntax fixes were needed; cold recall is pending.
    // Problem: minimum inserts, deletes or replacements to convert a into b.
    // Example: a = "ab", b = "ba" => 2.
    // Trace: [0,1,2] -> [1,1,1] -> [2,1,2] (base-column correction in chat).
    // Time O(N*M); extra space O(M), M = b.Length. No shorter-string swap here.
    // Compilation/execution/LeetCode acceptance unverified for this method.
    public int EditDistance1D(string a, string b)
    {
        int[] dp = new int[b.Length + 1];
        for (int j = 0; j <= b.Length; j++)
            dp[j] = j;

        for (int i = 1; i <= a.Length; i++)
        {
            // Pehle old base bachao; phir current row ka base update karo.
            int prevDiagonal = dp[0];
            dp[0] = i;

            for (int j = 1; j <= b.Length; j++)
            {
                int temp = dp[j]; // Old TOP next column ka diagonal banega.
                if (a[i - 1] == b[j - 1])
                    dp[j] = prevDiagonal;
                else
                    dp[j] = 1 + Math.Min(dp[j], Math.Min(dp[j - 1], prevDiagonal));

                prevDiagonal = temp;
            }
        }

        return dp[b.Length];
    }
}
