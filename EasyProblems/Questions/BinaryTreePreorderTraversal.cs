namespace EasyProblems.Questions;
/// <summary>
/// leetcode link: https://leetcode.com/problems/binary-tree-preorder-traversal/description/
/// Given the root of a binary tree, return the preorder traversal of its nodes' values.
/// Example 1:
/// Input: root = [1,null,2,3]
///Output: [1,2,3]
/// Example 2:
/// Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
/// Output: [1,2,4,5,6,7,3,8,9]
/// </summary>
public class BinaryTreePreorderTraversal
{
    public IList<int> PreorderTraversal(BinaryTreePostorderTraversal.TreeNode root) {
        Stack<BinaryTreePostorderTraversal.TreeNode> stack = new(); 
        List<int> result = new();   
        //BinaryTreePostorderTraversal.TreeNode current = root;
        stack.Push(root);
        while (stack.Count > 0 )
        {
            BinaryTreePostorderTraversal.TreeNode node = stack.Pop();
            result.Add(node.val);

            if (node.right is not null)
            {
                stack.Push(node.right); 
            }
            if(node.left is not null)
            {
                stack.Push(node.left);  
            }
        }
        
        return result;  
    }
}