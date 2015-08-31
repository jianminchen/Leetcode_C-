using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99RecoverBinarySearchTreeB
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
            /*
             * Test case 1:
             */
            TreeNode n1 = new TreeNode(0);
            n1.left = new TreeNode(1);

            //recoverTree(n1);

            TreeNode n2 = new TreeNode(2);
            n2.right = new TreeNode(1);

            recoverTree(n2); 


        }

        /*
         * Reference: 
         * http://www.jiuzhang.com/solutions/recover-binary-search-tree/
         * 
         * julia's comment:
         * 1. the code could not pass online judge 
         * 
         *  Input:
                [2,null,1]
                Output:
                [2,null,0]
                Expected:
                [1,null,2]
         *  But, my own test case shows correct. 
         */

        private static TreeNode theFirst  = null;
        private static TreeNode theSecond = null;
        private static TreeNode theLast   = new TreeNode(int.MinValue);

        public static void recoverTree(TreeNode root)
        {
            // traverse and get two elements
            traverse(root);
            // swap
            int temp = theFirst.val;
            theFirst.val = theSecond.val;
            theSecond.val = temp;
        }

        private static void traverse(TreeNode t)
        {
            if (t == null)
            {
                return;
            }

            traverse(t.left);


            bool inIncreasingOrder = t.val > theLast.val;
            if (! inIncreasingOrder)  // not in increasing order 
            {
                if (theFirst == null)
                {
                    theFirst = t;
                    theSecond = theLast;
                }
                else
                {
                    TreeNode tmp = theSecond;
                    theFirst = tmp; 
                    theSecond = t;
                }
            }
            
            theLast = t;
            traverse(t.right);
        }        
    }
}
