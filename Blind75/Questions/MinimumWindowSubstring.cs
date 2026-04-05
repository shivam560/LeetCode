namespace Blind75.Questions;

// LeetCode 76: Minimum Window Substring
// Given strings s and t, find the smallest substring of s that contains all characters of t.
// Key insight: Two dictionaries — need (what t requires) and window (what we have). Track matched count.
// Expand right to grow window. When all chars matched, shrink left to find smallest valid window.
// Example: s = "ADOBECODEBANC", t = "ABC" → "BANC"

public class MinimumWindowSubstring
{
    // Pattern: Sliding Window (Variable)
    // Time: O(n) | Space: O(n)
    public string MinWindow(string s, string t)
    {
        var need = new Dictionary<char, int>();
        foreach (var c in t)
        {
            if (need.ContainsKey(c))
                need[c]++;
            else
                need[c] = 1;
        }

        var window = new Dictionary<char, int>();
        int left = 0, matched = 0;
        int minLen = int.MaxValue, minStart = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (window.ContainsKey(s[right]))
                window[s[right]]++;
            else
                window[s[right]] = 1;

            if (need.ContainsKey(s[right]) && window[s[right]] == need[s[right]])
                matched++;

            while (matched == need.Count)
            {
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }
                window[s[left]]--;
                if (need.ContainsKey(s[left]) && window[s[left]] < need[s[left]])
                    matched--;
                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }
}
