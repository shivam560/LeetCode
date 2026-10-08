namespace Blind75.Questions;

// Question: Maximize total value while total weight is at most capacity.
// Each item may be chosen once; weights and values describe the same item indices.
// Example: weights = [2,3,4], values = [30,40,50], capacity = 5 -> 70.
// Choose the first two items. Assumptions: positive weights, equal array lengths,
// nonnegative capacity, and value totals fitting int.

public class ZeroOneKnapsack
{
    public int Knapsack(int[] weights, int[] values, int capacity)
    {
        int itemCount = weights.Length;
        int[,] dp = new int[itemCount + 1, capacity + 1];

        for (int availableItems = 1; availableItems <= itemCount; availableItems++)
        {
            for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
            {
                int itemWeight = weights[availableItems - 1];
                int itemValue = values[availableItems - 1];

                if (itemWeight <= currentCapacity)
                {
                    int take = itemValue + dp[availableItems - 1, currentCapacity - itemWeight];
                    int skip = dp[availableItems - 1, currentCapacity];
                    dp[availableItems, currentCapacity] = Math.Max(take, skip);
                }
                else
                {
                    dp[availableItems, currentCapacity] = dp[availableItems - 1, currentCapacity];
                }
            }
        }

        return dp[itemCount, capacity];
    }
}
