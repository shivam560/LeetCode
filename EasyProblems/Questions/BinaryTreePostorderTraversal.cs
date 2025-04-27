namespace EasyProblems.Questions;

/// <summary>
/// leetcode link: https://leetcode.com/problems/binary-tree-postorder-traversal/description/
/// Given the root of a binary tree, return the postorder traversal of its nodes' values.
/// Example 1:
/// Input: root = [1,null,2,3]
///Output: [3,2,1]
/// Example 2:
/// Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
/// Output: [4,6,7,5,2,9,8,3,1]
/// </summary>
public class BinaryTreePostorderTraversal
{
    public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
         }
    }
    
    public IList<int> PostorderTraversal(TreeNode root) {
        if (root is null)
        {
            return new List<int>(); 
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();  
        Dictionary<TreeNode, bool> visited = new Dictionary<TreeNode, bool>();
        List<int> result = new List<int>();  
        if (root != null)
        {
            stack.Push(root); // Push the root to the stack
        }
       
        visited.Add(root, false);
        while (stack.Count > 0)
        {
            var node = stack.Peek(); // we are just peeking the node, to check whether it is visited or not 
            var isVisited = visited.ContainsKey(node) ? visited[node]  : false;
            if (isVisited)
            {
                result.Add(node.val);
                stack.Pop(); // we are emptying the stack for the visited node
            }
            else
            {
                visited[node] = true; // if the current node is not visited we will mark it as visited
                if (node.right is not null) 
                {
                    stack.Push(node.right); // we want to first push the right node because it is a stack, it will be poped second last.
                   
                }

                if (node.left is not null)
                {
                    stack.Push(node.left); // left should be inserted last, it will be popped first 
                    
                }
            }
        }
           return result;
    }
}