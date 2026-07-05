namespace EasyProblems.Questions;

// LeetCode 303: Range Sum Query — Immutable
// Given an array, answer many queries: "sum of elements from index i to j?"
// Key insight: the CLASSIC prefix array. prefix[k] = sum of first k elements
// (size n+1, prefix[0] = 0). Then sumRange(i, j) = prefix[j+1] - prefix[i].
// Trade: O(n) preprocessing once in the constructor -> every query is O(1).
// (Brute force would be O(n) PER query — the whole point is killing that.)

public class RangeSumQueryImmutable
{
    private int[] prefix;   // field — visible to both constructor and SumRange

    // Time: O(n) once | Space: O(n)
    public RangeSumQueryImmutable(int[] nums)
    {
        prefix = new int[nums.Length + 1];          // n+1; prefix[0] stays 0
        for (int k = 0; k < nums.Length; k++)
            prefix[k + 1] = prefix[k] + nums[k];    // "balance after k+1 elements"
    }

    // Time: O(1) — one subtraction, no loop. That's the payoff.
    public int SumRange(int i, int j)
    {
        return prefix[j + 1] - prefix[i];
    }
}
