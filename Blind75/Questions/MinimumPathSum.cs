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

    // 1D, O(cols) space — 2026-10-24 daytime, closed notes.
    // His own idea: treat a missing neighbour as int.MaxValue so Math.Min ignores it —
    // filling dp with MaxValue makes row 0 need no special loop (top = "infinity").
    // He found the overflow cell himself: (0,0), where top AND left are both MaxValue.
    // Bug fixed after one hint: dp[0] = grid[0][0] was written BEFORE Array.Fill, so Fill erased it.
    // Compiled + ran the same 4 tests (7, 12, 5, 6) — all correct.
    // Before update: dp[j] = old TOP (row i-1), dp[j-1] = new LEFT (row i).
    public int MinPathSum1D(int[][] grid)
    {
        int cols = grid[0].Length;
        int[] dp = new int[cols];
        Array.Fill(dp, int.MaxValue);
        dp[0] = grid[0][0];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 && j == 0) continue;            // MaxValue + grid would overflow
                if (j == 0) dp[j] = grid[i][j] + dp[j];    // first column: only from top
                else dp[j] = grid[i][j] + Math.Min(dp[j], dp[j - 1]);
            }
        }
        return dp[cols - 1];
    }

    // Top-down — 2026-10-24 daytime. State/recurrence/base cases given unaided:
    // Solve(i,j) = min sum from (i,j) to bottom-right; top call Solve(0,0).
    // Off-grid -> int.MaxValue so Math.Min never picks it. Destination is the only cell
    // where BOTH calls would be off-grid, so its base case must come before the recursion.
    // Bug found by running: memo was a class field, so a 2nd grid on the same object reused
    // the 1st grid's (0,0) answer (12 -> 7). Fix: memo is local per call.
    // Time O(rows*cols); space O(rows*cols) memo + O(rows+cols) recursion stack.
    public int MinPathSumTopDown(int[][] grid)
    {
        var memo = new Dictionary<(int, int), int>();
        return Solve(0, 0, grid, memo);
    }

    private int Solve(int i, int j, int[][] grid, Dictionary<(int, int), int> memo)
    {
        if (i == grid.Length - 1 && j == grid[0].Length - 1) return grid[i][j];
        if (i > grid.Length - 1 || j > grid[0].Length - 1) return int.MaxValue;

        if (memo.ContainsKey((i, j))) return memo[(i, j)];
        int answer = grid[i][j] + Math.Min(Solve(i + 1, j, grid, memo), Solve(i, j + 1, grid, memo));
        memo[(i, j)] = answer;
        return answer;
    }
}
