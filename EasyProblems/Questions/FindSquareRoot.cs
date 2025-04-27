namespace EasyProblems.Questions;
/// <summary>
///Given a non-negative integer x, return the square root of x rounded down to the nearest integer.
/// The returned integer should be non-negative as well.
///You must not use any built-in exponent function or operator.
///For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
///Input: x = 4
///Output: 2
///Explanation: The square root of 4 is 2, so we return 2.
///Example 2:
/// Input: x = 8
/// Output: 2
///Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
/// </summary>
public class FindSquareRoot
{
    public int MySqrt(int n)
    {
        int l = 0;
        int r = n;
        int res = 0;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;  
            if (Math.Pow(mid, 2) > n)
            {
                r = mid - 1;
            }
            else if (Math.Pow(mid, 2) < n)
            {
                l = mid + 1;
                res = mid; // we want to store the highest mid value which is smaller than x. It will be our answer.
            }
            else
            {
                return mid;
            }
        }
        return res;
    }
}