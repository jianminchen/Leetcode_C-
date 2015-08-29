using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98ValidateBinarySearchTree
{
    public class TreeNode
    {
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
         * http://fisherlei.blogspot.ca/2013/01/leetcode-validate-binary-search-tree.html
         * 
         * analysis from the above blog:
         * 对于每一个子树，限制它的最大，最小值，如果超过则返回false。
           对于根节点，最大最小都不限制；
           每一层节点，左子树限制最大值小于根，右子树最小值大于根；
           但是比较有趣的是，在递归的过程中还得不断带入祖父节点的值。

           或者，中序遍历该树，然后扫描一遍看是否递增。
         * 红字部分是关键点。不把变量遗传下去的话，没法解决如下例子：
            {10,5,15,#,#,6,20}
         * 
         * julia's comment:
         * 1. Failed to pass online judge: 
         *  [2147483647] input, false, should be true
         */
        public static bool isValidBST(TreeNode root) {  
            return IsValidBST(root, int.MinValue, int.MaxValue);  
       }  

       public static bool IsValidBST(TreeNode node, int MIN, int MAX)   
       {  
            if(node == null)  
                  return true;

            int v = node.val;
            bool rootInRange = v > MIN && v < MAX;                 // Range: (MIN, MAX) 
            if (!rootInRange) 
                return false;

            bool l_BST = IsValidBST(node.left, MIN, v);  // left sub tree BST check: new Range: (MIN, v)
            if (!l_BST)
                return false;

            bool r_BST = IsValidBST(node.right, v, MAX); // right sub tree BST check: new Range: (v, MAX)
            if (!r_BST)
                return false;

            return true; 
       }

       /*
        * julia's comment: 
        * 1. change int.MinValue to long.MinValue, int.MaxValue to long.MaxValue
        * 2. pass online judge: 
        *   74 / 74 test cases passed.
            Status: Accepted
            Runtime: 216 ms
        */
       public static bool isValidBST_B(TreeNode root)
       {
           return IsValidBST_B(root, long.MinValue, long.MaxValue);
       }

       public static bool IsValidBST_B(TreeNode node, long MIN, long MAX)
       {
           if (node == null)
               return true;

           int v = node.val;           
           if (!(v > MIN && v < MAX))                            // Range: (MIN, MAX) 
               return false;
          
           if (!IsValidBST_B(node.left, MIN, v))                 // left sub tree BST check: new Range: (MIN, v)
               return false;
          
           if (!IsValidBST_B(node.right, v, MAX))                // right sub tree BST check: new Range: (v, MAX)
               return false;

           return true;
       }

      
    }
}
