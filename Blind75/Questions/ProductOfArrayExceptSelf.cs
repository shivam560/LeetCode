namespace Blind75.Questions;

// LeetCode 238: Product of Array Except Self
// Given array nums, return array where each element is product of all elements except itself. No division allowed.
// Key insight: Each answer = left product × right product. Two passes — left to right, then right to left.
// Use result array for left pass, then multiply right pass directly into it.
// Example: nums = [1, 2, 3, 4] → [24, 12, 8, 6]

public class ProductOfArrayExceptSelf
{
    // Pattern: Prefix Product (left + right)
    // Time: O(n) | Space: O(1) — only the output array
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];

        int prod = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prod;
            prod *= nums[i];
        }

        prod = 1;
        for (int j = nums.Length - 1; j >= 0; j--)
        {
            result[j] *= prod;
            prod *= nums[j];
        }

        return result;
    }
}
