using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109ConvertSortedListToBinarySearchTreeC
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int v)
        {
            val = v;
        }
    }

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
         * 
         * reference: 
         * https://github.com/soulmachine/leetcode
         * 
         * 自顶向下，时间复杂度O(n^2)，空间复杂度O(logn)
         * 
         * Julia's comment:
         * 
         * 1. put my understanding next to the source code; 
         * 2. Try to cut the time to do calculation, pay attention to len%/2, which may be 0 or 1
         * 3. Pass online judge  (Try 3 times, over 10 minutes to make the calculation correct!  August 25, 2015)
         *    the original book's calculation could not pass online judge)
         *    Get experience to handle the divide and conquer, calculation. 
         *    
         *  32 / 32 test cases passed.
            Status: Accepted
            Runtime: 172 ms
         *    
         */

        public static TreeNode sortedListToBST(ListNode head)
        {
            return sortedListToBST(head, listLength(head));
        }

        public static TreeNode sortedListToBST(ListNode head, int len) {
            if (len == 0) return null;
           
            if (len == 1) return 
                new TreeNode (head.val);

            // put all calculations here - think about how to spend shortest time on the calculation 
            int rootIndex    = len / 2 ;       // starting from 0, 
            int rightTreeHeadIndex = len /2 + 1;  // example: len is even, 1, 2, 3, 4 four node
                                                  // left tree, 1, 2, then, root index: 


            int leftTreeLen  = len / 2;        // 
            int rightTreeLen = len - len/2 -1; // leftTreeLen + rightTreeLen + 1 = len; 
                                               // len can be even or odd, so len%2 can be 1 or 0 
                                              
            

            ListNode nthNode = nth_node(head, rootIndex);

            TreeNode root = new TreeNode(nthNode.val);   // Julia's comment: cost of calculation: O(n/2) , 
                                                         // go through the list node one by one starting from head. 
                                                         // how many times: O(log n), height of tree
                                                         // time complexity: O(n logn) 
                                                         // if the root node can be random accessed like array, hashmp, O(1)
                                                         // then, this algorithm will not be best in time complexity. 
                                                         // this should be considered when you choose the algorithm, 
                                                         // this is called top-down

            root.left = sortedListToBST(head, leftTreeLen);

            ListNode secondHalf = nth_node(head, rightTreeHeadIndex);
            root.right = sortedListToBST(secondHalf, rightTreeLen);

            return root;
        }

        private static int listLength(ListNode node)
        {
            int n = 0;
            while (node != null)
            {
                ++n;
                node = node.next;
            }

            return n;
        }

        private static ListNode nth_node(ListNode node, int n)
        {
            while (n > 0)
            {
                node = node.next;

                n--; 
            }

            return node;
        }
    }
}
