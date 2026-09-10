namespace Blind75.Questions;

// LeetCode 62: Unique Paths — third DP problem, and the first TOP-DOWN (memoized) one.
// Robot at grid[0][0] must reach grid[m-1][n-1], moving only DOWN or RIGHT.
// Count the distinct paths.
//
// Recursion first (the 3 questions):
//   1. My one step? At (r,c) I have two choices: go down, or go right.
//   2. Who do I ask?  paths(r+1, c) and paths(r, c+1) — leap of faith.
//   3. When do I stop? Off the grid -> 0 (invalid, dead end).
//                      On the destination -> 1 (already there = one complete path).
// Combine with + (not Max): "how many WAYS" => sum. Both branches are valid paths.
//
// Plain recursion recomputes subproblems — in a 2x3 grid alone, Paths(1,1) and
// Paths(1,2) are each computed twice; it blows up exponentially on bigger grids.
// Memoization ("don't recompute — write it down") fixes it: 3 extra lines —
// check cache, compute, store.
//
// NOTE (real-world): `memo` as an instance field is fine for LeetCode (fresh object per
// test) but is a bug if the same object is reused with different m/n — (r,c) means
// something different per grid. In production, scope the cache to the input.

public class UniquePaths
{
    private Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();

    // Pattern: Top-down DP (recursion + memoization)
    // Time: O(m*n) — each (r,c) computed once. Space: O(m*n) cache + O(m+n) call stack.
    public int Paths(int r, int c, int m, int n)
    {
        if (r >= m || c >= n) return 0;              // walked off the grid
        if (r == m - 1 && c == n - 1) return 1;      // reached destination

        if (memo.ContainsKey((r, c))) return memo[(r, c)];   // cache hit

        int result = Paths(r + 1, c, m, n) + Paths(r, c + 1, m, n);

        memo[(r, c)] = result;                       // store before returning
        return result;
    }

    // LeetCode's entry point
    public int UniquePathsCount(int m, int n) => Paths(0, 0, m, n);
}
