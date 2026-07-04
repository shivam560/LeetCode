namespace Blind75.Questions;

// LeetCode 994: Rotting Oranges
// Grid: 0 = empty, 1 = fresh, 2 = rotten. Every minute, rotten oranges rot their
// 4-directional fresh neighbors. Return minutes until no fresh remain, else -1.
// Key insight: MULTI-SOURCE BFS — all initially-rotten oranges start in the queue
// together; each BFS level = one minute (level-size snapshot). Count fresh during
// the scan; rot a neighbor -> freshCount--, enqueue it (the queue spreads it NEXT
// minute — no recursion, that would be DFS and rot everything in one minute).

public class RottingOranges
{
    // Pattern: BFS (multi-source) on grid, level = minute
    // Time: O(m*n) — scan + each cell enqueued/dequeued at most once.
    // Space: O(m*n) — worst case all cells rotten in the queue at once.
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        var queue = new Queue<(int, int)>();
        int freshCount = 0;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 2) queue.Enqueue((i, j));
                else if (grid[i][j] == 1) freshCount++;
            }

        int minutes = 0;
        while (queue.Count > 0 && freshCount > 0)
        {
            minutes++;
            int size = queue.Count;                    // snapshot: is minute ke rotten
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();

                if (r + 1 < rows && grid[r + 1][c] == 1)
                {
                    grid[r + 1][c] = 2;
                    freshCount--;
                    queue.Enqueue((r + 1, c));
                }
                if (r - 1 >= 0 && grid[r - 1][c] == 1)
                {
                    grid[r - 1][c] = 2;
                    freshCount--;
                    queue.Enqueue((r - 1, c));
                }
                if (c + 1 < cols && grid[r][c + 1] == 1)
                {
                    grid[r][c + 1] = 2;
                    freshCount--;
                    queue.Enqueue((r, c + 1));
                }
                if (c - 1 >= 0 && grid[r][c - 1] == 1)
                {
                    grid[r][c - 1] = 2;
                    freshCount--;
                    queue.Enqueue((r, c - 1));
                }
            }
        }

        return freshCount == 0 ? minutes : -1;
    }
}
