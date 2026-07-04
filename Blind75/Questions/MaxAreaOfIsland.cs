namespace Blind75.Questions;

// LeetCode 695: Max Area of Island
// Grid of 0 (water) / 1 (land) — ints this time, not chars. Return the area
// (cell count) of the largest island; 0 if none.
// Key insight: Number of Islands' flood fill + Max Depth's value-returning recursion.
// Dfs returns the area it flooded: 1 (self) + SUM of all 4 neighbors (sum, not max —
// area is total cells, not longest path). Main loop keeps Math.Max across islands.
// Sink (=0) BEFORE recursing so neighbors asking back get 0 — no double count/loop.

public class MaxAreaOfIsland
{
    private int rows, cols;

    // Pattern: DFS flood fill on grid, returning a value
    // Time: O(m*n) — each cell visited at most once.
    // Space: O(m*n) worst case — recursion stack if the whole grid is one island.
    public int MaxAreaOfIslandSolve(int[][] grid)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        int maxArea = 0;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (grid[i][j] == 1)
                {
                    int area = Dfs(grid, i, j);
                    maxArea = Math.Max(maxArea, area);
                }

        return maxArea;
    }

    private int Dfs(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] == 0)
            return 0;

        grid[i][j] = 0;   // sink first — visited
        return 1 + Dfs(grid, i + 1, j)
                 + Dfs(grid, i - 1, j)
                 + Dfs(grid, i, j + 1)
                 + Dfs(grid, i, j - 1);
    }
}
