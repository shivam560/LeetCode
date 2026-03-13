namespace EasyProblems.Questions;

// LeetCode 125: Valid Palindrome
// Given a string s, return true if it is a palindrome.
// Consider only alphanumeric characters and ignore case.
// Example: "A man, a plan, a canal: Panama" → true
// Example: "race a car" → false

public class ValidPalindrome
{
    // Pattern: Two Pointers
    // Time: O(n) | Space: O(1)
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left])) { left++; continue; }
            if (!char.IsLetterOrDigit(s[right])) { right--; continue; }

            if (char.ToLower(s[left]) == char.ToLower(s[right]))
            {
                left++;
                right--;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
