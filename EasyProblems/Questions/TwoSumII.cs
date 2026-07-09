namespace EasyProblems.Questions;

// LeetCode 167: Two Sum II — Input Array Is Sorted
// Same as Two Sum (his very first problem!) but the array is SORTED — and that
// changes the tool: HashMap (O(n) space) -> Two Pointers (O(1) space).
// Rule: sum > target -> right-- (smaller number), sum < target -> left++ (bigger).
// Works BECAUSE sorted: left++ guarantees increase, right-- guarantees decrease.
// Trap: answer is 1-indexed.

public class TwoSumII
{
    // Pattern: Two Pointers (converging) on sorted array
    // Time: O(n) — pointers walk toward each other one step at a time, covering
    // the whole array between them (meeting in the middle ≠ halving! no space is
    // discarded, so NOT O(log n) — that's binary search). Space: O(1).
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int s = numbers[left] + numbers[right];
            if (s == target)
                return new int[] { left + 1, right + 1 };   // 1-indexed
            else if (s < target)
                left++;
            else
                right--;
        }
        return new int[0];   // never reached — LC guarantees one solution
    }
}
