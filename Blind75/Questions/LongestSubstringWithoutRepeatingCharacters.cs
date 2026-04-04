namespace Blind75.Questions;

// LeetCode 3: Longest Substring Without Repeating Characters
// Given a string s, find the length of the longest substring without repeating characters.
// Key insight: Use dictionary to track last index of each char. On duplicate, jump left to Math.Max(left, dict[char] + 1) — never move left backward.
// Example: s = "abcabcbb" → 3 ("abc")

public class LongestSubstringWithoutRepeatingCharacters
{
    // Pattern: Sliding Window (Variable)
    // Time: O(n) | Space: O(n)
    public int LengthOfLongestSubstring(string s)
    {
        int left = 0;
        int max = 0;
        var dict = new Dictionary<char, int>();
        for (int right = 0; right < s.Length; right++)
        {
            if (dict.ContainsKey(s[right]))
                left = Math.Max(left, dict[s[right]] + 1);
            dict[s[right]] = right;
            max = Math.Max(max, right - left + 1);
        }
        return max;
    }
}
