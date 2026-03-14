namespace EasyProblems.Questions;

// LeetCode 278: First Bad Version
// You have n versions [1..n]. One version is bad, and all after it are bad.
// Given IsBadVersion(int version), find the first bad version.
// Key insight: Boundary binary search. When IsBadVersion(mid) is true, mid might be the answer — set right = mid, not mid - 1.
// Use left < right (not <=) to avoid infinite loop. When loop ends, left == right == answer.
// Example: n = 5, first bad = 4 → 4

public class FirstBadVersion
{
    // Pattern: Binary Search (Boundary)
    // Time: O(log n) | Space: O(1)
    public int FirstBadVersionResult(int n)
    {
        int left = 1;
        int right = n;

        while (left < right)
        {
            int mid = (left + right) / 2;

            if (IsBadVersion(mid)) right = mid;
            else left = mid + 1;
        }

        return left;
    }

    // Placeholder — provided by LeetCode
    private bool IsBadVersion(int version) => false;
}
