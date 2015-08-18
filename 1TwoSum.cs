using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    public class Node{
        public int id,val;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://www.acmerblog.com/leetcode-two-sum-5223.html
         * 
         * 解法1：先排序，然后从开头和结尾同时向中间查找，原理也比较简单。复杂度O(nlogn)
         * 
         * julia's comment: 
         * 
         */
        public static ArrayList twoSum(int[] numbers, int target)
        {
            int len = numbers.Length;
            Node[] tmpNodes = new Node[len];

            for (int i = 0; i < len; i++)
            {
                tmpNodes[i].id = i + 1;
                tmpNodes[i].val = numbers[i];
            }

            Node[] nodes = sortArray(tmpNodes);

            int start = 0, end = len - 1;

            ArrayList ans = new ArrayList();

            while (start < end)
            {
                if (nodes[start].val + nodes[end].val == target)
                {

                    if (nodes[start].id > nodes[end].id)
                    {
                        swap(ref tmpNodes, start, end);

                        ans.Add(tmpNodes[start].id);
                        ans.Add(tmpNodes[end].id);

                        return ans;

                    }
                    else if (tmpNodes[start].val + tmpNodes[end].val < target)
                        start++;
                    else
                        end--;
                }
            }

            return ans; 
        }

        public static void swap(ref Node[] nA, int start, int end)
        {
            Node tmp = nA[start];
            nA[start] = nA[end];
            nA[end] = tmp; 
        }

        public static Node[] sortArray(Node[] nA)
        {
            return nA;   // implement later
        }

        public static bool compare(Node a, Node  b){
            return a.val < b.val;
        }
    }
}
