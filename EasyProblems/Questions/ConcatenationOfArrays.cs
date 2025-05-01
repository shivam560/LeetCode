namespace EasyProblems.Questions;
/// <summary>
/// leetcode link: https://leetcode.com/problems/concatenation-of-array/description/
/// Given an integer array nums of length n, you want to create an array ans of length 2n where ans[i] == nums[i] and ans[i + n] == nums[i] for 0 <= i < n (0-indexed).
///Specifically, ans is the concatenation of two nums arrays.
///Return the array ans.
/// Example 1:
/// Input: nums = [1,2,1]
///Output: [1,2,1,1,2,1]
/// Example 2:
/// Input: nums = [1,3,2,1]
/// Output: [1,3,2,1,1,3,2,1]
/// </summary>
public class ConcatenationOfArrays
{
    public int[] GetConcatenation(int[] nums)
    {
        int l = nums.Length;
        var result = new int[l*2];
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = nums[i % nums.Length];
            }
        }

        return result;
    }
}