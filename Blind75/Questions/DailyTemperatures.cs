namespace Blind75.Questions;

// LeetCode 739: Daily Temperatures
// For each day, how many days until a warmer temperature? 0 if none.
// Key insight: Monotonic DECREASING stack of indices. For each day, while today is warmer
// than the day on top of the stack, that day is resolved → pop it, answer = i - poppedIndex.
// Then push today. Days left in the stack never see a warmer day → stay 0 (default).
// Example: [73,74,75,71,69,72,76,73] → [1,1,4,2,1,1,0,0]

public class DailyTemperatures
{
    // Pattern: Monotonic Stack (decreasing, stores indices)
    // Time: O(n) — each index pushed once, popped at most once (amortized). Space: O(n) — stack.
    public int[] GetDailyTemperatures(int[] temps)
    {
        int[] result = new int[temps.Length];
        var stack = new Stack<int>();

        for (int i = 0; i < temps.Length; i++)
        {
            while (stack.Count > 0 && temps[stack.Peek()] < temps[i])
            {
                int k = stack.Pop();
                result[k] = i - k;
            }
            stack.Push(i);
        }
        return result;
    }
}
