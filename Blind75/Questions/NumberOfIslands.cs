namespace Blind75.Questions;

// LeetCode 200: Number of Islands
// Grid of '1' (land) / '0' (water). Count islands (4-directionally connected land).
// Key insight: scan every cell; each new unvisited '1' starts a new island (count++),
// then DFS flood-fills (sinks '1' -> '0') the whole island so it isn't counted again.
// Water and grid edges bound each island (DFS returns on '0' / out of bounds).

public class NumberOfIslands
{
    private int rows, cols;

    // Pattern: DFS flood fill on a grid
    // Time: O(m*n) | Space: O(m*n) worst case (recursion stack if grid is one big island)
    public int NumIslands(char[][] grid)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        int count = 0;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (grid[i][j] == '1')
                {
                    count++;
                    Dfs(grid, i, j);
                }

        return count;
    }

    private void Dfs(char[][] grid, int r, int c)
    {
        // bounds FIRST (short-circuit), then water/visited — else IndexOutOfRange
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == '0') return;
        grid[r][c] = '0';                 // sink visited land
        Dfs(grid, r + 1, c);              // down
        Dfs(grid, r - 1, c);              // up
        Dfs(grid, r, c + 1);              // right
        Dfs(grid, r, c - 1);              // left
    }
}
