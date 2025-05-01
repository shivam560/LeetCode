// See https://aka.ms/new-console-template for more information

using EasyProblems.Questions;

// FindSquareRoot findSquareRoot = new FindSquareRoot();
// Console.WriteLine(findSquareRoot.MySqrt(4));

// BinaryTreePostorderTraversal.TreeNode root = new BinaryTreePostorderTraversal.TreeNode(1);
// root.left = new BinaryTreePostorderTraversal.TreeNode(2);
// root.right = new BinaryTreePostorderTraversal.TreeNode(3);
//
// root.left.left = new BinaryTreePostorderTraversal.TreeNode(4);
// root.left.right = new BinaryTreePostorderTraversal.TreeNode(5);
//
// root.right.right = new BinaryTreePostorderTraversal.TreeNode(8);
//
// root.left.right.left = new BinaryTreePostorderTraversal.TreeNode(6);
// root.left.right.right = new BinaryTreePostorderTraversal.TreeNode(7);
//
// root.left.right.left.left = new BinaryTreePostorderTraversal.TreeNode(9);
//
// BinaryTreePreorderTraversal obj = new BinaryTreePreorderTraversal();  
// var result = obj.PreorderTraversal(root);
//
// foreach (var x in result)
// {
//     Console.WriteLine(x);
// }

ConcatenationOfArrays obj = new ConcatenationOfArrays();
var res = obj.GetConcatenation([1, 2, 1]);

foreach (var x in res)
{
     Console.WriteLine(x);
}