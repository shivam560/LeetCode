namespace Blind75.Questions;

// LeetCode 11: Container With Most Water
// Given an array height of length n, where each element represents a vertical line.
// Find two lines that together with the x-axis form a container that holds the most water.
// Key insight: Always move the shorter pointer inward — width shrinks, so only a taller height can improve area.
// Example: height = [1,8,6,2,5,4,8,3,7] → 49

public class ContainerWithMostWater
{
    // Pattern: Two Pointers
    // Time: O(n) | Space: O(1)
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int max = 0;

        while (left < right)
        {
            int curr = Math.Min(height[left], height[right]) * (right - left);

            if (curr > max) max = curr;

            if (height[left] < height[right]) left++;
            else right--;
        }

        return max;
    }
}
