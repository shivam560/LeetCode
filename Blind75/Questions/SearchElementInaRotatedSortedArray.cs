namespace Blind75.Questions;

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