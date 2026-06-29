namespace Blind75.Questions;

// LeetCode 104: Maximum Depth of Binary Tree
// Return the max depth = number of nodes along the longest root-to-leaf path.
// Key insight: DFS via recursion. A tree's depth = 1 (current node) + the deeper
// of its two subtrees. Base case: an empty node (null) has depth 0.
// Example:        1
//                / \
//               2   3      -> depth 3
//              / \   \
//             4   5   6

public class MaximumDepthOfBinaryTree
{
    // Pattern: DFS (recursion)
    // Time: O(n) — every node visited once. Space: O(h) — recursion stack = tree height.
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
