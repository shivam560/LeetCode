namespace Blind75.Questions;

// LeetCode 64: Minimum Path Sum
// Given a m x n grid filled with non-negative numbers, find a path from top left to
// bottom right, which minimizes the sum of all numbers along its path.
// You can only move either down or right at any point in time.
// Example: [[1,3,1],[1,5,1],[4,2,1]] -> 7 (path 1→3→1→1→1).
//
// 2026-10-24 — fresh DP TRANSFER problem (never seen before).
// State, recurrence, base cases and the full 3x3 table derived at H0 (no hints).
// Code needed fixes: loops started at 0 (dp[-1] crash), base loops used grid[i-1]
// instead of dp[i-1] (one cell's cost vs. the whole path sum), return dp[rows,cols].
// Final version compiled + ran on 4 tests (7, 12, 5, 6) — all correct.
//
// State: dp[i,j] = minimum path SUM from (0,0) to (i,j), including grid[i][j].
// Recurrence: dp[i,j] = grid[i][j] + Min(top, left) — you can only arrive from above or left.
// Base: dp[0,0] = grid[0][0]; row 0 has no top (only left); col 0 has no left (only top).

public class MinimumPathSum
{
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length; int cols = grid[0].Length;
        int[,] dp = new int[rows, cols];
        dp[0, 0] = grid[0][0];

        for (int i = 1; i < rows; i++)
            dp[i, 0] = grid[i][0] + dp[i - 1, 0];   // first column: only from top

        for (int j = 1; j < cols; j++)
            dp[0, j] = grid[0][j] + dp[0, j - 1];   // first row: only from left

        for (int i = 1; i < rows; i++)
            for (int j = 1; j < cols; j++)
                dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);

        return dp[rows - 1, cols - 1];
    }
}
