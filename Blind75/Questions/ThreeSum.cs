namespace Blind75.Questions;

// LeetCode 15: 3Sum
// Given an array nums, find all unique triplets [a, b, c] such that a + b + c = 0.
// No duplicate triplets allowed.
// Key insight: Sort first. Fix one number, then use Two Pointers for the remaining two.
//              Skip duplicates by comparing with previous element (sorted = duplicates are adjacent).
// Example: [-1, 0, 1, 2, -1, -4] → [[-1, -1, 2], [-1, 0, 1]]

public class ThreeSum
{
    // Pattern: Two Pointers (with sorting)
    // Time: O(n²) | Space: O(1)
    public IList<IList<int>> ThreeSumResult(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0) left++;
                else right--;
            }
        }

        return result;
    }
}
