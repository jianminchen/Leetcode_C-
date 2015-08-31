using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99RecoveryBinarySearchTree_C
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
         * Problem: Leetcode 99 - recover binary search tree
         * Reference: 
         * https://github.com/jianminchen/Leetcode_C-/blob/master/99RecoverBinarySearchTree.cs
         * 
         * julia's comment:
         * 1. Extract two functions: 
         *    findTheInorderPredecessorOfCurrent
         *    violationChecking        
         * 
         * 2. Add test cases for those two functions, 
         *    make them memorizable, testable, maintainable
         *   
         * 3. online judge passes
         *  1916 / 1916 test cases passed.
	        Status: Accepted
            Runtime: 324 ms
         * 
         */
        public static void recoverTree(TreeNode root)
        {
            TreeNode f1 = null,     // two vilation nodes, f1 and f2 
                     f2 = null;

            TreeNode ith,           // ith - current node, node will go through inorder traversal                                      
                     pr,            // pr - previous node
                     pa = null;     // pa - parent node

            if (root == null)
                return;

            bool found = false;

            ith = root;       // start from root node r
            // pa = null, and pr = null 

            while (ith != null)    // need to get into the inorder traversal without a stack - O(n) space
            {
                if (ith.left == null)
                {
                    violationChecking(pa, ith, ref f1, ref f2, ref found);

                    pa = ith;         // recover phase, go to next node; 
                                      // no left, then, go to the right. 
                    ith = ith.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pr = findTheInorderPredecessorOfCurrent(ith);

                    /* Make current as right child of its inorder predecessor */
                    if (pr.right == null)
                    {
                        pr.right = ith;
                        ith = ith.left;  // go to next iteration, left child. 
                    }

                    /* Revert the changes made in if part to restore the original
                    tree i.e., fix the right child of predecssor */
                    else
                    {
                        pr.right = null;   // revert the change. Why? Remember? 

                        violationChecking(pa, ith, ref f1, ref f2, ref found);

                        pa = ith;
                        ith = ith.right;    // go to next iteration, no left child, so right child. 
                    } /* End of if condition pre->right == NULL */
                } /* End of if condition current->left == NULL*/
            } /* End of while */

            if (f1 != null && f2 != null)  // swap f1 and f2 
            {
                int tmp = f1.val;
                f1.val = f2.val;
                f2.val = tmp;
            }
        }

        /* 
         * Find the inorder predecessor of current 
         * 
         * thought process:
         * start from input node n2, 
         * Go to left child first, and then, go the right continuously, 
         * until the last one, exclude input node - itself (n1), 
         * return the node (n1); 
         * Think in a graph of rightmost node in the binary search tree. 
         * Also, the code will work if the node is set as right child of 
         * its inordre predecessor. 
         * 
         */
        private static TreeNode findTheInorderPredecessorOfCurrent(TreeNode n2)
        {
            TreeNode n1 = n2.left;      // step 1: moving node (n1), go left first step 

            while (n1.right != null && n1.right != n2) // step 2: then, go right continuously;
                // exclude input node itself 
                n1 = n1.right;

            return n1;
        }

        /*
         *  previous -> current node
         *  thought process:
         *  if the current node visited has a not-null previous node, 
         *  then the two values of nodes should be in increasing order 
         *  
         * Base test case: 
         *   tree only have two nodes, switched; 
         *   case A: 
         *      2          1
         *     /    ->    /                               
         *     1         2
         *   case B: 
         *     1           2
         *      \    ->     \
         *      2            1
         *  Manually, walk through the code, make sure that f1 and f2 are correct results. 
         *  
         * input arguments: 
         *     n1 -  previous  -- 
         *     n2 -  current   --
         * output arguments:
         *      f1,       -- viloation node 1
         *      f2,       -- violation node 2 
         *      found     -- found 
         *  assumption: n2 node is not null
         *  violation facts:
         *  1. first node, it is the one with bigger value, violated; 
         *  but second node, it is the one with smaller value, violated. 
         *  2. sometimes, only one violation catch; like base case A, switch two nodes, only two nodes
         *     in the tree. Tree [2,#,1]
         *  3. sometimes, two violationes catch. 
         *     Tree [2, 3, 1], first one is 3, 2, second one is 2, 1. 
         */
        private static void violationChecking(TreeNode n1,
                                              TreeNode n2,
                                              ref TreeNode f1,
                                              ref TreeNode f2,
                                              ref bool found)
        {
            if (n1 != null && n1.val > n2.val)  // break "increasing order" principle
            {
                if (!found)
                {
                    f1 = n1;   // bigger value violated - first one always
                    found = true;
                }

                f2 = n2;       // smaller value violated - second one always 
            }
        }

    }
}
