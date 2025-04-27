namespace Blind75.Questions;

/// <summary>
///     leetcode link : https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
///     explanation for the algo : https://takeuforward.org/data-structure/minimum-in-rotated-sorted-array/
///     Question: Given an integer array arr of size N, sorted in ascending order (with distinct values).
///     Now the array is rotated between 1 to N times which is unknown. Find the minimum element in the array.
///     Example: Input Format:  array = [4,5,6,7,0,1,2,3]
///     Result: 0
///     Explanation:  Here, the element 0 is the minimum element in the array.
/// </summary>
public class FindMinimumInRotatedSortedArray
{
    public int FindMinimum(int[] array)
    {
        var min = int.MaxValue;
        int lo = 0, hi = array.Length - 1;

        while (lo <= hi)
        {
            var mid = (lo + hi) / 2;
            if (array[lo] <= array[mid]) //this means minimum is in right half. This condition tells us the left half is the sorted subarray hence we are always take the lo from left half and discrad the remaining elements because we know fisrt would be the minimum
            {
                min = Math.Min(min, array[lo]);
                lo = mid + 1; // we have moved our lo to the right half because we have already taken the min from the lft which was in array[lo] hence we dont need the rest of elements 
            }
            else // this means minimum is in left half
            {
                min = Math.Min(min, array[mid]);
                hi = mid - 1;
            }
        }

        return min;
    }
}