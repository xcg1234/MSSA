using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7_3
{
    internal class FindNodeInBinaryTree
    {
        // Make TreeNode 'public' to fix CS0050 and CS0051
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val, TreeNode Left = null, TreeNode Right = null)
            {
                this.val = val;
                this.left = Left;
                this.right = Right;
            }
        }

        public static TreeNode FindNode(TreeNode root, int target)
        {
            if (root == null) return null;
            if (root.val == target) return root;
            return FindNode(root.left, target) ?? FindNode(root.right, target);
        }
    }
}
