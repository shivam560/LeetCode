namespace EasyProblems.Questions;

// LeetCode 704: Binary Search
// Given a sorted array nums and a target, return the index of target. If not found, return -1.
// Key insight: Halve the search space each step. Move left = mid + 1 or right = mid - 1 to avoid infinite loop.
// Example: nums = [-1, 0, 3, 5, 9, 12], target = 9 → 4

public class BinarySearch
{
    // Pattern: Binary Search (Classic)
    // Time: O(log n) | Space: O(1)
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target) return mid;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}
