using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124BinaryTreeMaximumPathSum
{
    public class TreeNode{
        public int val; 

        public TreeNode left; 
        public TreeNode right; 

        public TreeNode(int v)
        {
            val = v; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
        /*
         * Reference:
         * http://fisherlei.blogspot.ca/2013/01/leetcode-binary-tree-maximum-path-sum.html
         * Analysis from the above blog:
         * For each node like following, there should be four ways existing for max path:

            1. Node only
            2. L-sub + Node
            3. R-sub + Node
            4. L-sub + Node + R-sub

            Keep trace the four path and pick up the max one in the end.
         * 
           Julia's comment:
         * 1. Pass online judge: 
         *  92 / 92 test cases passed.
            Status: Accepted
            Runtime: 188 ms
         */
        public static int maxPathSum(TreeNode root) {  
          
          int maxAcrossRoot = Int16.MinValue;  

          int maxEndByRoot = GetMax(root, ref maxAcrossRoot);  

          return Math.Max(maxAcrossRoot, maxEndByRoot);  
        }  

        private static int GetMax(TreeNode node, ref int maxAcrossRoot)  
        {  
          if(node == null) 
              return 0;  

          int left = GetMax(node.left, ref maxAcrossRoot);  
          int right = GetMax(node.right, ref maxAcrossRoot);  

          int cMax = node.val;  
          
          if(left > 0)  
            cMax += left;  

          if(right > 0)  
            cMax+=right;  

          maxAcrossRoot = Math.Max(maxAcrossRoot, cMax);  

          int val = node.val; 
          int maxLR = Math.Max(node.val+left, node.val+right);

          return Math.Max( val, maxLR);  
        }

        /*
         * another version
         * 1.Julia's comment:
         *   pass online judge
         */
        public static int MaxPathSum_B(TreeNode root)
        {
            int max = Int32.MinValue;

            dfs(root, ref max);

            return max;
        }

        public static int dfs(TreeNode root, ref int max)
        {
            if (root == null) return 0;

            int l = dfs(root.left, ref max);
            int r = dfs(root.right, ref max);

            int m = root.val;

            if (l > 0) m += l;
            if (r > 0) m += r;

            if (m > max) max = m;

            return Math.Max(l, r) > 0 ? Math.Max(l, r) + root.val : root.val;
        }
    }
}
