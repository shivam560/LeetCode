namespace Blind75.Questions;

// Question: Find a target in a rotated ascending array of distinct integers.
// Return its zero-based index, or -1 when absent.
// Example: nums = [4,5,6,7,0,1,2], target = 0 -> 4.

public class SearchElementInaRotatedSortedArray
{
    public int SearchElement(int[] nums, int target)
    {
        int lo = 0, hi = nums.Length - 1;

        while (lo <= hi)
        {
            var mid = (lo + hi) / 2;

            if (nums[mid] == target) return mid;

            if (nums[lo] <= nums[mid])
            {
                if (nums[lo] <= target && target <= nums[mid]) hi = mid - 1;
                else lo = mid + 1;  
            }
            else
            {
                if (nums[mid] <= target && target <= nums[hi]) lo = mid + 1;
                else hi = mid - 1;
            }
        }

        return -1;
    }
}
