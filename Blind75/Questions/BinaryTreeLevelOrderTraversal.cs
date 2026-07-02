namespace Blind75.Questions;

// LeetCode 102: Binary Tree Level Order Traversal
// Return node values level by level (list of lists).
// Key insight: BFS with a queue. At the START of each level, queue.Count == number of
// nodes in that level -> snapshot it, process exactly that many, enqueue their children
// (= next level). That snapshot is what separates one level from the next.
// (TreeNode is defined in MaximumDepthOfBinaryTree.cs)

public class BinaryTreeLevelOrderTraversal
{
    // Pattern: BFS (queue) with level-size snapshot
    // Time: O(n) — each node enqueued/dequeued once. Space: O(n) — widest level (~n/2).
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;          // snapshot BEFORE the loop
            var level = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(level);
        }
        return result;
    }
}
