namespace Blind75.Questions;

// Question: Can the entire string be split into words from wordDict?
// Keep character order; words must be contiguous and dictionary words may be reused.
// Example: s = "applepenapple", wordDict = ["apple","pen"] -> true.
// Split: apple | pen | apple. Both methods solve the same problem.

public class WordBreak
{
    public bool WordBreakTopDown(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        var memo = new Dictionary<int, bool>();

        return Solve(s, 0, wordSet, memo);
    }

    private bool Solve(
        string s,
        int start,
        HashSet<string> wordSet,
        Dictionary<int, bool> memo)
    {
        if (start == s.Length)
            return true;

        if (memo.ContainsKey(start))
            return memo[start];

        for (int end = start; end < s.Length; end++)
        {
            string word = s.Substring(start, end - start + 1);

            if (wordSet.Contains(word) && Solve(s, end + 1, wordSet, memo))
            {
                memo[start] = true;
                return true;
            }
        }

        memo[start] = false;
        return false;
    }

    public bool WordBreakBottomUp(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;

        for (int end = 1; end <= s.Length; end++)
        {
            for (int start = 0; start < end; start++)
            {
                string word = s.Substring(start, end - start);

                if (dp[start] && wordSet.Contains(word))
                {
                    dp[end] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}
