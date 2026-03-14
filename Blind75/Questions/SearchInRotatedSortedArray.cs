namespace Blind75.Questions;

// LeetCode 33: Search in Rotated Sorted Array
// A sorted array is rotated at some pivot. Find target's index or return -1.
// Key insight: At any mid, one half is always sorted. Check which half is sorted (nums[left] <= nums[mid]),
//              then check if target falls within that sorted half's range.
// Example: nums = [4,5,6,7,0,1,2], target = 0 → 4

public class SearchInRotatedSortedArray
{
    // Pattern: Binary Search
    // Time: O(log n) | Space: O(1)
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target) return mid;

            if (nums[left] <= nums[mid])
            {
                if (target >= nums[left] && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            else
            {
                if (target > nums[mid] && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return -1;
    }
}
