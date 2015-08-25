using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109ConvertSortedListToBinarySearchTreeB
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
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            l1.next.next.next.next.next = new ListNode(6);
            l1.next.next.next.next.next.next = new ListNode(7);

            TreeNode head = sortedListToBST(l1);
        }

        /*
         * reference: 
         * https://github.com/soulmachine/leetcode
         * 
         * analysis from the above blog: 
         * LeetCode, Convert Sorted List to Binary Search Tree
           bottom-up，时间复杂度O(n)，空间复杂度O(logn)
         * 
         * understand the analysis from the blog:
         * http://codeganker.blogspot.ca/2014/11/leetcode.html
         * 
         * 先来看看最简单的Convert Sorted Array to Binary Search Tree，数组本身是有序的，那么我们知道每次只要取中点作为根，
         * 然后递归构建对应的左右子树就可以了，递归的写法跟常规稍有不同，就是要把根root先new出来，然后它的左节点接到递归左边
         * 部分的返回值，右节点接到递归右边部分的返回值，最后将root返回回去。这个模板在树的构造中非常有用，其他几道题也都是按照这个来实现。

           接下来是Convert Sorted List to Binary Search Tree，这个跟Convert Sorted Array to Binary Search Tree比较近似，
         * 区别是元素存储的数据结构换成了链表，不过引入了一个重要的问题，就是链表的访问不是随机存取的，也就是不是O(1)的，如果每次
         * 去获取中点，然后进行左右递归的话，我们知道得到中点是O(n/2)=O(n)的，如此递推式是T(n) = 2T(n/2)+n/2，复杂度是O(nlogn)，
         * 并不是线性的，所以这里我们就得利用到树的中序遍历了，按照递归中序遍历的顺序对链表结点一个个进行访问，而我们要构造的二分查找树
         * 正是按照链表的顺序来的。如此就能按照链表的访问顺序来构造，不会因此而增加找中间结点的复杂度。
         * 
         * julia's comment:
         * 1. Try to use ref in the function argument of list
         * 2. Read the website: 
         * http://stackoverflow.com/questions/4311226/list-passed-by-ref-help-me-explain-this-behaviour
         * 3. Online judge:
         *    32 / 32 test cases passed.
              Status: Accepted
              Runtime: 176 ms
         * 
         */

        public static TreeNode sortedListToBST(ListNode head) {
            int len = 0;
            ListNode p = head;
            while (p != null) {
                len++;
                p = p.next;
            }
            return sortedListToBST(ref head, 0, len - 1);
        }

        private static TreeNode sortedListToBST(ref ListNode list, int start, int end) {
            if (start > end) 
                return null;

            int mid = start + (end - start) / 2;
            TreeNode leftChild = sortedListToBST(ref list, start, mid - 1);
            TreeNode parent = new TreeNode(list.val);

            parent.left = leftChild;
            list = list.next;
 
            parent.right = sortedListToBST(ref list, mid + 1, end);

            return parent;
        }
    }
}
