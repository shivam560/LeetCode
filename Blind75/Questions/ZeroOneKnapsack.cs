namespace Blind75.Questions;

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
