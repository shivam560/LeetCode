namespace Blind75.Questions;

// LeetCode 2492: Minimum Score of a Path Between Two Cities (Daily Challenge 2026-07-04)
// n cities, bidirectional weighted roads. Path score = min road distance on the path.
// Roads/cities may be revisited. Return the minimum possible score of a path 1 -> n.
// Key insight: revisits allowed => you can detour over ANY road reachable from city 1
// and come back. So the answer is simply the smallest road in the connected component
// containing 1 (and n — guaranteed same component). No path-finding needed!
// First real GRAPH problem: build an adjacency list, BFS from 1, min over every edge seen.

public class MinScoreOfPathBetweenCities
{
    // Pattern: BFS on graph (adjacency list). BFS over recursion: n up to 1e5 — deep
    // recursion risks StackOverflow; a queue lives on the heap.
    // Time: O(n + E) — build list O(n+E); BFS visits each city once, scans each
    // road's 2 entries once. Space: O(n + E) — adjacency list + queue/visited.
    public int MinScore(int n, int[][] roads)
    {
        // adjacency list: almari (array, n+1 slots — cities 1..n, slot 0 unused)
        // har drawer mein expandable file (List of (neighbor, dist))
        var adj = new List<(int city, int dist)>[n + 1];
        for (int i = 1; i <= n; i++) adj[i] = new List<(int, int)>();

        foreach (var road in roads)
        {
            int a = road[0], b = road[1], d = road[2];
            adj[a].Add((b, d));   // bidirectional — road appears on both pages
            adj[b].Add((a, d));
        }

        int minScore = int.MaxValue;
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(1);
        visited.Add(1);

        while (queue.Count > 0)
        {
            int c = queue.Dequeue();
            foreach (var (city, dist) in adj[c])
            {
                // edge ALWAYS counts, even if neighbor already visited
                minScore = Math.Min(minScore, dist);
                if (!visited.Contains(city))
                {
                    visited.Add(city);
                    queue.Enqueue(city);
                }
            }
        }   // return AFTER the whole BFS — not inside the loop!

        return minScore;
    }
}
